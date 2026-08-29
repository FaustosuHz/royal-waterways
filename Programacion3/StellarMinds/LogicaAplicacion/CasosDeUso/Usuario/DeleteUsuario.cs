using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.Usuario
{
    public class DeleteUsuario : ICUDelete
    {
        private readonly IRepositorioUsuario _usuarios;

        public DeleteUsuario(IRepositorioUsuario repo)
        {
            _usuarios = repo;
        }

        public void Execute(int id)
        {
            _usuarios.Delete(id);
        }
    }
}