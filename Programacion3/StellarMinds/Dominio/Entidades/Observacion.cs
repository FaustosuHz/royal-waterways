using Dominio.ValueObjects.VOObservacion;

namespace Dominio.Entidades
{
    public class Observacion
    {
        public int Id { get; private set; }

        public Usuario Usuario { get; private set; }
        public Prestamo Prestamo { get; private set; }
        public ObjetoCeleste ObjetoCeleste { get; private set; }

        public DateTime FechaObservacion { get; private set; }

        public ResultadoObservacion? Resultado { get; private set; }
        public VODetalle? Detalle { get; private set; }

        public Observacion() { }

        public Observacion(
            Usuario usuario,
            Prestamo prestamo,
            DateTime fechaObservacion,
            ObjetoCeleste objetoCeleste
        )
        {
            Usuario = usuario;
            Prestamo = prestamo;
            FechaObservacion = fechaObservacion;
            ObjetoCeleste = objetoCeleste;
        }

        public void RegistrarResultadoIA(ResultadoObservacion resultado, string detalle)
        {
            Resultado = resultado;
            Detalle = new VODetalle(detalle);
        }
    }
}