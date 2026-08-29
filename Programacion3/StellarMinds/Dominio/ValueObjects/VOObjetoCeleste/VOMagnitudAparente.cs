using Dominio.Excepciones.ObjetoCeleste;

namespace Dominio.ValueObjects.VOObjetoCeleste
{
    public record VOMagnitudAparente
    {
        public decimal Value { get; }

        public VOMagnitudAparente(decimal value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            // verificar maximo 2 decimales
            decimal valorAbsoluto = Math.Abs(Value);
            decimal parteDecimal = valorAbsoluto - Math.Truncate(valorAbsoluto);

            if (Decimal.Round(parteDecimal, 2) != parteDecimal)
            {
                throw new MagnitudAparenteInvalidException("La magnitud aparente debe tener como máximo 2 decimales.");
            }
        }
    }
}