using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class ModeloInvalidException : LogicaNegocioException
    {
        public ModeloInvalidException()
        {
        }

        public ModeloInvalidException(string? message) : base(message)
        {
        }

    }
}