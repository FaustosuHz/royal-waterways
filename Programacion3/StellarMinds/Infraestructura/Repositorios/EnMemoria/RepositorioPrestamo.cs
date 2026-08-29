using Dominio.Entidades;

namespace Infraestructura.Repositorios.EnMemoria
{
    public class RepositorioPrestamo
    {
        private static List<Prestamo> _prestamos { get; set; } = new List<Prestamo>();

        public void Add(Prestamo prestamo)
        {
            _prestamos.Add(prestamo);
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return _prestamos;
        }

        public IEnumerable<Prestamo> GetById(int id)
        {
            return _prestamos;
        }


    }
}
