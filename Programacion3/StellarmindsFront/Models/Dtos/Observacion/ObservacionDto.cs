namespace StellarmindsFront.Models.Dtos.Observacion
{
    public class ObservacionDto
    {
        public int usuarioId { get; set; }
        public int prestamoId { get; set; }
        public int objetoCelesteId { get; set; }
        public DateTime fechaObservacion { get; set; }

        public string indicador { get; set; }
        public string detalle { get; set; }
    }
}