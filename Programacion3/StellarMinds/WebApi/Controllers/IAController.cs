using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.Dtos.Observacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/ia")]
    public class IAController : ControllerBase
    {
        private readonly ICUEvaluacionConIA<EvaluarObservacionDto, EvaluacionIAResponseDto> _cu;

        public IAController(
            ICUEvaluacionConIA<EvaluarObservacionDto, EvaluacionIAResponseDto> cu)
        {
            _cu = cu;
        }

        [HttpPost("evaluar-observacion")]
        public IActionResult Evaluar([FromBody] EvaluarObservacionDto dto)
        {
            if (dto == null)
                return BadRequest(new
                {
                    mensaje = "Datos inválidos"
                });

            try
            {
                var result = _cu.Execute(dto);

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new
                {
                    mensaje = e.Message
                });
            }
            catch (InvalidOperationException e)
            {
                return NotFound(new
                {
                    mensaje = e.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    mensaje = "Ocurrió un error interno."
                });
            }
        }
    }
}