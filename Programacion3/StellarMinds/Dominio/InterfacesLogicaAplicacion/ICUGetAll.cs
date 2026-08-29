namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUGetAll<T>
    {
        IEnumerable<T> Execute();
    }
}
