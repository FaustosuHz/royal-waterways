using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Usuario;
using UsuarioEntidad = Dominio.Entidades.Usuario;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class Login : ICULogin<UsuarioLoginDto, UsuarioLogueadoDto>
    {
        private IRepositorioUsuario _usuarios;

        public Login(IRepositorioUsuario repo)
        {
            _usuarios = repo;
        }

        public UsuarioLogueadoDto Execute(UsuarioLoginDto usuarioLoginDto)
        {
            if (usuarioLoginDto == null)
            {
                throw new ArgumentException("El usuario no puede ser nulo");
            }

            UsuarioEntidad usuario = _usuarios.Login(
                UsuarioMapper.FromLoginDto(usuarioLoginDto)
            );

            return UsuarioMapper.ToUsuarioLogueadoDto(usuario);
        }
    }
}