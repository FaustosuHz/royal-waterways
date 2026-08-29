using Dominio.Entidades;

namespace Infraestructura.Repositorios.EnMemoria
{
    public class RepositorioAuditoriaPrestamo
    {
        private static List<AuditoriaPrestamo> _auditorias { get; set; } = new List<AuditoriaPrestamo>();

        public void Add(AuditoriaPrestamo auditoria)
        {
            _auditorias.Add(auditoria);
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<AuditoriaPrestamo> GetAll()
        {
            return _auditorias;
        }

        public IEnumerable<AuditoriaPrestamo> GetById(int id)
        {
            return _auditorias;
        }


    }
}
