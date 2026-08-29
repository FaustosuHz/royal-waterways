using Dominio.Entidades;
using Dominio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios.EntityFramework
{
    public class RepositorioObservacion : IRepositorioObservacion
    {
        private StellarMindsContext _context;

        public RepositorioObservacion(StellarMindsContext context)
        {
            _context = context;
        }

        public int Add(Observacion observacion)
        {
            if (observacion == null)
                throw new ArgumentException("No se recibió la observación");

            _context.Observaciones.Add(observacion);
            _context.SaveChanges();

            return observacion.Id;
        }

        public Observacion GetById(int id)
        {
            Observacion observacion = _context.Observaciones
                .Include(o => o.Usuario)
                .Include(o => o.Prestamo)
                    .ThenInclude(p => p.Telescopio)
                .Include(o => o.Prestamo)
                    .ThenInclude(p => p.Montura)
                .Include(o => o.Prestamo)
                    .ThenInclude(p => p.Camara)
                .Include(o => o.Prestamo)
                    .ThenInclude(p => p.Ocular)
                .Include(o => o.ObjetoCeleste)
                .FirstOrDefault(o => o.Id == id);

            if (observacion == null)
                throw new InvalidOperationException($"No se encontró la observación {id}");

            return observacion;
        }

        public IEnumerable<(string Nombre, string Tipo, int Cantidad)> GetRanking()
        {
            return _context.Observaciones
                .AsNoTracking()
                .Include(o => o.ObjetoCeleste)
                .AsEnumerable()
                .GroupBy(o => new
                {
                    Nombre = o.ObjetoCeleste.Nombre.ToString(),
                    Tipo = o.ObjetoCeleste.Tipo.ToString()
                })
                .Select(g => (
                    g.Key.Nombre,
                    g.Key.Tipo,
                    g.Count()
                ))
                .OrderByDescending(x => x.Item3)
                .ToList();
        }

        public IEnumerable<Observacion> GetAll()
        {
            return _context.Observaciones
                .Include(o => o.Usuario)
                .Include(o => o.Prestamo)
                    .ThenInclude(p => p.Telescopio)
                .Include(o => o.Prestamo)
                    .ThenInclude(p => p.Montura)
                .Include(o => o.Prestamo)
                    .ThenInclude(p => p.Camara)
                .Include(o => o.Prestamo)
                    .ThenInclude(p => p.Ocular)
                .Include(o => o.ObjetoCeleste)
                .ToList();
        }
    }
}