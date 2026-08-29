namespace LogicaAplicacion.Dtos.Prestamo
{
    public record PrestamoDto(
     int id,
     int usuarioId,
     int telescopioId,
     int monturaId,
     int? camaraId,
     int? ocularId,
     DateTime fechaInicio,
     DateTime fechaFin
 );
}