using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.CasosUso.Observaciones;
using LogicaAplicacion.Dtos.Observacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ObservacionesController : ControllerBase
    {
        private ICUGetAll<ObservacionDto> _getAll;
        private ICUAdd<ObservacionAltaDto> _add;
        private GetRankingObjetosCelestes _getRanking;

        public ObservacionesController(
            ICUGetAll<ObservacionDto> getAll,
            ICUAdd<ObservacionAltaDto> add,
            GetRankingObjetosCelestes getRanking)
        {
            _getAll = getAll;
            _add = add;
            _getRanking = getRanking;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_getAll.Execute());
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    mensaje = "Ocurrió un error interno."
                });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ObservacionAltaDto dto)
        {
            try
            {
                _add.Execute(dto);

                return Ok(new
                {
                    mensaje = "Observación creada correctamente"
                });
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

        [HttpGet("ranking")]
        public IActionResult GetRanking()
        {
            try
            {
                return Ok(_getRanking.Execute().Select(x => new
                {
                    nombre = x.Nombre,
                    tipo = x.Tipo,
                    cantidad = x.Cantidad
                }));
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