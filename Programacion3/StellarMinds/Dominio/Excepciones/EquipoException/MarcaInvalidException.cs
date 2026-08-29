using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class MarcaInvalidException : LogicaNegocioException
    {
        public MarcaInvalidException()
        {
        }

        public MarcaInvalidException(string? message) : base(message)
        {
        }

    }
}