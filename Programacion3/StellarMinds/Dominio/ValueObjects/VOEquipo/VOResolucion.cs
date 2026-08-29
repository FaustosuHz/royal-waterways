using Dominio.Excepciones.EquipoException;
using System.Text.RegularExpressions;

namespace Dominio.ValueObjects.VOEquipo
{
    public record VOResolucion
    {
        public string Value { get; }

        private VOResolucion() { }

        public VOResolucion(string value)
        {
            Value = value?.Trim();
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ResolucionInvalidException("La resolución no puede estar vacía.");

            string patron = @"^\d+x\d+$";

            if (!Regex.IsMatch(Value, patron))
                throw new ResolucionInvalidException("La resolución debe tener formato AxB (ej: 1920x1080).");

            var partes = Value.Split('x');
            int ancho = int.Parse(partes[0]);
            int alto = int.Parse(partes[1]);

            if (ancho <= 0 || alto <= 0)
                throw new ResolucionInvalidException("La resolución debe tener valores mayores a 0.");
        }
    }
}