using Dominio.ValueObjects.VOEquipo;

namespace Dominio.Entidades
{
    public class EquipoMontura : Equipo
    {
        public TipoMontura TipoMontura { get; private set; }
        public VOUnidadKg CargaUtilKg { get; private set; }
        public bool EsGoTo { get; private set; }

        public EquipoMontura()
        {
        }

        public EquipoMontura(
            VOMarca marca,
            VOModelo modelo,
            VOCantidadDisponible cantidadDisponible,
            TipoMontura tipoMontura,
            VOUnidadKg cargaUtilKg,
            bool esGoTo
        ) : base(marca, modelo, cantidadDisponible)
        {
            TipoMontura = tipoMontura;
            CargaUtilKg = cargaUtilKg;
            EsGoTo = esGoTo;
        }

        public override void Update(Equipo nuevo)
        {
            base.Update(nuevo);

            EquipoMontura montura = (EquipoMontura)nuevo;

            TipoMontura = montura.TipoMontura;
            CargaUtilKg = montura.CargaUtilKg;
            EsGoTo = montura.EsGoTo;
        }
    }
}