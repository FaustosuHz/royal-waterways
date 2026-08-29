using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.Dtos.Equipo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class EquiposController : ControllerBase
{
    private ICUAdd<EquipoAltaDto> _add;
    private ICUGetAll<EquipoListadoDto> _getAll;
    private ICUGetById<EquipoListadoDto> _getById;
    private ICUEdit<EquipoAltaDto> _edit;
    private ICUDeleteEquipo _delete;
    private ICUGetDisponibilidadEquipo _getDisponibilidad;

    public EquiposController(
        ICUAdd<EquipoAltaDto> add,
        ICUGetAll<EquipoListadoDto> getAll,
        ICUGetById<EquipoListadoDto> getById,
        ICUEdit<EquipoAltaDto> edit,
        ICUDeleteEquipo delete,
        ICUGetDisponibilidadEquipo getDisponibilidad)
    {
        _add = add;
        _getAll = getAll;
        _getById = getById;
        _edit = edit;
        _delete = delete;
        _getDisponibilidad = getDisponibilidad;
    }

    [HttpPost]
    public IActionResult Create(EquipoAltaDto equipo)
    {
        try
        {
            _add.Execute(equipo);

            return StatusCode(StatusCodes.Status201Created, new
            {
                mensaje = "Equipo creado correctamente"
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                mensaje = ex.Message
            });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new
            {
                mensaje = ex.Message
            });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                mensaje = "Ocurrió un error interno."
            });
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_getAll.Execute());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                mensaje = "Ocurrió un error interno."
            });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            return Ok(_getById.Execute(id));
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new
            {
                mensaje = ex.Message
            });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                mensaje = "Ocurrió un error interno."
            });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, EquipoAltaDto equipo)
    {
        try
        {
            _edit.Execute(id, equipo);

            return Ok(new
            {
                mensaje = "Equipo editado correctamente"
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                mensaje = ex.Message
            });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new
            {
                mensaje = ex.Message
            });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                mensaje = "Ocurrió un error interno."
            });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _delete.Execute(id);

            return Ok(new
            {
                mensaje = "Equipo eliminado correctamente"
            });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new
            {
                mensaje = ex.Message
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                mensaje = ex.Message
            });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                mensaje = "Ocurrió un error interno."
            });
        }
    }

    [HttpGet("{id}/disponibilidad")]
    public IActionResult GetDisponibilidad(int id)
    {
        try
        {
            var disponible = _getDisponibilidad.Execute(id);

            return Ok(new
            {
                disponible
            });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new
            {
                mensaje = ex.Message
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                mensaje = ex.Message
            });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                mensaje = "Ocurrió un error interno."
            });
        }
    }
}