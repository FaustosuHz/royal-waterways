using Dominio.Entidades;
using Dominio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios.EntityFramework
{
    public class RepositorioAuditoriaPrestamo : IRepositorioAuditoriaPrestamo
    {
        private StellarMindsContext _context;

        public RepositorioAuditoriaPrestamo(StellarMindsContext context)
        {
            _context = context;
        }

        public int Add(AuditoriaPrestamo auditoria)
        {
            _context.AuditoriasPrestamo.Add(auditoria);

            _context.SaveChanges();

            return auditoria.Id;
        }

        public IEnumerable<AuditoriaPrestamo> GetAll()
        {
            return _context.AuditoriasPrestamo
                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Usuario)

                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Telescopio)

                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Montura)

                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Camara)

                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Ocular)

                .Include(a => a.Coordinador)
                .ToList();
        }

        public AuditoriaPrestamo GetById(int id)
        {
            AuditoriaPrestamo auditoria =
                _context.AuditoriasPrestamo
                    .Include(a => a.Prestamo)
                    .Include(a => a.Coordinador)
                    .FirstOrDefault(a => a.Id == id);

            if (auditoria == null)
            {
                throw new InvalidOperationException(
                    "Auditoría no encontrada"
                );
            }

            return auditoria;
        }

    }
}