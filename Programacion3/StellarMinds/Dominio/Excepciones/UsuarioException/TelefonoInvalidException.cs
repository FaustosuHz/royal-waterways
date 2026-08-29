using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.UsuarioException
{
    internal class TelefonoInvalidException : LogicaNegocioException
    {
        public TelefonoInvalidException()
        {
        }

        public TelefonoInvalidException(string? message) : base(message)
        {
        }
    }
}