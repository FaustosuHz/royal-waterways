namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUGetById<T>
    {
        T Execute(int id);
    }
}
