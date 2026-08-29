namespace StellarmindsFront.Models.Dtos.Usuario
{
    public record UsuarioAltaDto(
        string nombre,
        string apellido,
        string direccion,
        string telefono,
        string email,
        string nombreUsuario,
        string contrasenia,
        string Rol
    );
}