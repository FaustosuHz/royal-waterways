using Dominio.Excepciones.UsuarioException;
namespace Dominio.ValueObjects.VOUsuario
{
    public record VOEmail
    {
        public string Value { get; private set; }

        public VOEmail(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value == null || Value.Length < 5 || !Value.Contains("@"))
            {
                throw new EmailInvalidException("El email debe tener al menos 5 caracteres y contener '@'");
            }
        }

    }
}
