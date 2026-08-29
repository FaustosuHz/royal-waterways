using Dominio.Entidades;
using Dominio.ValueObjects.VOShared;
using Dominio.ValueObjects.VOUsuario;
using LogicaAplicacion.Dtos.Usuario;

internal class UsuarioMapper
{
    public static Usuario FromDto(UsuarioAltaDto usuarioDto)
    {
        if (usuarioDto.Rol == "Administrador")
        {
            return new Administrador(
                new VONombre(usuarioDto.nombre),
                new VOApellido(usuarioDto.apellido),
                new VODireccion(usuarioDto.direccion),
                new VOTelefono(usuarioDto.telefono),
                new VOEmail(usuarioDto.email),
                new VONombreUsuario(usuarioDto.nombreUsuario),
                new VOContrasenia(usuarioDto.contrasenia)
            );
        }

        if (usuarioDto.Rol == "Coordinador")
        {
            return new Coordinador(
                new VONombre(usuarioDto.nombre),
                new VOApellido(usuarioDto.apellido),
                new VODireccion(usuarioDto.direccion),
                new VOTelefono(usuarioDto.telefono),
                new VOEmail(usuarioDto.email),
                new VONombreUsuario(usuarioDto.nombreUsuario),
                new VOContrasenia(usuarioDto.contrasenia)
            );
        }

        if (usuarioDto.Rol == "Socio")
        {
            return new Socio(
                new VONombre(usuarioDto.nombre),
                new VOApellido(usuarioDto.apellido),
                new VODireccion(usuarioDto.direccion),
                new VOTelefono(usuarioDto.telefono),
                new VOEmail(usuarioDto.email),
                new VONombreUsuario(usuarioDto.nombreUsuario),
                new VOContrasenia(usuarioDto.contrasenia)
            );
        }

        throw new InvalidOperationException("Rol inválido");
    }

    public static Usuario FromLoginDto(UsuarioLoginDto usuarioLoginDto)
    {
        return new Socio(
            null,
            null,
            null,
            null,
            null,
            new VONombreUsuario(usuarioLoginDto.nombreUsuario),
            new VOContrasenia(usuarioLoginDto.contrasenia)
        );
    }

    public static UsuarioLogueadoDto ToUsuarioLogueadoDto(Usuario usuario)
    {
        return new UsuarioLogueadoDto(
            usuario.Id,
            usuario.Email.Value,
            usuario.NombreUsuario.Value,
            usuario.GetType().Name
        );
    }

    public static UsuarioListadoDto ToUsuarioListadoDto(Usuario usuario)
    {
        return new UsuarioListadoDto(
            usuario.Id,
            usuario.Nombre.Value,
            usuario.Apellido.Value,
            usuario.Email.Value,
            usuario.NombreUsuario.Value,
            usuario.GetType().Name
        );
    }

    public static Usuario FromEditarDto(UsuarioEditarDto usuarioDto)
    {
        return new Socio(
            new VONombre(usuarioDto.nombre),
            new VOApellido(usuarioDto.apellido),
            new VODireccion(usuarioDto.direccion),
            new VOTelefono(usuarioDto.telefono),
            new VOEmail(usuarioDto.email),
            new VONombreUsuario(usuarioDto.nombreUsuario),
            new VOContrasenia(usuarioDto.contrasenia)
        );
    }
}