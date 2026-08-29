using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class UnidadKgInvalidException : LogicaNegocioException
    {
        public UnidadKgInvalidException()
        {
        }

        public UnidadKgInvalidException(string? message) : base(message)
        {
        }

    }
}