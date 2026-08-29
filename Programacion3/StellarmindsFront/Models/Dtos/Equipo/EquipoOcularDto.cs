namespace WebApp.Models.Dtos.Equipo
{
    public record EquipoOcularDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        string tipoEquipo,
        decimal diametroMM,
        decimal anguloVisionGrados
    );
}