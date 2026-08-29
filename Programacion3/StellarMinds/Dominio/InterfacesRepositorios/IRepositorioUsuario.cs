using Dominio.Entidades;
using Infraestructura.Repositorios.EnMemoria;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioUsuario :
        IRepositorioAdd<Usuario>,
        IRepositorioEdit<Usuario>,
        IRepositorioDelete<Usuario>,
        IRepositorioGetById<Usuario>,
        IRepositorioLogin<Usuario>,
        IRepositorioGetAll<Usuario>
    {
    }
}
