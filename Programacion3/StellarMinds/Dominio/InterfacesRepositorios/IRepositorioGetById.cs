namespace Infraestructura.Repositorios.EnMemoria
{
    public interface IRepositorioGetById<T>
    {
        T GetById(int id);
    }
}
