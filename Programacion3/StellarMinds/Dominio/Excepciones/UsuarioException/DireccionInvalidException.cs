using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.UsuarioException
{
    internal class DireccionInvalidException : LogicaNegocioException
    {
        public DireccionInvalidException()
        {
        }

        public DireccionInvalidException(string? message) : base(message)
        {
        }

    }
}