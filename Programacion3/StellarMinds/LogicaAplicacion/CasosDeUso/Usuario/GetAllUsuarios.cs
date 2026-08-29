using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Usuario;

namespace LogicaAplicacion.CasosDeUso.Usuario
{
    public class GetAllUsuarios : ICUGetAll<UsuarioListadoDto>
    {
        private IRepositorioUsuario _usuarios;

        public GetAllUsuarios(IRepositorioUsuario repo)
        {
            _usuarios = repo;
        }

        public IEnumerable<UsuarioListadoDto> Execute()
        {
            return _usuarios
                .GetAll()
                .Select(u => UsuarioMapper.ToUsuarioListadoDto(u));
        }
    }
}