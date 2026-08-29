using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Equipo;
using LogicaAplicacion.Dtos.Observacion;
using LogicaAplicacion.Mapper;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace LogicaAplicacion.CasosUso.Observaciones
{
    public class CUEvaluarObservacion
        : ICUEvaluacionConIA<EvaluarObservacionDto, EvaluacionIAResponseDto>
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioObjetoCeleste _repoObjeto;

        public CUEvaluarObservacion(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioEquipo repoEquipo,
            IRepositorioObjetoCeleste repoObjetoCeleste)
        {
            _repoPrestamo = repoPrestamo;
            _repoEquipo = repoEquipo;
            _repoObjeto = repoObjetoCeleste;
        }

        public EvaluacionIAResponseDto Execute(EvaluarObservacionDto dto)
        {
            var prestamo = _repoPrestamo.GetById(dto.prestamoId)
                ?? throw new InvalidOperationException("Préstamo no encontrado");

            var objetoCeleste = _repoObjeto.GetById(dto.objetoCelesteId)
                ?? throw new InvalidOperationException("Objeto celeste no encontrado");

            var telescopio = EquipoMapper.ToListadoDto(
                _repoEquipo.GetById(prestamo.Telescopio.Id)
            );

            var montura = EquipoMapper.ToListadoDto(
                _repoEquipo.GetById(prestamo.Montura.Id)
            );

            EquipoListadoDto camara = null;
            EquipoListadoDto ocular = null;

            if (prestamo.Camara != null)
                camara = EquipoMapper.ToListadoDto(
                    _repoEquipo.GetById(prestamo.Camara.Id)
                );

            if (prestamo.Ocular != null)
                ocular = EquipoMapper.ToListadoDto(
                    _repoEquipo.GetById(prestamo.Ocular.Id)
                );

            var input = new
            {
                dto.usuarioId,
                dto.fechaObservacion,
                telescopio,
                montura,
                camara,
                ocular,
                objeto_celeste = objetoCeleste
            };

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text =
                                "Eres un sistema experto en astrofotografía. " +
                                "Devuelve SOLO JSON válido sin markdown ni texto adicional. " +
                                "{ \"indicador\": \"IDEAL\" | \"ADECUADO\" | \"NO_RECOMENDABLE\", \"detalle\": \"máx 300 caracteres\" }. " +
                                "No inventes datos. Usa solo el input. " +
                                JsonSerializer.Serialize(input)
                            }
                        }
                    }
                }
            };

            using var client = new HttpClient();

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent"
            );

            request.Headers.Add("X-goog-api-key", "poner apikey aca");

            request.Content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = client.Send(request);
            var resultJson = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                return new EvaluacionIAResponseDto
                {
                    indicador = "IA_NO_DISPONIBLE",
                    detalle = "La IA no está disponible en este momento. Intente nuevamente."
                };
            }

            var root = JsonNode.Parse(resultJson);

            var text = root?["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("Respuesta vacía de Gemini");

            text = text.Replace("```json", "")
                       .Replace("```", "")
                       .Trim();

            var start = text.IndexOf("{");
            var end = text.LastIndexOf("}");

            if (start >= 0 && end > start)
                text = text.Substring(start, end - start + 1);

            var result = JsonSerializer.Deserialize<EvaluacionIAResponseDto>(text);

            if (result == null)
                throw new InvalidOperationException($"IA devolvió JSON inválido. Respuesta: {text}");

            return result;
        }
    }
}