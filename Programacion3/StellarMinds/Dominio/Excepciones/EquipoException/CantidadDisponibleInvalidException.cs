using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class CantidadDisponibleInvalidException : LogicaNegocioException
    {
        public CantidadDisponibleInvalidException()
        {
        }

        public CantidadDisponibleInvalidException(string? message) : base(message)
        {
        }

    }
}