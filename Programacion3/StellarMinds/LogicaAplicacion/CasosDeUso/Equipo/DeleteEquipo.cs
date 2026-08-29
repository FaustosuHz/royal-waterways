using Dominio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.Equipo
{
    public class DeleteEquipo : ICUDeleteEquipo
    {
        private IRepositorioEquipo _equipos;
        private IRepositorioPrestamo _prestamos;

        public DeleteEquipo(
            IRepositorioEquipo repo,
            IRepositorioPrestamo repoPrestamo)
        {
            _equipos = repo;
            _prestamos = repoPrestamo;
        }

        public void Execute(int id)
        {
            if (_prestamos.ExistePrestamoActivoPorEquipo(id))
                throw new InvalidOperationException("No se puede eliminar un equipo con préstamos activos");

            _equipos.Delete(id);
        }
    }
}