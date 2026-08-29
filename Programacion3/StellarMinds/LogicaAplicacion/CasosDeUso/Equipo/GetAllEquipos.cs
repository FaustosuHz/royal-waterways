using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Equipo;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.Equipos
{
    public class GetAllEquipos : ICUGetAll<EquipoListadoDto>
    {
        private readonly IRepositorioEquipo _equipos;

        public GetAllEquipos(IRepositorioEquipo repo)
        {
            _equipos = repo;
        }

        public IEnumerable<EquipoListadoDto> Execute()
        {
            return _equipos
                .GetAll()
                .Select(e => EquipoMapper.ToListadoDto(e));
        }
    }
}