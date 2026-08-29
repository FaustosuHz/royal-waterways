using Dominio.Excepciones.EquipoException;

namespace Dominio.ValueObjects.VOEquipo
{
    public record VOUnidadKg
    {
        public decimal Value { get; }

        public VOUnidadKg() { }

        public VOUnidadKg(decimal value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value <= 0)
                throw new UnidadKgInvalidException("El peso en kg debe ser mayor a 0.");
        }
    }
}