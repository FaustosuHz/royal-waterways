namespace StellarmindsFront.Models.Dtos.Prestamo
{
    public class PrestamoAltaDto
    {
        public int usuarioId { get; set; }

        public int telescopioId { get; set; }

        public int monturaId { get; set; }

        public int? camaraId { get; set; }

        public int? ocularId { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }
    }
}