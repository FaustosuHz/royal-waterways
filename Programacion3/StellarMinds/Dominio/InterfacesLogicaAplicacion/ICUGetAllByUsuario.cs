namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUGetAllByUsuario<T>
    {
        IEnumerable<T> Execute(int usuarioId);
    }
}