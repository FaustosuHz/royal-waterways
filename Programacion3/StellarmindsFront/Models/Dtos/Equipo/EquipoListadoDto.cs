namespace WebApp.Models.Dtos.Equipo
{
    public class EquipoListadoDto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisponible { get; set; }
        public string TipoEquipo { get; set; }

        // Cámara
        public string? TipoSensor { get; set; }
        public string? Resolucion { get; set; }
        public decimal? TamanioPixelMicras { get; set; }

        // Montura
        public string? TipoMontura { get; set; }
        public decimal? CargaUtilKg { get; set; }
        public bool? EsGoTo { get; set; }

        // Ocular
        public decimal? DiametroMM { get; set; }
        public decimal? AnguloVisionGrados { get; set; }

        // Telescopio
        public decimal? AperturaMM { get; set; }
        public string? RelacionFocal { get; set; }
        public decimal? DistanciaFocalMM { get; set; }
        public decimal? PesoKg { get; set; }
    }
}