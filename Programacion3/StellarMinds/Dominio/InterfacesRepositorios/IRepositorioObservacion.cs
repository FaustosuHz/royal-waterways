using Dominio.Entidades;
using Infraestructura.Repositorios.EnMemoria;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioObservacion :
        IRepositorioAdd<Observacion>,
        IRepositorioGetById<Observacion>,
        IRepositorioGetAll<Observacion>
    {
        IEnumerable<(string Nombre, string Tipo, int Cantidad)> GetRanking();
    }
}