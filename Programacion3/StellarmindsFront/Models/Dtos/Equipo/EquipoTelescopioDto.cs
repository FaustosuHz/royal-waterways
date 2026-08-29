namespace WebApp.Models.Dtos.Equipo
{
    public record EquipoTelescopioDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        string tipoEquipo,
        decimal aperturaMM,
        string relacionFocal,
        decimal distanciaFocalMM,
        decimal pesoKg
    );
}