namespace Dominio.Entidades
{
    public class Prestamo
    {
        public int Id { get; private set; }

        public Usuario Usuario { get; private set; }
        public EquipoTelescopio Telescopio { get; private set; }
        public EquipoMontura Montura { get; private set; }
        public EquipoCamara? Camara { get; private set; }
        public EquipoOcular? Ocular { get; private set; }

        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }

        public EstadoPrestamo Estado { get; private set; }

        public Prestamo() { }

        public Prestamo(
            Usuario usuario,
            EquipoTelescopio telescopio,
            EquipoMontura montura,
            EquipoCamara? camara,
            EquipoOcular? ocular,
            DateTime fechaInicio,
            DateTime fechaFin
        )
        {
            Usuario = usuario;
            Telescopio = telescopio;
            Montura = montura;
            Camara = camara;
            Ocular = ocular;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;

            Validar();

            Estado = EstadoPrestamo.EnPrestamo;
        }

        private void Validar()
        {
            if (FechaInicio > FechaFin)
                throw new Exception("La fecha de inicio no puede ser mayor a la fecha fin");

            if (Camara is null && Ocular is null)
                throw new Exception("Debe incluir cámara u ocular");

            if (Camara is not null && Ocular is not null)
                throw new Exception("No puede incluir cámara y ocular al mismo tiempo");

            if (Usuario is null)
                throw new Exception("Usuario obligatorio");

            if (Telescopio is null || Montura is null)
                throw new Exception("Telescopio y montura son obligatorios");
        }

        public void Update(
                           Usuario usuario,
                           EquipoTelescopio telescopio,
                           EquipoMontura montura,
                           EquipoCamara? camara,
                           EquipoOcular? ocular,
                           DateTime fechaInicio,
                           DateTime fechaFin)
        {
            Usuario = usuario;
            Telescopio = telescopio;
            Montura = montura;
            Camara = camara;
            Ocular = ocular;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;

            Validar();
        }

        public void Devolver()
        {
            Estado = EstadoPrestamo.Devuelto;
        }
    }
}