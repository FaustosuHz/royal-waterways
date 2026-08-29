using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.AuditoriaPrestamo;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Dtos.Usuario;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.AuditoriaPrestamoCU
{
    public class GetAllAuditoriaPrestamo
        : ICUGetAll<AuditoriaPrestamoMostrarDto>
    {
        private readonly IRepositorioAuditoriaPrestamo _repoAuditoria;

        public GetAllAuditoriaPrestamo(IRepositorioAuditoriaPrestamo repoAuditoria)
        {
            _repoAuditoria = repoAuditoria;
        }

        public IEnumerable<AuditoriaPrestamoMostrarDto> Execute()
        {
            var auditorias = _repoAuditoria.GetAll();

            return auditorias.Select(a =>
            {
                if (a?.Prestamo == null)
                    throw new Exception($"Auditoría {a.Id} sin préstamo");

                if (a.Prestamo.Usuario == null)
                    throw new Exception($"Préstamo {a.Prestamo.Id} sin usuario");

                var prestamo = a.Prestamo;
                var usuario = prestamo.Usuario;

                var usuarioDto = new UsuarioListadoDto(
                    usuario.Id,
                    usuario.Nombre?.Value ?? "",
                    usuario.Apellido?.Value ?? "",
                    usuario.Email?.Value ?? "",
                    usuario.NombreUsuario?.Value ?? "",
                    usuario.GetType().Name
                );

                var prestamoDto = new PrestamoDetalleDto(
                    prestamo.Id,
                    usuarioDto,
                    EquipoMapper.ToListadoDto(prestamo.Telescopio),
                    EquipoMapper.ToListadoDto(prestamo.Montura),
                    prestamo.Camara != null ? EquipoMapper.ToListadoDto(prestamo.Camara) : null,
                    prestamo.Ocular != null ? EquipoMapper.ToListadoDto(prestamo.Ocular) : null,
                    prestamo.FechaInicio,
                    prestamo.FechaFin,
                    prestamo.Estado.ToString()
                );

                return new AuditoriaPrestamoMostrarDto(
                    a.Id,
                    prestamoDto,
                    usuarioDto,
                    (int)a.Accion
                );
            });
        }
    }
}