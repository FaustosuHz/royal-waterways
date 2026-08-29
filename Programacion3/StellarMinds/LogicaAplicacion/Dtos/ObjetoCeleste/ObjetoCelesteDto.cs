namespace LogicaAplicacion.Dtos.ObjetoCeleste
{
    public record ObjetoCelesteDto(
        int id,
        string nombre,
        int tipo,
        decimal magnitudAparente
    );
}