namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUGetByUsuario<T>
    {
        IEnumerable<T> Execute(int usuarioId);
    }
}