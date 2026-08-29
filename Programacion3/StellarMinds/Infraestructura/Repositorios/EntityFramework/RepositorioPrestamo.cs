using Dominio.Entidades;
using Dominio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios.EntityFramework
{
    public class RepositorioPrestamo : IRepositorioPrestamo
    {
        private StellarMindsContext _context;

        public RepositorioPrestamo(StellarMindsContext context)
        {
            _context = context;
        }

        public int Add(Prestamo prestamo)
        {
            if (prestamo == null)
            {
                throw new ArgumentException("No se recibió el préstamo");
            }

            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();

            return prestamo.Id;
        }

        public Prestamo GetById(int id)
        {
            Prestamo prestamo = _context.Prestamos
                .Include(p => p.Usuario)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .FirstOrDefault(p => p.Id == id);

            if (prestamo == null)
            {
                throw new InvalidOperationException($"No se encontro el prestamo {id}");
            }

            return prestamo;
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return _context.Prestamos
                .Include(p => p.Usuario)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .ToList();
        }

        public IEnumerable<Prestamo> GetPrestamosPorUsuario(int usuarioId)
        {
            return _context.Prestamos
                .Include(p => p.Usuario)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .Where(p => p.Usuario.Id == usuarioId)
                .ToList();
        }

        public void Delete(int id)
        {
            Prestamo prestamo = GetById(id);

            _context.Prestamos.Remove(prestamo);
            _context.SaveChanges();
        }

        public void Edit(int id, Prestamo prestamo)
        {
            Prestamo prestamoEditado = GetById(id);

            prestamoEditado.Update(
                prestamo.Usuario,
                prestamo.Telescopio,
                prestamo.Montura,
                prestamo.Camara,
                prestamo.Ocular,
                prestamo.FechaInicio,
                prestamo.FechaFin
            );

            _context.SaveChanges();
        }

        public IEnumerable<Prestamo> GetPrestamosActivosPorUsuario(int usuarioId)
        {
            return _context.Prestamos
                .Include(p => p.Usuario)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .Where(p =>
                    p.Usuario.Id == usuarioId &&
                    p.Estado == EstadoPrestamo.EnPrestamo)
                .ToList();
        }

        public void DevolverPrestamo(int prestamoId)
        {
            Prestamo prestamo = GetById(prestamoId);

            prestamo.Devolver();

            prestamo.Telescopio.AumentarCantidad();
            prestamo.Montura.AumentarCantidad();

            if (prestamo.Camara != null)
                prestamo.Camara.AumentarCantidad();

            if (prestamo.Ocular != null)
                prestamo.Ocular.AumentarCantidad();

            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetSociosPorTelescopio(int telescopioId)
        {
            return _context.Prestamos
               .Include(p => p.Usuario)
               .Where(p => p.Telescopio.Id == telescopioId)
               .Select(p => p.Usuario)
               .Distinct()
               .AsEnumerable()
               .OrderByDescending(u => u.Nombre.ToString())
               .ToList();
        }

        public bool ExistePrestamoActivoPorEquipo(int equipoId)
        {
            return _context.Prestamos.Any(p =>
                p.Estado == EstadoPrestamo.EnPrestamo &&
                (
                    (p.Telescopio != null && p.Telescopio.Id == equipoId) ||
                    (p.Montura != null && p.Montura.Id == equipoId) ||
                    (p.Camara != null && p.Camara.Id == equipoId) ||
                    (p.Ocular != null && p.Ocular.Id == equipoId)
                )
            );
        }
    }
}