using Dominio.Excepciones.EquipoException;

namespace Dominio.ValueObjects.VOEquipo
{
    public record VOUnidadMM
    {
        public decimal Value { get; }

        public VOUnidadMM()
        { }

        public VOUnidadMM(decimal value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value <= 0)
                throw new UnidadMMInvalidException("El valor en milímetros debe ser mayor a 0.");
        }
    }
}