namespace WebApp.Models.Dtos.Equipo
{
    public record EquipoCamaraDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        string tipoEquipo,
        string tipoSensor,
        string resolucion,
        decimal tamanioPixelMicras
    );
}