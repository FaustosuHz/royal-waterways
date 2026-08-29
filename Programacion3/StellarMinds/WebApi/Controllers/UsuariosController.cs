using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.Dtos.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private ICUAdd<UsuarioAltaDto> _add;
        private ICUGetAll<UsuarioListadoDto> _getAll;
        private ICUGetById<UsuarioListadoDto> _getById;
        private ICUEdit<UsuarioEditarDto> _edit;
        private ICUDelete _delete;

        public UsuariosController(
            ICUAdd<UsuarioAltaDto> add,
            ICUGetAll<UsuarioListadoDto> getAll,
            ICUGetById<UsuarioListadoDto> getById,
            ICUEdit<UsuarioEditarDto> edit,
            ICUDelete delete)
        {
            _add = add;
            _getAll = getAll;
            _getById = getById;
            _edit = edit;
            _delete = delete;
        }

        [HttpPost]
        public IActionResult Create(UsuarioAltaDto usuario)
        {
            try
            {
                _add.Execute(new UsuarioAltaDto(
                    nombre: usuario.nombre,
                    apellido: usuario.apellido,
                    direccion: usuario.direccion,
                    telefono: usuario.telefono,
                    email: usuario.email,
                    nombreUsuario: usuario.nombreUsuario,
                    contrasenia: usuario.contrasenia,
                    Rol: usuario.Rol
                ));

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                if (ex.GetType().Name == "EmailInvalidException")
                {
                    return BadRequest("Email inválido");
                }

                if (ex.GetType().Name == "TelefonoInvalidException")
                {
                    return BadRequest("Teléfono inválido");
                }

                if (ex.GetType().Name == "DireccionInvalidException")
                {
                    return BadRequest("Dirección inválida");
                }

                if (ex.GetType().Name == "NombreUsuarioInvalidException")
                {
                    return BadRequest("Nombre de usuario inválido");
                }

                if (ex.GetType().Name == "ContraseniaInvalidException")
                {
                    return BadRequest("Contraseña inválida");
                }

                if (ex.GetType().Name == "ApellidoInvalidException")
                {
                    return BadRequest("Apellido inválido");
                }

                return BadRequest(ex.Message);
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

        [HttpPut("{id}")]
        public IActionResult Edit(int id, UsuarioEditarDto usuario)
        {
            try
            {
                _edit.Execute(id, usuario);

                return Ok(new
                {
                    mensaje = "Usuario editado correctamente"
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
                    mensaje = "Usuario eliminado correctamente"
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