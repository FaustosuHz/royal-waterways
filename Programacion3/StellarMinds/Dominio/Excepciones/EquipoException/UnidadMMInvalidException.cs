using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class UnidadMMInvalidException : LogicaNegocioException
    {
        public UnidadMMInvalidException()
        {
        }

        public UnidadMMInvalidException(string? message) : base(message)
        {
        }

    }
}