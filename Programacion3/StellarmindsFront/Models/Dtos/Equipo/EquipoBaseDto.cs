namespace WebApp.Models.Dtos.Equipo
{
    public record EquipoBaseDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        string tipoEquipo
    );
}