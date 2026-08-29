using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class AnguloVisionInvalidException : LogicaNegocioException
    {
        public AnguloVisionInvalidException()
        {
        }

        public AnguloVisionInvalidException(string? message) : base(message)
        {
        }

    }
}