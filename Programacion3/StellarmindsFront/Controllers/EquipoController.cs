using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebApp.Filter;
using WebApp.Models.Dtos.Equipo;

namespace WebApp.Controllers
{
    public class EquipoController : Controller
    {
        private readonly HttpClient _httpClient;

        public EquipoController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Logueado]
        [Administrador]
        public async Task<IActionResult> Index()
        {
            try
            {
                var token = HttpContext.Session.GetString("JWT");

                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://localhost:7051/api/v1/Equipos"
                );

                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.SendAsync(request);

                var raw = await response.Content.ReadAsStringAsync();

                ViewBag.Debug = $"STATUS: {response.StatusCode} | BODY: {raw}";

                if (!response.IsSuccessStatusCode)
                {
                    return View(new List<EquipoListadoDto>());
                }

                var equipos = await response.Content.ReadFromJsonAsync<List<EquipoListadoDto>>();

                return View(equipos ?? new List<EquipoListadoDto>());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<EquipoListadoDto>());
            }
        }

        [Logueado]
        [Administrador]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Logueado]
        [Administrador]
        [HttpPost]
        public async Task<IActionResult> Create(EquipoAltaDto equipo)
        {
            SetToken();

            object dtoToSend;

            if (equipo.tipoEquipo == "Camara")
            {
                dtoToSend = new
                {
                    equipo.marca,
                    equipo.modelo,
                    equipo.cantidadDisponible,
                    equipo.tipoEquipo,
                    equipo.tipoSensor,
                    equipo.resolucion,
                    equipo.tamanioPixelMicras
                };
            }
            else if (equipo.tipoEquipo == "Montura")
            {
                dtoToSend = new
                {
                    equipo.marca,
                    equipo.modelo,
                    equipo.cantidadDisponible,
                    equipo.tipoEquipo,
                    equipo.tipoMontura,
                    equipo.cargaUtilKg,
                    equipo.esGoTo
                };
            }
            else if (equipo.tipoEquipo == "Ocular")
            {
                dtoToSend = new
                {
                    equipo.marca,
                    equipo.modelo,
                    equipo.cantidadDisponible,
                    equipo.tipoEquipo,
                    equipo.diametroMM,
                    equipo.anguloVisionGrados
                };
            }
            else if (equipo.tipoEquipo == "Telescopio")
            {
                dtoToSend = new
                {
                    equipo.marca,
                    equipo.modelo,
                    equipo.cantidadDisponible,
                    equipo.tipoEquipo,
                    equipo.aperturaMM,
                    equipo.relacionFocal,
                    equipo.distanciaFocalMM,
                    equipo.pesoKg
                };
            }
            else
            {
                ViewBag.Error = "Tipo de equipo inválido";
                return View(equipo);
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync(
                    "https://localhost:7051/api/v1/Equipos",
                    dtoToSend);

                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    ViewBag.Error = body;
                    return View(equipo);
                }

                TempData["Success"] = "Equipo creado correctamente";
                return RedirectToAction("Index");
            }
            catch (HttpRequestException)
            {
                ViewBag.Error = "Error de conexión con el servidor";
                return View(equipo);
            }
        }

        [Logueado]
        [Administrador]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                SetToken();

                var response = await _httpClient.GetAsync(
                    $"https://localhost:7051/api/v1/Equipos/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = await response.Content.ReadAsStringAsync();
                    return RedirectToAction("Index");
                }

                var equipo = await response.Content.ReadFromJsonAsync<EquipoAltaDto>();

                return View(equipo);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [Logueado]
        [Administrador]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EquipoAltaDto equipo)
        {
            try
            {
                SetToken();

                var response = await _httpClient.PutAsJsonAsync(
                    $"https://localhost:7051/api/v1/Equipos/{id}",
                    equipo);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = await response.Content.ReadAsStringAsync();
                    return View(equipo);
                }

                TempData["Success"] = "Equipo editado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(equipo);
            }
        }

        [Logueado]
        [Administrador]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [Logueado]
        [Administrador]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                SetToken();

                var response = await _httpClient.DeleteAsync(
                    $"https://localhost:7051/api/v1/Equipos/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    TempData["Error"] = await response.Content.ReadAsStringAsync();
                    return RedirectToAction("Index");
                }

                TempData["Success"] = "Equipo eliminado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        private void SetToken()
        {
            var token = HttpContext.Session.GetString("JWT");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}