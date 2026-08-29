using Dominio.ValueObjects.VOEquipo;

namespace Dominio.Entidades
{
    public class EquipoCamara : Equipo
    {
        public CamaraTipoSensor TipoSensor { get; private set; }
        public VOResolucion Resolucion { get; private set; }
        public VOTamanioPixelMicras TamanioPixelMicras { get; private set; }

        public EquipoCamara()
        {
        }

        public EquipoCamara(
            VOMarca marca,
            VOModelo modelo,
            VOCantidadDisponible cantidadDisponible,
            CamaraTipoSensor tipoSensor,
            VOResolucion resolucion,
            VOTamanioPixelMicras tamanioPixelMicras
        ) : base(marca, modelo, cantidadDisponible)
        {
            TipoSensor = tipoSensor;
            Resolucion = resolucion;
            TamanioPixelMicras = tamanioPixelMicras;
        }

        public override void Update(Equipo nuevo)
        {
            base.Update(nuevo);

            EquipoCamara camara = (EquipoCamara)nuevo;

            TipoSensor = camara.TipoSensor;
            Resolucion = camara.Resolucion;
            TamanioPixelMicras = camara.TamanioPixelMicras;
        }
    }
}