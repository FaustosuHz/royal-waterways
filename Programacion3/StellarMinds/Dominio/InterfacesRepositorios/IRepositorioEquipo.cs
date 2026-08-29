using Dominio.Entidades;
using Infraestructura.Repositorios.EnMemoria;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioEquipo :
        IRepositorioAdd<Equipo>,
        IRepositorioEdit<Equipo>,
        IRepositorioDelete<Equipo>,
        IRepositorioGetById<Equipo>,
        IRepositorioGetAll<Equipo>
    {
    }
}
