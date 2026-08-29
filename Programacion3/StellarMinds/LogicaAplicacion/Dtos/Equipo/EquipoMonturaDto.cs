namespace LogicaAplicacion.Dtos.Equipo
{
    public record EquipoMonturaDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        string tipoMontura,
        decimal cargaUtilKg,
        bool esGoTo
    );
}