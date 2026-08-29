namespace Dominio.Excepciones.SharedException
{
    public class NombreInvalidException : LogicaNegocioException
    {
        public NombreInvalidException() { }

        public NombreInvalidException(string? message) : base(message)
        {
        }
    }
}
