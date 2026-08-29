using System.Text.RegularExpressions;
using Dominio.Excepciones.UsuarioException;

namespace Dominio.ValueObjects.VOUsuario
{
    public record VOApellido
    {
        public string Value { get; private set; }

        public VOApellido(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value) || Value.Trim().Length < 3)
                throw new ApellidoInvalidException("El apellido debe tener al menos 3 caracteres");

            string patron = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$";

            if (!Regex.IsMatch(Value, patron))
                throw new ApellidoInvalidException("El apellido contiene caracteres inválidos");
        }
    }
}