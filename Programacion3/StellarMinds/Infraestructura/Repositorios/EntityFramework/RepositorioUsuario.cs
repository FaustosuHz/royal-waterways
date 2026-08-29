using Dominio.Entidades;
using Dominio.InterfacesRepositorios;

namespace Infraestructura.Repositorios.EntityFramework
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private StellarMindsContext _context;

        public RepositorioUsuario(StellarMindsContext context)
        {
            _context = context;
        }

        public int Add(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("No se recibio el usuario");
            }

            if (_context.Usuarios.Any(u =>
                u.Email.Value == usuario.Email.Value ||
                u.NombreUsuario.Value == usuario.NombreUsuario.Value))
            {
                throw new ArgumentException("Ya existe un usuario registrado con ese email o nombre de usuario");
            }

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario.Id;
        }

        public Usuario GetById(int id)
        {
            Usuario unUsuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (unUsuario == null)
            {
                throw new InvalidOperationException($"No se encontro al Usuario {id}");
            }

            return unUsuario;
        }

        public IEnumerable<Usuario> GetAll()
        {
            IEnumerable<Usuario> aux = _context.Usuarios.ToList();

            return aux;
        }

        public void Delete(int id)
        {
            Usuario unUsuario = GetById(id);

            _context.Usuarios.Remove(unUsuario);
            _context.SaveChanges();
        }

        public void Edit(int id, Usuario usuario)
        {
            Usuario unUsuario = GetById(id);

            unUsuario.Update(usuario);

            _context.Usuarios.Update(unUsuario);
            _context.SaveChanges();
        }

        public Usuario Login(Usuario usuarioLogin)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(u =>
                u.NombreUsuario.Value == usuarioLogin.NombreUsuario.Value &&
                u.Contrasenia.Value == usuarioLogin.Contrasenia.Value);

            if (usuario == null)
            {
                throw new InvalidOperationException("Credenciales incorrectas");
            }

            return usuario;
        }
    }
}