using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.UsuarioException
{
    internal class NombreUsuarioInvalidException : LogicaNegocioException
    {
        public NombreUsuarioInvalidException()
        {
        }

        public NombreUsuarioInvalidException(string? message) : base(message)
        {
        }

    }
}