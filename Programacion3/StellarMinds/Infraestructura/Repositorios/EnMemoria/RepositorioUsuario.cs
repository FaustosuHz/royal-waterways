using Dominio.Entidades;
using Dominio.InterfacesRepositorios;

namespace Infraestructura.Repositorios.EnMemoria
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static List<Usuario> _usuarios { get; set; } = new List<Usuario>();

        public int Add(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("No se recibio el usuario");
            }
            if (_usuarios.Contains(usuario))
            {
                throw new Exception("Ya existe el usuario");
            }
            _usuarios.Add(usuario);
            return usuario.Id;
        }

        public void Delete(int id)
        {
            Usuario usuario = GetById(id);

            _usuarios.Remove(usuario);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarios;
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
