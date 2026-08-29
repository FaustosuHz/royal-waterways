using Dominio.Entidades;
using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.Prestamos
{
    public class GetPrestamoByUsuario : ICUGetByUsuario<PrestamoDetalleDto>
    {
        private IRepositorioPrestamo _repoPrestamo;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioEquipo _repoEquipo;

        public GetPrestamoByUsuario(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioUsuario repoUsuario,
            IRepositorioEquipo repoEquipo)
        {
            _repoPrestamo = repoPrestamo;
            _repoUsuario = repoUsuario;
            _repoEquipo = repoEquipo;
        }

        public IEnumerable<PrestamoDetalleDto> Execute(int usuarioId)
        {
            var prestamos = _repoPrestamo.GetPrestamosActivosPorUsuario(usuarioId);

            return prestamos.Select(prestamo =>
            {
                var usuario = _repoUsuario.GetById(prestamo.Usuario.Id);

                var telescopio = _repoEquipo.GetById(prestamo.Telescopio.Id);
                var montura = _repoEquipo.GetById(prestamo.Montura.Id);

                Equipo camara = null;
                Equipo ocular = null;

                if (prestamo.Camara != null)
                    camara = _repoEquipo.GetById(prestamo.Camara.Id);

                if (prestamo.Ocular != null)
                    ocular = _repoEquipo.GetById(prestamo.Ocular.Id);

                return PrestamoMapper.DetalleToDto(
                    prestamo,
                    UsuarioMapper.ToUsuarioListadoDto(usuario),
                    EquipoMapper.ToListadoDto(telescopio),
                    EquipoMapper.ToListadoDto(montura),
                    camara != null ? EquipoMapper.ToListadoDto(camara) : null,
                    ocular != null ? EquipoMapper.ToListadoDto(ocular) : null
                );
            }).ToList();
        }
    }
}