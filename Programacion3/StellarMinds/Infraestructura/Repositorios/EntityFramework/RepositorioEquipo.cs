using Dominio.Entidades;
using Dominio.InterfacesRepositorios;

namespace Infraestructura.Repositorios.EntityFramework
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private StellarMindsContext _context;

        public RepositorioEquipo(StellarMindsContext context)
        {
            _context = context;
        }

        public int Add(Equipo equipo)
        {
            if (equipo == null)
            {
                throw new ArgumentException("No se recibio el equipo");
            }

            _context.Equipos.Add(equipo);
            _context.SaveChanges();

            return equipo.Id;
        }

        public Equipo GetById(int id)
        {
            Equipo equipo = _context.Equipos.FirstOrDefault(e => e.Id == id);

            if (equipo == null)
            {
                throw new InvalidOperationException($"No se encontró el equipo {id}");
            }

            return equipo;
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _context.Equipos.ToList();
        }

        public void Delete(int id)
        {
            Equipo equipo = GetById(id);

            _context.Equipos.Remove(equipo);
            _context.SaveChanges();
        }

        public void Edit(int id, Equipo equipo)
        {
            Equipo existente = GetById(id);

            _context.Entry(existente).CurrentValues.SetValues(equipo);

            _context.SaveChanges();
        }
    }
}