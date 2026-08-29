using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.UsuarioException
{
    public class EmailInvalidException : LogicaNegocioException
    {
        public EmailInvalidException()
            : base("Email inválido")
        {
        }

        public EmailInvalidException(string? message)
            : base(message)
        {
        }
    }
}