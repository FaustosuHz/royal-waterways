using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Observacion;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.ObservacionCU
{
    public class GetAllObservaciones : ICUGetAll<ObservacionDto>
    {
        private IRepositorioObservacion _repo;

        public GetAllObservaciones(IRepositorioObservacion repo)
        {
            _repo = repo;
        }

        public IEnumerable<ObservacionDto> Execute()
        {
            return _repo.GetAll()
                .Select(o => ObservacionMapper.ToDto(o));
        }
    }
}