namespace WebApp.Models.Dtos.Equipo
{
    public record EquipoMonturaDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        string tipoEquipo,
        string tipoMontura,
        decimal cargaUtilKg,
        bool esGoTo
    );
}