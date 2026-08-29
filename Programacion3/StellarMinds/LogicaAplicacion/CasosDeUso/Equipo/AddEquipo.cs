using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Equipo;
using LogicaAplicacion.Mapper;

public class AddEquipo : ICUAdd<EquipoAltaDto>
{
    private readonly IRepositorioEquipo _equipos;

    public AddEquipo(IRepositorioEquipo repo)
    {
        _equipos = repo;
    }

    public void Execute(EquipoAltaDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentException("Datos inválidos");
        }

        var equipo = EquipoMapper.FromDto(dto);

        _equipos.Add(equipo);
    }
}