using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.AuditoriaPrestamo;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Dtos.Usuario;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.AuditoriaPrestamoCU
{
    public class GetAuditoriaPrestamoById
        : ICUGetById<AuditoriaPrestamoMostrarDto>
    {
        private readonly IRepositorioAuditoriaPrestamo _repoAuditoria;
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioEquipo _repoEquipo;

        public GetAuditoriaPrestamoById(
            IRepositorioAuditoriaPrestamo repoAuditoria,
            IRepositorioPrestamo repoPrestamo,
            IRepositorioUsuario repoUsuario,
            IRepositorioEquipo repoEquipo)
        {
            _repoAuditoria = repoAuditoria;
            _repoPrestamo = repoPrestamo;
            _repoUsuario = repoUsuario;
            _repoEquipo = repoEquipo;
        }

        public AuditoriaPrestamoMostrarDto Execute(int id)
        {
            var auditoria = _repoAuditoria.GetById(id)
                ?? throw new Exception("Auditoría no encontrada");

            var prestamo = _repoPrestamo.GetById(auditoria.Prestamo.Id)
                ?? throw new Exception("Préstamo no encontrado");

            var usuario = _repoUsuario.GetById(prestamo.Usuario.Id)
                ?? throw new Exception("Usuario no encontrado");

            var usuarioDto = new UsuarioListadoDto(
                usuario.Id,
                usuario.Nombre.Value,
                usuario.Apellido.Value,
                usuario.Email.Value,
                usuario.NombreUsuario.Value,
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

            return AuditoriaPrestamoMapper.ToMostrarDto(
                auditoria,
                prestamoDto,
                usuarioDto
            );
        }
    }
}