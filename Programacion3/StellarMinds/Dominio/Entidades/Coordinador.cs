using Dominio.ValueObjects.VOShared;
using Dominio.ValueObjects.VOUsuario;

namespace Dominio.Entidades
{
    public class Coordinador : Usuario
    {
        public override string Rol => "Coordinador";

        public Coordinador()
        {
        }

        public Coordinador(
            VONombre nombre,
            VOApellido apellido,
            VODireccion direccion,
            VOTelefono telefono,
            VOEmail email,
            VONombreUsuario nombreUsuario,
            VOContrasenia contrasenia
        ) : base(
            nombre,
            apellido,
            direccion,
            telefono,
            email,
            nombreUsuario,
            contrasenia)
        {
        }
    }
}