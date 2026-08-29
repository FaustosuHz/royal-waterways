namespace WebApp.Models.Dtos.Prestamo
{
    public class PrestamoDto
    {
        public int id { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string estado { get; set; }
    }
}