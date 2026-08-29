using Dominio.Excepciones.EquipoException;

namespace Dominio.ValueObjects.VOEquipo
{
    public record VOModelo
    {
        public string Value { get; }

        private VOModelo() { }

        public VOModelo(string value)
        {
            Value = value?.Trim();
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ModeloInvalidException("El modelo no puede estar vacío.");

            if (Value.Length < 2)
                throw new ModeloInvalidException("El modelo debe tener al menos 2 caracteres.");
        }
    }
}