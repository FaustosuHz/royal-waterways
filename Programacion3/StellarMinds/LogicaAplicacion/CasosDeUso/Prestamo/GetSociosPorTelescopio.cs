using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Usuario;

namespace LogicaAplicacion.CasosUso.Prestamos
{
    public class GetSociosPorTelescopio :
        ICUGetSociosPorTelescopio<UsuarioListadoDto>
    {
        private IRepositorioPrestamo _repoPrestamo;

        public GetSociosPorTelescopio(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public IEnumerable<UsuarioListadoDto> Execute(int telescopioId)
        {
            return _repoPrestamo
                .GetSociosPorTelescopio(telescopioId)
                .Select(UsuarioMapper.ToUsuarioListadoDto);
        }
    }
}