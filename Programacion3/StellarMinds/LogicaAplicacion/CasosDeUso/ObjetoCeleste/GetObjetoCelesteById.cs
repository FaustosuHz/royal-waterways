using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.ObjetoCeleste;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.ObjetoCelesteCU
{
    public class GetObjetoCelesteById
        : ICUGetById<ObjetoCelesteDto>
    {
        private IRepositorioObjetoCeleste _repo;

        public GetObjetoCelesteById(
            IRepositorioObjetoCeleste repo)
        {
            _repo = repo;
        }

        public ObjetoCelesteDto Execute(int id)
        {
            return ObjetoCelesteMapper.ToDto(
                _repo.GetById(id)
            );
        }
    }
}