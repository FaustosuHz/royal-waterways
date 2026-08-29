namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICULogin<T, TResult>
    {
        TResult Execute(T obj);
    }
}