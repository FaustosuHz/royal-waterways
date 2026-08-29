using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.UsuarioException
{
    internal class ApellidoInvalidException : LogicaNegocioException
    {
        public ApellidoInvalidException()
        {
        }

        public ApellidoInvalidException(string? message) : base(message)
        {
        }
    }
}