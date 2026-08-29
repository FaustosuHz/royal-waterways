namespace WebApp.Models.Dtos.Usuario
{
    public class UsuarioApiDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
    }
}