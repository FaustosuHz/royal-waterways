using Dominio.InterfacesLogicaAplicacion;
using LogicaAplicacion.Dtos.AuditoriaPrestamo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditoriaPrestamoController : ControllerBase
    {
        private readonly ICUGetAll<AuditoriaPrestamoMostrarDto> _getAll;
        private readonly ICUGetById<AuditoriaPrestamoMostrarDto> _getById;

        public AuditoriaPrestamoController(
            ICUGetAll<AuditoriaPrestamoMostrarDto> getAll,
            ICUGetById<AuditoriaPrestamoMostrarDto> getById)
        {
            _getAll = getAll;
            _getById = getById;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_getAll.Execute());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_getById.Execute(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}