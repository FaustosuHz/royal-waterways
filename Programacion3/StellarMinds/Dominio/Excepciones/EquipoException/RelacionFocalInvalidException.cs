using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class RelacionFocalInvalidException : LogicaNegocioException
    {
        public RelacionFocalInvalidException()
        {
        }

        public RelacionFocalInvalidException(string? message) : base(message)
        {
        }

    }
}