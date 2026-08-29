namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioEdit<T>
    {
        void Edit(int id, T obj);
    }
}
