using Dominio.Entidades;
using Dominio.ValueObjects.VOObjetoCeleste;
using Dominio.ValueObjects.VOShared;
using LogicaAplicacion.Dtos.ObjetoCeleste;

namespace LogicaAplicacion.Mapper
{
    public class ObjetoCelesteMapper
    {
        public static ObjetoCeleste FromDto(ObjetoCelesteDto dto)
        {
            return new ObjetoCeleste(
                new VONombre(dto.nombre),
                (TipoObjetoCeleste)dto.tipo,
                new VOMagnitudAparente(dto.magnitudAparente)
            );
        }

        public static ObjetoCelesteDto ToDto(ObjetoCeleste objetoCeleste)
        {
            return new ObjetoCelesteDto(
                objetoCeleste.Id,
                objetoCeleste.Nombre.Value,
                (int)objetoCeleste.Tipo,
                objetoCeleste.MagnitudAparente.Value
            );
        }
    }
}