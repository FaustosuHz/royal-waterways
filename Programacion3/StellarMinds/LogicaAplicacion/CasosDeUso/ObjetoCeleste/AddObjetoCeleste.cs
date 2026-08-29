using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.ObjetoCeleste;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.ObjetoCelesteCU
{
    public class AddObjetoCeleste
        : ICUAdd<ObjetoCelesteDto>
    {
        private readonly IRepositorioObjetoCeleste _repo;

        public AddObjetoCeleste(
            IRepositorioObjetoCeleste repo
        )
        {
            _repo = repo;
        }

        public void Execute(ObjetoCelesteDto dto)
        {
            var objetoCeleste =
                ObjetoCelesteMapper.FromDto(dto);

            _repo.Add(objetoCeleste);
        }
    }
}