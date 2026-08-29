using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Usuario;

namespace LogicaAplicacion.CasosDeUso.Usuario
{
    public class AddUsuario : ICUAdd<UsuarioAltaDto>
    {
        private IRepositorioUsuario _usuarios;

        public AddUsuario(IRepositorioUsuario repo)
        {
            _usuarios = repo;
        }

        public void Execute(UsuarioAltaDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                throw new ArgumentException("El usuario no puede ser nulo");
            }
            _usuarios.Add(UsuarioMapper.FromDto(usuarioDto));
        }

    }
}
