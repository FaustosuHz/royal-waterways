using Dominio.Entidades;
using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.Prestamos
{
    public class GetAllPrestamos : ICUGetAll<PrestamoDto>
    {
        private IRepositorioPrestamo _repoPrestamo;

        public GetAllPrestamos(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public IEnumerable<PrestamoDto> Execute()
        {
            IEnumerable<Prestamo> prestamos = _repoPrestamo.GetAll();

            return prestamos.Select(p => PrestamoMapper.ToDto(p));
        }
    }
}