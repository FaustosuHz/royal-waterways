using Microsoft.AspNetCore.Mvc;
using StellarmindsFront.Models.Dtos.Observacion;
using StellarmindsFront.Models.Dtos.Prestamo;
using System.Net.Http.Headers;
using WebApp.Filter;
using WebApp.Models.Dtos.ObjetoCeleste;

namespace WebApp.Controllers
{
    public class ObservacionController : Controller
    {
        private readonly HttpClient _httpClient;

        public ObservacionController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Logueado]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var token = HttpContext.Session.GetString("JWT");
            var userId = HttpContext.Session.GetString("userId");

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Login");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var prestamos = await _httpClient.GetFromJsonAsync<List<PrestamoDetalleDto>>(
                $"https://localhost:7051/api/v1/prestamos/usuario/{userId}"
            );

            var objetos = await _httpClient.GetFromJsonAsync<List<ObjetoCelesteDto>>(
                "https://localhost:7051/api/v1/ObjetosCelestes"
            );

            ViewBag.Prestamos = prestamos ?? new List<PrestamoDetalleDto>();
            ViewBag.Objetos = objetos ?? new List<ObjetoCelesteDto>();

            return View();
        }

        [Logueado]
        [HttpGet]
        public async Task<IActionResult> Ranking()
        {
            var token = HttpContext.Session.GetString("JWT");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var ranking = await _httpClient.GetFromJsonAsync<List<RankingObjetoCelesteDto>>(
                "https://localhost:7051/api/v1/Observaciones/ranking"
            );

            return View(ranking ?? new List<RankingObjetoCelesteDto>());
        }

        [Logueado]
        [HttpPost]
        public async Task<IActionResult> Create(ObservacionAltaDto dto)
        {
            var token = HttpContext.Session.GetString("JWT");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            dto.usuarioId = int.Parse(HttpContext.Session.GetString("userId"));

            var response = await _httpClient.PostAsJsonAsync(
                "https://localhost:7051/api/v1/Observaciones",
                dto
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Observación creada";
                return RedirectToAction("Create");
            }

            TempData["Error"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("Create");
        }
    }
}