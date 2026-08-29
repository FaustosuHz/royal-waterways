using Dominio.ValueObjects.VOEquipo;

namespace Dominio.Entidades
{
    public class EquipoOcular : Equipo
    {
        public VOUnidadMM DiametroMM { get; private set; }
        public VOAnguloVisionGrado AnguloVisionGrados { get; private set; }

        public EquipoOcular()
        {
        }

        public EquipoOcular(
            VOMarca marca,
            VOModelo modelo,
            VOCantidadDisponible cantidadDisponible,
            VOUnidadMM diametroMM,
            VOAnguloVisionGrado anguloVisionGrados
        ) : base(marca, modelo, cantidadDisponible)
        {
            DiametroMM = diametroMM;
            AnguloVisionGrados = anguloVisionGrados;
        }

        public override void Update(Equipo nuevo)
        {
            base.Update(nuevo);

            EquipoOcular ocular = (EquipoOcular)nuevo;

            DiametroMM = ocular.DiametroMM;
            AnguloVisionGrados = ocular.AnguloVisionGrados;
        }
    }
}