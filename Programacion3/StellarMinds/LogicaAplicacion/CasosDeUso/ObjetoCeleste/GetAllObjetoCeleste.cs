using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.ObjetoCeleste;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.ObjetoCelesteCU
{
    public class GetAllObjetosCelestes
        : ICUGetAll<ObjetoCelesteDto>
    {
        private IRepositorioObjetoCeleste _repo;

        public GetAllObjetosCelestes(
            IRepositorioObjetoCeleste repo)
        {
            _repo = repo;
        }

        public IEnumerable<ObjetoCelesteDto> Execute()
        {
            return _repo
                .GetAll()
                .Select(o => ObjetoCelesteMapper.ToDto(o));
        }
    }
}