using Dominio.Entidades;
using Infraestructura.Repositorios.EnMemoria;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioAuditoriaPrestamo :
        IRepositorioAdd<AuditoriaPrestamo>,
        IRepositorioGetById<AuditoriaPrestamo>,
        IRepositorioGetAll<AuditoriaPrestamo>
    {
    }
}
