using Dominio.Entidades;

namespace Infraestructura.Repositorios.EnMemoria
{
    public class RepositorioObservacion
    {
        private static List<Observacion> _observaciones { get; set; } = new List<Observacion>();

        public void Add(Observacion observacion)
        {
            _observaciones.Add(observacion);
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<Observacion> GetAll()
        {
            return _observaciones;
        }

        public IEnumerable<Observacion> GetById(int id)
        {
            return _observaciones;
        }


    }
}
