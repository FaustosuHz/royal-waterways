using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.Dtos.ObjetoCeleste;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ObjetosCelestesController : ControllerBase
    {
        private ICUAdd<ObjetoCelesteDto> _add;
        private ICUGetAll<ObjetoCelesteDto> _getAll;
        private ICUGetById<ObjetoCelesteDto> _getById;
        private ICUDelete _delete;

        public ObjetosCelestesController(
            ICUAdd<ObjetoCelesteDto> add,
            ICUGetAll<ObjetoCelesteDto> getAll,
            ICUGetById<ObjetoCelesteDto> getById,
            ICUDelete delete)
        {
            _add = add;
            _getAll = getAll;
            _getById = getById;
            _delete = delete;
        }

        [HttpPost]
        public IActionResult Create(ObjetoCelesteDto objetoCeleste)
        {
            try
            {
                _add.Execute(objetoCeleste);

                return Ok(new
                {
                    mensaje = "Objeto celeste creado correctamente"
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_getById.Execute(id));
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _delete.Execute(id);

                return Ok(new
                {
                    mensaje = "Objeto celeste eliminado correctamente"
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