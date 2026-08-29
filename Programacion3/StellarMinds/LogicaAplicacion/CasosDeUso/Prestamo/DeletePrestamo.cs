using Dominio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso.Prestamos
{
    public class DeletePrestamo : ICUDeletePrestamo
    {
        private IRepositorioPrestamo _repoPrestamo;

        public DeletePrestamo(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public void Execute(int id)
        {
            _repoPrestamo.Delete(id);
        }
    }
}