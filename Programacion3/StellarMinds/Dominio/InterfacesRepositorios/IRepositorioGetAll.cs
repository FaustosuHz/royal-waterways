namespace Infraestructura.Repositorios.EnMemoria
{
    public interface IRepositorioGetAll<T>
    {
        IEnumerable<T> GetAll();
    }
}