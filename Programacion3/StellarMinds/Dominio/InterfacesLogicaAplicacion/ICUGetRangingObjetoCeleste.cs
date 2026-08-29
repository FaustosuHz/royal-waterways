namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUGetRanking<T>
    {
        IEnumerable<T> Execute();
    }
}