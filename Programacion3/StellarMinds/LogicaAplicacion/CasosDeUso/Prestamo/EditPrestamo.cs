using Dominio.Entidades;
using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Prestamo;

namespace LogicaAplicacion.CasosUso.Prestamos
{
    public class EditPrestamo : ICUEdit<PrestamoEditDto>
    {
        private IRepositorioPrestamo _repoPrestamo;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioEquipo _repoEquipo;

        public EditPrestamo(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioUsuario repoUsuario,
            IRepositorioEquipo repoEquipo)
        {
            _repoPrestamo = repoPrestamo;
            _repoUsuario = repoUsuario;
            _repoEquipo = repoEquipo;
        }

        public void Execute(int id, PrestamoEditDto dto)
        {
            Usuario usuario = _repoUsuario.GetById(dto.usuarioId);

            Equipo equipoTelescopio = _repoEquipo.GetById(dto.telescopioId);
            if (equipoTelescopio.GetType().Name != nameof(EquipoTelescopio))
                throw new ArgumentException("El equipo indicado no es un telescopio");

            Equipo equipoMontura = _repoEquipo.GetById(dto.monturaId);
            if (equipoMontura.GetType().Name != nameof(EquipoMontura))
                throw new ArgumentException("El equipo indicado no es una montura");

            EquipoCamara? camara = null;
            if (dto.camaraId != null)
            {
                Equipo equipoCamara = _repoEquipo.GetById(dto.camaraId.Value);

                if (equipoCamara.GetType().Name != nameof(EquipoCamara))
                    throw new ArgumentException("El equipo indicado no es una cámara");

                camara = (EquipoCamara)equipoCamara;
            }

            EquipoOcular? ocular = null;
            if (dto.ocularId != null)
            {
                Equipo equipoOcular = _repoEquipo.GetById(dto.ocularId.Value);

                if (equipoOcular.GetType().Name != nameof(EquipoOcular))
                    throw new ArgumentException("El equipo indicado no es un ocular");

                ocular = (EquipoOcular)equipoOcular;
            }

            Prestamo prestamo = new Prestamo(
                usuario,
                (EquipoTelescopio)equipoTelescopio,
                (EquipoMontura)equipoMontura,
                camara,
                ocular,
                dto.fechaInicio,
                dto.fechaFin
            );

            _repoPrestamo.Edit(id, prestamo);
        }
    }
}