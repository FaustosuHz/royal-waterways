using Dominio.Excepciones.UsuarioException;

namespace Dominio.ValueObjects.VOUsuario
{
    public record VONombreUsuario
    {
        public string Value { get; private set; }

        public VONombreUsuario(string value)
        {
            Validar(value);
            Value = value.Trim();
        }

        private void Validar(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new NombreUsuarioInvalidException("El nombre de usuario no puede estar vacío");

            string valorLimpio = value.Trim();

            if (valorLimpio.Length < 3)
                throw new NombreUsuarioInvalidException("El nombre de usuario debe tener al menos 3 caracteres");

            if (valorLimpio.Length > 20)
                throw new NombreUsuarioInvalidException("El nombre de usuario no puede superar los 20 caracteres");
        }
    }
}