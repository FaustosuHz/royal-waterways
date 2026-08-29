using Dominio.Entidades;
using LogicaAplicacion.Dtos.Observacion;

namespace LogicaAplicacion.Mapper
{
    public class ObservacionMapper
    {
        public static ObservacionDto ToDto(Observacion o)
        {
            return new ObservacionDto(
                o.Id,
                o.Usuario.Id,
                o.Prestamo.Id,
                o.ObjetoCeleste.Id,
                o.FechaObservacion,
                o.Resultado?.ToString(),
                o.Detalle?.Value
            );
        }

        public static Observacion FromDto(
            ObservacionAltaDto dto,
            Usuario usuario,
            Prestamo prestamo,
            ObjetoCeleste objetoCeleste)
        {
            var observacion = new Observacion(
                usuario,
                prestamo,
                dto.fechaObservacion,
                objetoCeleste
            );

            if (!string.IsNullOrWhiteSpace(dto.resultado))
            {
                observacion.RegistrarResultadoIA(
                    Enum.Parse<ResultadoObservacion>(dto.resultado),
                    dto.detalle ?? ""
                );
            }

            return observacion;
        }
    }
}