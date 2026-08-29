using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class ResolucionInvalidException : LogicaNegocioException
    {
        public ResolucionInvalidException()
        {
        }

        public ResolucionInvalidException(string? message) : base(message)
        {
        }

    }
}