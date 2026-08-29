namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUDevolverPrestamo
    {
        void Execute(int prestamoId, int coordinadorId);
    }
}