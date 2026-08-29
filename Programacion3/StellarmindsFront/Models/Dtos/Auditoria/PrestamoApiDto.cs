using WebApp.Models.Dtos.Equipo;
using WebApp.Models.Dtos.Usuario;

namespace WebApp.Models.Dtos.Prestamo
{
    public class PrestamoApiDto
    {
        public int Id { get; set; }
        public UsuarioApiDto Usuario { get; set; }
        public EquipoApiDto Telescopio { get; set; }
        public EquipoApiDto Montura { get; set; }
        public EquipoApiDto? Camara { get; set; }
        public EquipoApiDto? Ocular { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
    }
}