using Dominio.Excepciones.SharedException;

namespace Dominio.Excepciones.ObjetoCeleste
{
    public class MagnitudAparenteInvalidException : LogicaNegocioException
    {
        public MagnitudAparenteInvalidException()
            : base("La magnitud aparente es inválida.")
        {
        }

        public MagnitudAparenteInvalidException(string message)
            : base(message)
        {
        }
    }
}