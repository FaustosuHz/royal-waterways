using Dominio.ValueObjects.VOShared;
using Dominio.ValueObjects.VOUsuario;

namespace Dominio.Entidades
{
    public abstract class Usuario
    {
        public int Id { get; set; }

        public VONombre Nombre { get; set; }
        public VOApellido Apellido { get; set; }
        public VODireccion Direccion { get; set; }
        public VOTelefono Telefono { get; set; }
        public VOEmail Email { get; set; }
        public VONombreUsuario NombreUsuario { get; set; }
        public VOContrasenia Contrasenia { get; set; }

        public bool Activo { get; set; }

        public abstract string Rol { get; }

        protected Usuario()
        {

        }

        protected Usuario(
            VONombre nombre,
            VOApellido apellido,
            VODireccion direccion,
            VOTelefono telefono,
            VOEmail email,
            VONombreUsuario nombreUsuario,
            VOContrasenia contrasenia
        )
        {
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;

            Activo = true;

        }

        public void Update(Usuario obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Datos inválidos");
            }

            Nombre = obj.Nombre;
            Apellido = obj.Apellido;
            Direccion = obj.Direccion;
            Telefono = obj.Telefono;
            Email = obj.Email;
            NombreUsuario = obj.NombreUsuario;
            Activo = obj.Activo;
        }
    }
}