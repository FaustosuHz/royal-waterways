using Dominio.Entidades;

namespace Infraestructura.Repositorios.EnMemoria
{
    public class RepositorioEquipo
    {
        private static List<Equipo> _equipos { get; set; } = new List<Equipo>();

        public void Add(Equipo equipo)
        {
            _equipos.Add(equipo);
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _equipos;
        }

        public IEnumerable<Equipo> GetById(int id)
        {
            return _equipos;
        }


    }
}
