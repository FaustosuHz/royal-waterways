namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUEdit<T>
    {
        void Execute(int id, T dto);
    }
}