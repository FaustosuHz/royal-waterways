using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.UsuarioException
{
    internal class ContraseniaInvalidException : LogicaNegocioException
    {
        public ContraseniaInvalidException()
        {
        }

        public ContraseniaInvalidException(string? message) : base(message)
        {
        }

    }
}