using Dominio.ValueObjects.VOShared;
using Dominio.ValueObjects.VOUsuario;

namespace Dominio.Entidades
{
    public class Socio : Usuario
    {
        public override string Rol => "Socio";

        public Socio()
        {
        }

        public Socio(
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