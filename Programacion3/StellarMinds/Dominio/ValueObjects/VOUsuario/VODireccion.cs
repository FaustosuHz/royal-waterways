using Dominio.Excepciones.UsuarioException;

namespace Dominio.ValueObjects.VOUsuario
{
    public record VODireccion
    {
        public string Value { get; private set; }

        public VODireccion(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value == null || Value.Length < 3)
            {
                throw new DireccionInvalidException("Direccion invalida");
            }
        }
    }
}