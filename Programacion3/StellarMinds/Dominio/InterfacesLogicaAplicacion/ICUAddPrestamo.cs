namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUAddPrestamo<T>
    {
        void Execute(T dto, int coordinadorId);
    }
}