using Dominio.ValueObjects.VOEquipo;

namespace Dominio.Entidades
{
    public class EquipoTelescopio : Equipo
    {
        public VOUnidadMM AperturaMM { get; private set; }
        public VORelacionFocal RelacionFocal { get; private set; }
        public VOUnidadMM DistanciaFocalMM { get; private set; }
        public VOUnidadKg PesoKg { get; private set; }

        public EquipoTelescopio()
        {
        }

        public EquipoTelescopio(
            VOMarca marca,
            VOModelo modelo,
            VOCantidadDisponible cantidadDisponible,
            VOUnidadMM aperturaMM,
            VORelacionFocal relacionFocal,
            VOUnidadMM distanciaFocalMM,
            VOUnidadKg pesoKg
        ) : base(marca, modelo, cantidadDisponible)
        {
            AperturaMM = aperturaMM;
            RelacionFocal = relacionFocal;
            DistanciaFocalMM = distanciaFocalMM;
            PesoKg = pesoKg;
        }

        public override void Update(Equipo nuevo)
        {
            base.Update(nuevo);

            EquipoTelescopio telescopio = (EquipoTelescopio)nuevo;

            AperturaMM = telescopio.AperturaMM;
            RelacionFocal = telescopio.RelacionFocal;
            DistanciaFocalMM = telescopio.DistanciaFocalMM;
            PesoKg = telescopio.PesoKg;
        }

    }
}