using Dominio.Entidades;
using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.Prestamos
{
    public class GetPrestamoById : ICUGetById<PrestamoDto>
    {
        private IRepositorioPrestamo _repoPrestamo;

        public GetPrestamoById(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public PrestamoDto Execute(int id)
        {
            Prestamo prestamo = _repoPrestamo.GetById(id);

            return PrestamoMapper.ToDto(prestamo);
        }
    }
}