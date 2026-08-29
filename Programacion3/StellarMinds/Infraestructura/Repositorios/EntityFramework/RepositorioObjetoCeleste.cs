using Dominio.Entidades;
using Dominio.InterfacesRepositorios;

namespace Infraestructura.Repositorios.EntityFramework
{
    public class RepositorioObjetoCeleste : IRepositorioObjetoCeleste
    {
        private StellarMindsContext _context;

        public RepositorioObjetoCeleste(StellarMindsContext context)
        {
            _context = context;
        }

        public int Add(ObjetoCeleste objetoCeleste)
        {
            if (objetoCeleste == null)
            {
                throw new ArgumentException(
                    "No se recibió el objeto celeste"
                );
            }

            _context.ObjetosCelestes.Add(objetoCeleste);

            _context.SaveChanges();

            return objetoCeleste.Id;
        }

        public IEnumerable<ObjetoCeleste> GetAll()
        {
            return _context.ObjetosCelestes.ToList();
        }

        public ObjetoCeleste GetById(int id)
        {
            ObjetoCeleste objetoCeleste =
                _context.ObjetosCelestes
                    .FirstOrDefault(objeto => objeto.Id == id);

            if (objetoCeleste == null)
            {
                throw new InvalidOperationException($"No se encontró el objeto celeste {id}");
            }

            return objetoCeleste;
        }

        public void Delete(int id)
        {
            ObjetoCeleste objetoCeleste = GetById(id);

            _context.ObjetosCelestes.Remove(objetoCeleste);

            _context.SaveChanges();
        }

        public void Edit(int id, ObjetoCeleste objetoCelesteActualizado)
        {
            ObjetoCeleste objetoCelesteExistente = GetById(id);

            objetoCelesteExistente.Update(objetoCelesteActualizado);

            _context.ObjetosCelestes.Update(objetoCelesteExistente);

            _context.SaveChanges();
        }
    }
}