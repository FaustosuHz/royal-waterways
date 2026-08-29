using System.Text.RegularExpressions;
using Dominio.Excepciones.UsuarioException;

namespace Dominio.ValueObjects.VOUsuario
{
    public record VOTelefono
    {
        public string Value { get; private set; }

        public VOTelefono(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new TelefonoInvalidException("El teléfono no puede estar vacío");

            string valorLimpio = Value.Trim();

            string patron = @"^[0-9]+$";

            if (!Regex.IsMatch(valorLimpio, patron))
                throw new TelefonoInvalidException("El teléfono solo puede contener números");

            if (valorLimpio.Length < 7 || valorLimpio.Length > 15)
                throw new TelefonoInvalidException("El teléfono debe tener entre 7 y 15 dígitos");
        }
    }
}