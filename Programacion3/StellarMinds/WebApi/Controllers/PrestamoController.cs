using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Dtos.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PrestamosController : ControllerBase
    {
        private ICUAddPrestamo<PrestamoAltaDto> _add;
        private ICUGetAll<PrestamoDto> _getAll;
        private ICUGetById<PrestamoDto> _getById;
        private ICUGetByUsuario<PrestamoDetalleDto> _getByUsuario;
        private ICUGetAllByUsuario<PrestamoDetalleDto> _getAllByUsuario;
        private ICUEdit<PrestamoEditDto> _edit;
        private ICUDeletePrestamo _delete;
        private ICUDevolverPrestamo _devolverPrestamo;
        private ICUGetSociosPorTelescopio<UsuarioListadoDto> _getSociosPorTelescopio;

        public PrestamosController(
            ICUAddPrestamo<PrestamoAltaDto> add,
            ICUGetAll<PrestamoDto> getAll,
            ICUGetById<PrestamoDto> getById,
            ICUGetByUsuario<PrestamoDetalleDto> getByUsuario,
            ICUGetAllByUsuario<PrestamoDetalleDto> getAllByUsuario,
            ICUEdit<PrestamoEditDto> edit,
            ICUDeletePrestamo delete,
            ICUDevolverPrestamo devolverPrestamo,
            ICUGetSociosPorTelescopio<UsuarioListadoDto> getSociosPorTelescopio
            )
        {
            _add = add;
            _getAll = getAll;
            _getById = getById;
            _getByUsuario = getByUsuario;
            _getAllByUsuario = getAllByUsuario;
            _edit = edit;
            _delete = delete;
            _devolverPrestamo = devolverPrestamo;
            _getSociosPorTelescopio = getSociosPorTelescopio;
        }

        [HttpPost]
        public IActionResult Create(PrestamoAltaDto prestamo)
        {
            try
            {
                int coordinadorId = int.Parse(User.FindFirst("id")!.Value);

                _add.Execute(prestamo, coordinadorId);

                return Ok(new
                {
                    mensaje = "Préstamo creado correctamente"
                });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { mensaje = e.Message });
            }
            catch (InvalidOperationException e)
            {
                return NotFound(new { mensaje = e.Message });
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

        [HttpGet("usuario/{usuarioId}")]
        public IActionResult GetByUsuario(int usuarioId)
        {
            try
            {
                return Ok(_getByUsuario.Execute(usuarioId));
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

        [HttpGet("usuario/{usuarioId}/todos")]
        public IActionResult GetAllByUsuario(int usuarioId)
        {
            try
            {
                return Ok(_getAllByUsuario.Execute(usuarioId));
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

        [HttpPut("{id}")]
        public IActionResult Edit(int id, PrestamoEditDto prestamo)
        {
            try
            {
                _edit.Execute(id, prestamo);

                return Ok(new
                {
                    mensaje = "Préstamo editado correctamente"
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

        [HttpPut("{id}/devolver")]
        public IActionResult Devolver(int id)
        {
            try
            {
                int coordinadorId = int.Parse(User.FindFirst("id")!.Value);

                _devolverPrestamo.Execute(id, coordinadorId);

                return Ok(new
                {
                    mensaje = "Préstamo devuelto correctamente"
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _delete.Execute(id);

                return Ok(new
                {
                    mensaje = "Préstamo eliminado correctamente"
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

        [HttpGet("telescopio/{telescopioId}/socios")]
        public IActionResult GetSociosPorTelescopio(int telescopioId)
        {
            try
            {
                return Ok(_getSociosPorTelescopio.Execute(telescopioId));
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