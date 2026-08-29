using Dominio.Entidades;
using Dominio.ValueObjects.VOEquipo;
using LogicaAplicacion.Dtos.Equipo;

namespace LogicaAplicacion.Mapper
{
    internal static class EquipoMapper
    {
        public static Equipo FromDto(EquipoAltaDto dto)
        {
            if (dto == null)
                throw new ArgumentException("DTO inválido");

            switch (dto.tipoEquipo)
            {
                case "Camara":
                    return new EquipoCamara(
                        new VOMarca(dto.marca),
                        new VOModelo(dto.modelo),
                        new VOCantidadDisponible(dto.cantidadDisponible),
                        Enum.Parse<CamaraTipoSensor>(dto.tipoSensor!),
                        new VOResolucion(dto.resolucion!),
                        new VOTamanioPixelMicras(dto.tamanioPixelMicras!.Value)
                    );

                case "Montura":
                    return new EquipoMontura(
                        new VOMarca(dto.marca),
                        new VOModelo(dto.modelo),
                        new VOCantidadDisponible(dto.cantidadDisponible),
                        Enum.Parse<TipoMontura>(dto.tipoMontura!),
                        new VOUnidadKg(dto.cargaUtilKg!.Value),
                        dto.esGoTo!.Value
                    );

                case "Ocular":
                    return new EquipoOcular(
                        new VOMarca(dto.marca),
                        new VOModelo(dto.modelo),
                        new VOCantidadDisponible(dto.cantidadDisponible),
                        new VOUnidadMM(dto.diametroMM!.Value),
                        new VOAnguloVisionGrado(dto.anguloVisionGrados!.Value)
                    );

                case "Telescopio":
                    return new EquipoTelescopio(
                        new VOMarca(dto.marca),
                        new VOModelo(dto.modelo),
                        new VOCantidadDisponible(dto.cantidadDisponible),
                        new VOUnidadMM(dto.aperturaMM!.Value),
                        new VORelacionFocal(dto.relacionFocal!),
                        new VOUnidadMM(dto.distanciaFocalMM!.Value),
                        new VOUnidadKg(dto.pesoKg!.Value)
                    );

                default:
                    throw new InvalidOperationException("Tipo de equipo inválido");
            }
        }

        public static EquipoListadoDto ToListadoDto(Equipo equipo)
        {
            if (equipo is EquipoCamara camara)
            {
                return new EquipoListadoDto(
                    equipo.Id,
                    equipo.Marca.Value,
                    equipo.Modelo.Value,
                    equipo.CantidadDisponible.Value,
                    "Camara",

                    camara.TipoSensor.ToString(),
                    camara.Resolucion.Value,
                    camara.TamanioPixelMicras.Value,

                    null, null, null,
                    null, null,
                    null, null, null, null
                );
            }

            if (equipo is EquipoMontura montura)
            {
                return new EquipoListadoDto(
                    equipo.Id,
                    equipo.Marca.Value,
                    equipo.Modelo.Value,
                    equipo.CantidadDisponible.Value,
                    "Montura",

                    null, null, null,

                    montura.TipoMontura.ToString(),
                    montura.CargaUtilKg.Value,
                    montura.EsGoTo,

                    null, null,
                    null, null, null, null
                );
            }

            if (equipo is EquipoOcular ocular)
            {
                return new EquipoListadoDto(
                    equipo.Id,
                    equipo.Marca.Value,
                    equipo.Modelo.Value,
                    equipo.CantidadDisponible.Value,
                    "Ocular",

                    null, null, null,
                    null, null, null,

                    ocular.DiametroMM.Value,
                    ocular.AnguloVisionGrados.Value,

                    null, null, null, null
                );
            }

            if (equipo is EquipoTelescopio tel)
            {
                return new EquipoListadoDto(
                    equipo.Id,
                    equipo.Marca.Value,
                    equipo.Modelo.Value,
                    equipo.CantidadDisponible.Value,
                    "Telescopio",

                    null, null, null,
                    null, null, null,
                    null, null,

                    tel.AperturaMM.Value,
                    tel.RelacionFocal.Value,
                    tel.DistanciaFocalMM.Value,
                    tel.PesoKg.Value
                );
            }

            throw new InvalidOperationException("Tipo de equipo inválido");
        }
    }
}