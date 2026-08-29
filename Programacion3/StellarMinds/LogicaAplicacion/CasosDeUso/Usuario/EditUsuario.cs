using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.Usuario
{
    public class EditUsuario : ICUEdit<UsuarioEditarDto>
    {
        private IRepositorioUsuario _usuarios;

        public EditUsuario(IRepositorioUsuario repo)
        {
            _usuarios = repo;
        }

        public void Execute(int id, UsuarioEditarDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                throw new ArgumentException("El usuario no puede ser nulo");
            }

            _usuarios.Edit(
                id,
                UsuarioMapper.FromEditarDto(usuarioDto)
            );
        }
    }
}