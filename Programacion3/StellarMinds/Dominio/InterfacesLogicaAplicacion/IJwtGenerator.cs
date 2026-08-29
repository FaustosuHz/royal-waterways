namespace Dominio.InterfacesLogicaAplicacion
{
    public interface IJwtGenerator<T>
    {
        string GenerateToken(T Usuario);
    }
}
