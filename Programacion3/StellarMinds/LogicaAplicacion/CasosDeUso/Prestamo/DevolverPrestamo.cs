using Dominio.Entidades;
using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso.Prestamos
{
    public class DevolverPrestamo : ICUDevolverPrestamo
    {
        private IRepositorioPrestamo _repoPrestamo;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoriaPrestamo _repoAuditoria;

        public DevolverPrestamo(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioUsuario repoUsuario,
            IRepositorioAuditoriaPrestamo repoAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void Execute(int prestamoId, int coordinadorId)
        {
            Prestamo prestamo = _repoPrestamo.GetById(prestamoId);

            Usuario coordinador = _repoUsuario.GetById(coordinadorId);

            _repoPrestamo.DevolverPrestamo(prestamoId);

            AuditoriaPrestamo auditoria = new AuditoriaPrestamo(
                prestamo,
                coordinador,
                TipoAccionAuditoria.Devolucion
            );

            _repoAuditoria.Add(auditoria);
        }
    }
}