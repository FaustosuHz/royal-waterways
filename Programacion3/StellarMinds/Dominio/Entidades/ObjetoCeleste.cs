using Dominio.ValueObjects.VOObjetoCeleste;
using Dominio.ValueObjects.VOShared;

namespace Dominio.Entidades
{
    public class ObjetoCeleste
    {
        public int Id { get; private set; }
        public VONombre Nombre { get; private set; }
        public TipoObjetoCeleste Tipo { get; private set; }
        public VOMagnitudAparente MagnitudAparente { get; private set; }

        public ObjetoCeleste() { }

        public ObjetoCeleste(
            VONombre nombre,
            TipoObjetoCeleste tipo,
            VOMagnitudAparente magnitud)
        {
            Nombre = nombre;
            Tipo = tipo;
            MagnitudAparente = magnitud;
        }

        public void Update(ObjetoCeleste objetoCeleste)
        {
            Nombre = objetoCeleste.Nombre;
            Tipo = objetoCeleste.Tipo;
            MagnitudAparente = objetoCeleste.MagnitudAparente;
        }
    }
}