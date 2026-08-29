namespace LogicaAplicacion.Dtos.Equipo
{
    public record EquipoOcularDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        decimal diametroMM,
        decimal anguloVisionGrados
    );
}