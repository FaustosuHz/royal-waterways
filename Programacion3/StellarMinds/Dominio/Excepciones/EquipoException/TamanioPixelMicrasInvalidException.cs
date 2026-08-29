using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.EquipoException
{
    internal class TamanioPixelMicrasInvalidException : LogicaNegocioException
    {
        public TamanioPixelMicrasInvalidException()
        {
        }

        public TamanioPixelMicrasInvalidException(string? message) : base(message)
        {
        }

    }
}