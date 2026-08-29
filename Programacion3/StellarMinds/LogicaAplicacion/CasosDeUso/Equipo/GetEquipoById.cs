using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Equipo;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosDeUso.Equipo
{
    public class GetEquipoById : ICUGetById<EquipoListadoDto>
    {
        private IRepositorioEquipo _equipos;

        public GetEquipoById(IRepositorioEquipo repo)
        {
            _equipos = repo;
        }

        public EquipoListadoDto Execute(int id)
        {
            return EquipoMapper.ToListadoDto(
                _equipos.GetById(id)
            );
        }
    }
}