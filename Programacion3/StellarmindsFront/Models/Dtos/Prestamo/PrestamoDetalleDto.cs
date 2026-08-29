using StellarmindsFront.Models.Dtos.Usuario;
using WebApp.Models.Dtos.Equipo;

namespace StellarmindsFront.Models.Dtos.Prestamo
{
    public class PrestamoDetalleDto
    {
        public int Id { get; set; }
        public UsuarioListadoDto Usuario { get; set; }
        public EquipoListadoDto Telescopio { get; set; }
        public EquipoListadoDto Montura { get; set; }
        public EquipoListadoDto? Camara { get; set; }
        public EquipoListadoDto? Ocular { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public string Estado { get; set; }
    }
}