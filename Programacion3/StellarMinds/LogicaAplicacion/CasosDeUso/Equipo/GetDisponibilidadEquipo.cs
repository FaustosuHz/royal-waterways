using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.Dtos.Equipo;

namespace LogicaAplicacion.CasosUso.Equipos
{
    public class GetDisponibilidadEquipo : ICUGetDisponibilidadEquipo
    {
        private ICUGetById<EquipoListadoDto> _getById;

        public GetDisponibilidadEquipo(ICUGetById<EquipoListadoDto> getById)
        {
            _getById = getById;
        }

        public bool Execute(int equipoId)
        {
            var equipo = _getById.Execute(equipoId);

            if (equipo == null)
                throw new Exception("Equipo no encontrado");

            return equipo.CantidadDisponible > 0;
        }
    }
}