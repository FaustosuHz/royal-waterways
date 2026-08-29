using Dominio.Excepciones.EquipoException;

namespace Dominio.ValueObjects.VOEquipo
{
    public record VOMarca
    {
        public string Value { get; }

        private VOMarca() { }

        public VOMarca(string value)
        {
            Value = value?.Trim();
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new MarcaInvalidException("La marca no puede estar vacía.");

            if (Value.Length < 2)
                throw new MarcaInvalidException("La marca debe tener al menos 2 caracteres.");
        }
    }
}