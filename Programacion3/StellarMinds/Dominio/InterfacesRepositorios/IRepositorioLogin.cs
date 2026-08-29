using Dominio.Entidades;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioLogin<T>
    {
        Usuario Login(T obj);
    }
}
