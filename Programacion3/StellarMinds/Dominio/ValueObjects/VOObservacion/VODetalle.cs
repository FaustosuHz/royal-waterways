using Dominio.Excepciones.ObservacionException;
namespace Dominio.ValueObjects.VOObservacion
{
    public record VODetalle
    {
        public string Value { get; }

        public VODetalle(string value)
        {
            Value = value?.Trim();
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new DetalleInvalidException("El detalle no puede estar vacío.");

            if (Value.Length > 300)
                throw new DetalleInvalidException("El detalle no puede superar los 300 caracteres.");
        }
    }
}