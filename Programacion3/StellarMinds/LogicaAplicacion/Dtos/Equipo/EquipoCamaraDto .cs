namespace LogicaAplicacion.Dtos.Equipo
{
    public record EquipoCamaraDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        string tipoSensor,
        string resolucion,
        decimal tamanioPixelMicras
    );
}