namespace LogicaAplicacion.Dtos.Equipo
{
    public record EquipoTelescopioDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        decimal aperturaMM,
        string relacionFocal,
        decimal distanciaFocalMM,
        decimal pesoKg
    );
}