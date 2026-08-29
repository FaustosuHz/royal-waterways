using Dominio.Entidades;
using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.Prestamos
{
    public class AddPrestamo : ICUAddPrestamo<PrestamoAltaDto>
    {
        private IRepositorioPrestamo _repoPrestamo;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioEquipo _repoEquipo;
        private IRepositorioAuditoriaPrestamo _repoAuditoria;

        public AddPrestamo(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioUsuario repoUsuario,
            IRepositorioEquipo repoEquipo,
            IRepositorioAuditoriaPrestamo repoAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoUsuario = repoUsuario;
            _repoEquipo = repoEquipo;
            _repoAuditoria = repoAuditoria;
        }

        public void Execute(PrestamoAltaDto dto, int coordinadorId)
        {
            if (dto.fechaInicio == default || dto.fechaFin == default)
                throw new ArgumentException("Las fechas son obligatorias");

            if (dto.fechaFin < dto.fechaInicio)
                throw new ArgumentException("La fecha fin no puede ser menor a la fecha inicio");

            if (dto.fechaInicio.Date < DateTime.Now.Date)
                throw new ArgumentException("La fecha inicio no puede estar en el pasado");

            if (dto.camaraId != null && dto.ocularId != null)
                throw new ArgumentException("No se puede seleccionar cámara y ocular al mismo tiempo");

            Usuario usuario = _repoUsuario.GetById(dto.usuarioId);

            Equipo equipoTelescopio = _repoEquipo.GetById(dto.telescopioId);

            if (equipoTelescopio.GetType().Name != nameof(EquipoTelescopio))
                throw new ArgumentException("El equipo indicado no es un telescopio");

            if (equipoTelescopio.CantidadDisponible.Value <= 0)
                throw new ArgumentException("El telescopio no tiene disponibilidad");

            Equipo equipoMontura = _repoEquipo.GetById(dto.monturaId);

            if (equipoMontura.GetType().Name != nameof(EquipoMontura))
                throw new ArgumentException("El equipo indicado no es una montura");

            if (equipoMontura.CantidadDisponible.Value <= 0)
                throw new ArgumentException("La montura no tiene disponibilidad");

            EquipoCamara? camara = null;

            if (dto.camaraId != null)
            {
                Equipo equipoCamara = _repoEquipo.GetById(dto.camaraId.Value);

                if (equipoCamara.GetType().Name != nameof(EquipoCamara))
                    throw new ArgumentException("El equipo indicado no es una cámara");

                if (equipoCamara.CantidadDisponible.Value <= 0)
                    throw new ArgumentException("La cámara no tiene disponibilidad");

                camara = (EquipoCamara)equipoCamara;
            }

            EquipoOcular? ocular = null;

            if (dto.ocularId != null)
            {
                Equipo equipoOcular = _repoEquipo.GetById(dto.ocularId.Value);

                if (equipoOcular.GetType().Name != nameof(EquipoOcular))
                    throw new ArgumentException("El equipo indicado no es un ocular");

                if (equipoOcular.CantidadDisponible.Value <= 0)
                    throw new ArgumentException("El ocular no tiene disponibilidad");

                ocular = (EquipoOcular)equipoOcular;
            }

            equipoTelescopio.DisminuirCantidad();
            equipoMontura.DisminuirCantidad();

            if (camara != null)
                camara.DisminuirCantidad();

            if (ocular != null)
                ocular.DisminuirCantidad();

            Prestamo prestamo = PrestamoMapper.FromDto(
                dto,
                usuario,
                (EquipoTelescopio)equipoTelescopio,
                (EquipoMontura)equipoMontura,
                camara,
                ocular
            );

            _repoPrestamo.Add(prestamo);

            Usuario coordinador = _repoUsuario.GetById(coordinadorId);

            AuditoriaPrestamo auditoria = new AuditoriaPrestamo(
                prestamo,
                coordinador,
                TipoAccionAuditoria.Prestamo
            );

            _repoAuditoria.Add(auditoria);
        }
    }
}