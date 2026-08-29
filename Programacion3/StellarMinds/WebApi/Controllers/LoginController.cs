using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.Dtos.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ICUGetById<UsuarioListadoDto> _getById;
        IJwtGenerator<UsuarioListadoDto> _jwtGenerator;
        ICULogin<UsuarioLoginDto, UsuarioLogueadoDto> _login;

        public LoginController(
            ICUGetById<UsuarioListadoDto> getById,
            IJwtGenerator<UsuarioListadoDto> jwtGenerator,
            ICULogin<UsuarioLoginDto, UsuarioLogueadoDto> login)
        {
            _getById = getById;
            _jwtGenerator = jwtGenerator;
            _login = login;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UsuarioLoginDto loginDto)
        {
            try
            {
                UsuarioLogueadoDto usuarioLogueado = _login.Execute(loginDto);

                UsuarioListadoDto user = _getById.Execute(usuarioLogueado.id);

                var token = _jwtGenerator.GenerateToken(user);

                return Ok(new { token });
            }
            catch (ArgumentException)
            {
                return Unauthorized(new
                {
                    mensaje = "Usuario o contraseña incorrectos"
                });
            }
            catch (InvalidOperationException)
            {
                return Unauthorized(new
                {
                    mensaje = "Usuario o contraseña incorrectos"
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensaje = "Error interno del servidor"
                });
            }
        }
    }
}