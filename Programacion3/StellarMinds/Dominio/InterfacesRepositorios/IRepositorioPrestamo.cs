using Dominio.Entidades;
using Infraestructura.Repositorios.EnMemoria;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioPrestamo :
        IRepositorioAdd<Prestamo>,
        IRepositorioEdit<Prestamo>,
        IRepositorioDelete<Prestamo>,
        IRepositorioGetById<Prestamo>,
        IRepositorioGetAll<Prestamo>
    {
        bool ExistePrestamoActivoPorEquipo(int equipoId);

        IEnumerable<Prestamo> GetPrestamosActivosPorUsuario(int usuarioId);

        IEnumerable<Prestamo> GetPrestamosPorUsuario(int usuarioId);
        IEnumerable<Usuario> GetSociosPorTelescopio(int telescopioId);

        void DevolverPrestamo(int prestamoId);
    }
}