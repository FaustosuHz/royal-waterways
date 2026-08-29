using Dominio.ValueObjects.VOEquipo;

namespace Dominio.Entidades
{
    public abstract class Equipo
    {
        public int Id { get; private set; }
        public VOMarca Marca { get; private set; }
        public VOModelo Modelo { get; private set; }
        public VOCantidadDisponible CantidadDisponible { get; private set; }

        public Equipo()
        {
        }

        public Equipo(
            VOMarca marca,
            VOModelo modelo,
            VOCantidadDisponible cantidadDisponible
        )
        {
            Marca = marca;
            Modelo = modelo;
            CantidadDisponible = cantidadDisponible;
        }

        public void DisminuirCantidad()
        {
            if (CantidadDisponible.Value <= 0)
                throw new Exception("Sin disponibilidad");

            CantidadDisponible = new VOCantidadDisponible(CantidadDisponible.Value - 1);
        }

        public void AumentarCantidad()
        {
            CantidadDisponible = new VOCantidadDisponible(CantidadDisponible.Value + 1);
        }

        public virtual void Update(Equipo nuevo)
        {
            Marca = nuevo.Marca;
            Modelo = nuevo.Modelo;
            CantidadDisponible = nuevo.CantidadDisponible;
        }
    }
}