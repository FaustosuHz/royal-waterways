using Dominio.ValueObjects.VOShared;
using Dominio.ValueObjects.VOUsuario;

namespace Dominio.Entidades
{
    public class Administrador : Usuario
    {
        public override string Rol => "Administrador";

        public Administrador()
        {
        }

        public Administrador(
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