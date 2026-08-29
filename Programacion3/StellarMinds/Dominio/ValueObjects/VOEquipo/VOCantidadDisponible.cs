using Dominio.Excepciones.EquipoException;

namespace Dominio.ValueObjects.VOEquipo
{
    public record VOCantidadDisponible
    {
        public int Value { get; }

        private VOCantidadDisponible() { }

        public VOCantidadDisponible(int value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value < 0)
                throw new CantidadDisponibleInvalidException("La cantidad disponible no puede ser negativa.");
        }
    }
}