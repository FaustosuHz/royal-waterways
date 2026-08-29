using Dominio.Entidades;
using Infraestructura.Repositorios.EnMemoria;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioObjetoCeleste :
        IRepositorioAdd<ObjetoCeleste>,
        IRepositorioEdit<ObjetoCeleste>,
        IRepositorioDelete<ObjetoCeleste>,
        IRepositorioGetById<ObjetoCeleste>,
        IRepositorioGetAll<ObjetoCeleste>
    {
    }
}
