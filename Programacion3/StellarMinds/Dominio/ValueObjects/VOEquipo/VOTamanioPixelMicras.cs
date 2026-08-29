using Dominio.Excepciones.EquipoException;

namespace Dominio.ValueObjects.VOEquipo
{
    public record VOTamanioPixelMicras
    {
        public decimal Value { get; }

        private VOTamanioPixelMicras() { }

        public VOTamanioPixelMicras(decimal value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value <= 0)
                throw new TamanioPixelMicrasInvalidException("El tamaño de píxel en micras debe ser mayor a 0.");
        }
    }
}