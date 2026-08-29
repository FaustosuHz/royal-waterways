using WebApp.Models.Dtos.Prestamo;
using WebApp.Models.Dtos.Usuario;

namespace WebApp.Models.Dtos.Auditoria
{
    public class AuditoriaPrestamoApiDto
    {
        public int Id { get; set; }
        public PrestamoApiDto Prestamo { get; set; }
        public UsuarioApiDto Coordinador { get; set; }
        public int Accion { get; set; }
    }
}