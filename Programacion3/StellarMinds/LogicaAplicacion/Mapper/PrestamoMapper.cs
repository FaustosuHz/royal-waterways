using Dominio.Entidades;
using LogicaAplicacion.Dtos.Equipo;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Dtos.Usuario;

namespace LogicaAplicacion.Mapper
{
    public class PrestamoMapper
    {
        public static Prestamo FromDto(
            PrestamoAltaDto dto,
            Usuario usuario,
            EquipoTelescopio telescopio,
            EquipoMontura montura,
            EquipoCamara? camara,
            EquipoOcular? ocular
        )
        {
            return new Prestamo(
                usuario,
                telescopio,
                montura,
                camara,
                ocular,
                dto.fechaInicio,
                dto.fechaFin
            );
        }

        public static PrestamoDto ToDto(Prestamo prestamo)
        {
            return new PrestamoDto(
                prestamo.Id,
                prestamo.Usuario.Id,
                prestamo.Telescopio.Id,
                prestamo.Montura.Id,
                prestamo.Camara?.Id,
                prestamo.Ocular?.Id,
                prestamo.FechaInicio,
                prestamo.FechaFin
            );
        }

        public static PrestamoDetalleDto DetalleToDto(
            Prestamo prestamo,
            UsuarioListadoDto usuario,
            EquipoListadoDto telescopio,
            EquipoListadoDto montura,
            EquipoListadoDto? camara,
            EquipoListadoDto? ocular
        )
        {
            return new PrestamoDetalleDto(
                prestamo.Id,
                usuario,
                telescopio,
                montura,
                camara,
                ocular,
                prestamo.FechaInicio,
                prestamo.FechaFin,
                prestamo.Estado.ToString()
            );
        }
    }
}