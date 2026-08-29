namespace StellarmindsFront.Models.Dtos.Usuario
{
    public record UsuarioListadoDto(
        int Id,
        string nombre,
        string apellido,
        string email,
        string nombreUsuario,
        string rol
    );
}