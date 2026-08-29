using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso.ObjetoCelesteCU
{
    public class DeleteObjetoCeleste
        : ICUDelete
    {
        private IRepositorioObjetoCeleste _repo;

        public DeleteObjetoCeleste(
            IRepositorioObjetoCeleste repo)
        {
            _repo = repo;
        }

        public void Execute(int id)
        {
            _repo.Delete(id);
        }
    }
}