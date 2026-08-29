using System.Text.RegularExpressions;
using Dominio.Excepciones.UsuarioException;

namespace Dominio.ValueObjects.VOUsuario
{
    public record VOContrasenia
    {
        public string Value { get; private set; }

        public VOContrasenia(string value)
        {
            Validar(value);
            Value = value.Trim();
        }

        private void Validar(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ContraseniaInvalidException("La contraseña no puede estar vacía");

            string valorLimpio = value.Trim();

            if (valorLimpio.Length < 8)
                throw new ContraseniaInvalidException("Debe tener al menos 8 caracteres");

            if (!Regex.IsMatch(valorLimpio, @"[A-Z]"))
                throw new ContraseniaInvalidException("Debe tener al menos una mayúscula");

            if (!Regex.IsMatch(valorLimpio, @"[a-z]"))
                throw new ContraseniaInvalidException("Debe tener al menos una minúscula");

            if (!Regex.IsMatch(valorLimpio, @"[0-9]"))
                throw new ContraseniaInvalidException("Debe tener al menos un número");

            if (!Regex.IsMatch(valorLimpio, @"[^a-zA-Z0-9]"))
                throw new ContraseniaInvalidException("Debe tener al menos un carácter especial");
        }
    }
}