using Dominio.Excepciones.EquipoException;
using System.Text.RegularExpressions;

namespace Dominio.ValueObjects.VOEquipo
{
    public record VORelacionFocal
    {
        public string Value { get; }

        private VORelacionFocal() { }

        public VORelacionFocal(string value)
        {
            Value = value?.Trim();
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new RelacionFocalInvalidException("La relación focal no puede estar vacía.");

            string patron = @"^f\/\d+(\.\d+)?$";

            if (!Regex.IsMatch(Value.ToLower(), patron))
                throw new RelacionFocalInvalidException("Formato inválido. Ej: f/10, f/5, f/11.5.");

            string numeroStr = Value.ToLower().Replace("f/", "");

            if (!decimal.TryParse(numeroStr, out decimal valor) || valor <= 0)
                throw new RelacionFocalInvalidException("La relación focal debe ser un número mayor a 0.");
        }
    }
}