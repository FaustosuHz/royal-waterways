namespace Dominio.Entidades
{
    public class AuditoriaPrestamo
    {
        public int Id { get; private set; }

        public Prestamo Prestamo { get; private set; }

        public Usuario Coordinador { get; private set; }

        public DateTime Fecha { get; private set; }

        public TipoAccionAuditoria Accion { get; private set; }

        public AuditoriaPrestamo() { }

        public AuditoriaPrestamo(
            Prestamo prestamo,
            Usuario coordinador,
            TipoAccionAuditoria accion
        )
        {
            Prestamo = prestamo;

            Coordinador = coordinador;

            Accion = accion;

            Fecha = DateTime.Now;
        }
    }
}