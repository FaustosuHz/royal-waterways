using LogicaAplicacion.Dtos.Equipo;
using LogicaAplicacion.Dtos.Usuario;

namespace LogicaAplicacion.Dtos.Prestamo
{
    public record PrestamoDetalleDto(
        int id,
        UsuarioListadoDto usuario,
        EquipoListadoDto telescopio,
        EquipoListadoDto montura,
        EquipoListadoDto? camara,
        EquipoListadoDto? ocular,
        DateTime fechaInicio,
        DateTime fechaFin,
        string estado
    );
}