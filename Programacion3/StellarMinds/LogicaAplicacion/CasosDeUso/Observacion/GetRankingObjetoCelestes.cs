using Dominio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso.Observaciones
{
    public class GetRankingObjetosCelestes
    {
        private readonly IRepositorioObservacion _repo;

        public GetRankingObjetosCelestes(IRepositorioObservacion repo)
        {
            _repo = repo;
        }

        public IEnumerable<(string Nombre, string Tipo, int Cantidad)> Execute()
        {
            return _repo.GetRanking();
        }
    }
}