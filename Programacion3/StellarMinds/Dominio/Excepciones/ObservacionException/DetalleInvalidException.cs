using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.ObservacionException
{
    internal class DetalleInvalidException : LogicaNegocioException
    {
        public DetalleInvalidException()
        {
        }

        public DetalleInvalidException(string? message) : base(message)
        {
        }
    }
}