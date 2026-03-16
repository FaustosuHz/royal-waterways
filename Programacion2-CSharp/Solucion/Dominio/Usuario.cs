namespace Dominio
{
    public class Usuario : IValidar
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public Equipo Equipo { get; set; }
        public DateTime FechaDeIncorporacion { get; set; }
        public Rol Rol { get; set; }
        public bool Activo { get; set; }

        public Usuario() 
        {
                Id = UltimoId++;
                Activo = true;
        }

        public Usuario(string nombre, string apellido, string contrasenia, Equipo equipo, Rol rolUsuario, DateTime fechaDeIncorporacion)
        {
            Id = UltimoId++;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
            Equipo = equipo;
            Rol = rolUsuario;
            FechaDeIncorporacion = fechaDeIncorporacion;
            Activo = true;
        }

       public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarContrasenia();
            ValidarEquipo();
            ValidarFechaDeIncorporacion();
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacío.");
            }
        }

        public void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("El apellido no puede estar vacío");
            }
        }

        public void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(Contrasenia))
            {
                throw new Exception("La contraseña no puede estar vacía");
            }

            if (Contrasenia.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            }
        }

        private void ValidarEquipo()
        {
            if (Equipo == null) { throw new Exception("El Usuario debe pertenecer a un Equipo"); }
        }

        private void ValidarFechaDeIncorporacion()
        {
            if (FechaDeIncorporacion == DateTime.MinValue)
            {
                throw new Exception("Debe indicar una fecha de incorporación válida");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Usuario u)
            {
                return Email == u.Email;
            }
            else
            {
                return false;
            }
        }

   }
}
