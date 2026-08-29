using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Equipo;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosDeUso.Equipo
{
    public class EditEquipo : ICUEdit<EquipoAltaDto>
    {
        private readonly IRepositorioEquipo _equipos;
        private readonly IRepositorioPrestamo _prestamos;

        public EditEquipo(
            IRepositorioEquipo repo,
            IRepositorioPrestamo repoPrestamo)
        {
            _equipos = repo;
            _prestamos = repoPrestamo;
        }

        public void Execute(int id, EquipoAltaDto dto)
        {
            if (dto == null)
                throw new ArgumentException("Datos inválidos");

            if (_prestamos.ExistePrestamoActivoPorEquipo(id))
                throw new InvalidOperationException("No se puede editar un equipo con préstamos activos");

            var equipo = _equipos.GetById(id);

            var nuevo = EquipoMapper.FromDto(dto);

            equipo.Update(nuevo);

            _equipos.Edit(id, equipo);
        }
    }
}