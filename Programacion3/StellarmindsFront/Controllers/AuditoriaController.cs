using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebApp.Filter;
using WebApp.Models.Dtos.Auditoria;

namespace WebApp.Controllers
{
    public class AuditoriaController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuditoriaController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Logueado]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWT");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var auditorias = await _httpClient.GetFromJsonAsync<List<AuditoriaPrestamoApiDto>>(
                "https://localhost:7051/api/v1/AuditoriaPrestamo"
            );

            return View(auditorias ?? new List<AuditoriaPrestamoApiDto>());
        }

        [Logueado]
        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            var token = HttpContext.Session.GetString("JWT");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var auditoria = await _httpClient.GetFromJsonAsync<AuditoriaPrestamoApiDto>(
                $"https://localhost:7051/api/v1/AuditoriaPrestamo/{id}"
            );

            return View(auditoria);
        }
    }
}