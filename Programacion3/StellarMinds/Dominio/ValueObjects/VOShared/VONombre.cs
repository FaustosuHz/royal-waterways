using Dominio.Excepciones.SharedException;
using System.Text.RegularExpressions;

namespace Dominio.ValueObjects.VOShared
{
    public record VONombre
    {
        public string Value { get; }

        public VONombre()
        {
        }

        public VONombre(string value)
        {
            Value = value?.Trim();
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value) || Value.Length < 3)
                throw new NombreInvalidException("El nombre debe tener al menos 3 caracteres.");

            string patron = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ0-9 ]+$";

            if (!Regex.IsMatch(Value, patron))
                throw new NombreInvalidException("El nombre contiene caracteres inválidos.");
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(VONombre vo)
        {
            return vo.Value;
        }
    }
}