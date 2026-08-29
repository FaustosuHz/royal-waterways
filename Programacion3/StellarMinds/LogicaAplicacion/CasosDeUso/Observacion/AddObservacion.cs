using Dominio.Entidades;
using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.Observacion;
using LogicaAplicacion.Mapper;

public class AddObservacion : ICUAdd<ObservacionAltaDto>
{
    private IRepositorioObservacion _observaciones;
    private IRepositorioUsuario _usuarios;
    private IRepositorioPrestamo _prestamos;
    private IRepositorioObjetoCeleste _objetos;

    public AddObservacion(
        IRepositorioObservacion observaciones,
        IRepositorioUsuario usuarios,
        IRepositorioPrestamo prestamos,
        IRepositorioObjetoCeleste objetos)
    {
        _observaciones = observaciones;
        _usuarios = usuarios;
        _prestamos = prestamos;
        _objetos = objetos;
    }

    public void Execute(ObservacionAltaDto dto)
    {
        if (dto == null)
            throw new ArgumentException("Datos inválidos");

        Usuario usuario = _usuarios.GetById(dto.usuarioId);
        if (usuario == null)
            throw new Exception("Usuario no encontrado");

        Prestamo prestamo = _prestamos.GetById(dto.prestamoId);
        if (prestamo == null)
            throw new Exception("Prestamo no encontrado");

        ObjetoCeleste objeto = _objetos.GetById(dto.objetoCelesteId);
        if (objeto == null)
            throw new Exception("Objeto celeste no encontrado");

        Observacion observacion = ObservacionMapper.FromDto(
            dto,
            usuario,
            prestamo,
            objeto
        );

        _observaciones.Add(observacion);
    }
}