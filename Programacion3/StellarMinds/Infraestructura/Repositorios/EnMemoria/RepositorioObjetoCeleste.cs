using Dominio.Entidades;

namespace Infraestructura.Repositorios.EnMemoria
{
    public class RepositorioObjetoCeleste
    {
        private static List<ObjetoCeleste> _objetosCelestes { get; set; } = new List<ObjetoCeleste>();

        public void Add(ObjetoCeleste objetosCeleste)
        {
            _objetosCelestes.Add(objetosCeleste);
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<ObjetoCeleste> GetAll()
        {
            return _objetosCelestes;
        }

        public IEnumerable<ObjetoCeleste> GetById(int id)
        {
            return _objetosCelestes;
        }


    }
}
