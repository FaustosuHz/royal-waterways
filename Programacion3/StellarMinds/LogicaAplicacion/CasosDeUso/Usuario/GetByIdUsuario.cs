using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Usuario;

namespace LogicaAplicacion.CasosDeUso.Usuario
{
    public class GetByIdUsuario : ICUGetById<UsuarioListadoDto>
    {
        private IRepositorioUsuario _usuarios;

        public GetByIdUsuario(IRepositorioUsuario repo)
        {
            _usuarios = repo;
        }

        public UsuarioListadoDto Execute(int id)
        {
            return UsuarioMapper.ToUsuarioListadoDto(
                _usuarios.GetById(id)
            );
        }
    }
}