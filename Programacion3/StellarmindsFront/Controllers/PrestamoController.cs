using Microsoft.AspNetCore.Mvc;
using StellarmindsFront.Models.Dtos.Prestamo;
using StellarmindsFront.Models.Dtos.Usuario;
using System.Net.Http.Headers;
using WebApp.Filter;
using WebApp.Models.Dtos.Equipo;

namespace WebApp.Controllers
{
    public class PrestamoController : Controller
    {
        private HttpClient _httpClient;

        public PrestamoController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Logueado]
        [Coordinador]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var token = HttpContext.Session.GetString("JWT");

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var usuariosResponse =
                    await _httpClient.GetAsync("https://localhost:7051/api/v1/Usuarios");

                var equiposResponse =
                    await _httpClient.GetAsync("https://localhost:7051/api/v1/Equipos");

                var usuarios =
                    await usuariosResponse.Content.ReadFromJsonAsync<List<UsuarioListadoDto>>();

                var equipos =
                    await equiposResponse.Content.ReadFromJsonAsync<List<EquipoListadoDto>>();

                ViewBag.Usuarios = usuarios ?? new List<UsuarioListadoDto>();
                ViewBag.Equipos = equipos ?? new List<EquipoListadoDto>();

                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        [Logueado]
        [Coordinador]
        [HttpPost]
        public async Task<IActionResult> Create(PrestamoAltaDto prestamo)
        {
            try
            {
                var token = HttpContext.Session.GetString("JWT");

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PostAsJsonAsync(
                    "https://localhost:7051/api/v1/Prestamos",
                    prestamo);

                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Préstamo creado correctamente";
                    return RedirectToAction("Create");
                }

                var usuariosResponse =
                    await _httpClient.GetAsync("https://localhost:7051/api/v1/Usuarios");

                var equiposResponse =
                    await _httpClient.GetAsync("https://localhost:7051/api/v1/Equipos");

                ViewBag.Usuarios =
                    await usuariosResponse.Content.ReadFromJsonAsync<List<UsuarioListadoDto>>()
                    ?? new List<UsuarioListadoDto>();

                ViewBag.Equipos =
                    await equiposResponse.Content.ReadFromJsonAsync<List<EquipoListadoDto>>()
                    ?? new List<EquipoListadoDto>();

                TempData["Error"] = content;
                return View(prestamo);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(prestamo);
            }
        }

        [Logueado]
        [HttpGet]
        public async Task<IActionResult> SociosPorTelescopio(int? telescopioId)
        {
            try
            {
                var token = HttpContext.Session.GetString("JWT");

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var equipos = await _httpClient.GetFromJsonAsync<List<EquipoListadoDto>>(
                    "https://localhost:7051/api/v1/Equipos"
                );

                ViewBag.Telescopios = equipos?
                    .Where(e => e.TipoEquipo == "Telescopio")
                    .ToList()
                    ?? new List<EquipoListadoDto>();

                if (!telescopioId.HasValue)
                    return View(new List<UsuarioListadoDto>());

                var socios = await _httpClient.GetFromJsonAsync<List<UsuarioListadoDto>>(
                    $"https://localhost:7051/api/v1/Prestamos/telescopio/{telescopioId}/socios"
                );

                return View(socios ?? new List<UsuarioListadoDto>());
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new List<UsuarioListadoDto>());
            }
        }

        [Logueado]
        [Coordinador]
        [HttpGet]
        public async Task<IActionResult> Devolver()
        {
            try
            {
                var token = HttpContext.Session.GetString("JWT");

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var usuarios = await _httpClient.GetFromJsonAsync<List<UsuarioListadoDto>>(
                    "https://localhost:7051/api/v1/Usuarios"
                );

                ViewBag.Usuarios = usuarios ?? new List<UsuarioListadoDto>();

                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        [Logueado]
        [HttpGet]
        public async Task<IActionResult> MisPrestamos(int? mes, int? anio)
        {
            try
            {
                var token = HttpContext.Session.GetString("JWT");
                var userId = HttpContext.Session.GetString("userId");

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var prestamos = await _httpClient.GetFromJsonAsync<List<PrestamoDetalleDto>>(
                    $"https://localhost:7051/api/v1/prestamos/usuario/{userId}/todos"
                );

                if (mes.HasValue && anio.HasValue)
                {
                    prestamos = prestamos?
                        .Where(p =>
                            p.FechaInicio.Month == mes.Value &&
                            p.FechaInicio.Year == anio.Value)
                        .ToList();
                }

                return View(prestamos ?? new List<PrestamoDetalleDto>());
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new List<PrestamoDetalleDto>());
            }
        }


    }
}