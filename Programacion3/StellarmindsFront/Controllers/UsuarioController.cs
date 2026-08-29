using Microsoft.AspNetCore.Mvc;
using StellarmindsFront.Models.Dtos.Usuario;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private HttpClient _httpClient;

        public UsuarioController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Logueado]
        [Administrador]
        public IActionResult Create()
        {
            return View();
        }

        [Logueado]
        [Administrador]
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioAltaDto usuario)
        {
            try
            {
                var dto = new UsuarioAltaDto(
                    nombre: usuario.nombre,
                    apellido: usuario.apellido,
                    direccion: usuario.direccion,
                    telefono: usuario.telefono,
                    email: usuario.email,
                    nombreUsuario: usuario.nombreUsuario,
                    contrasenia: usuario.contrasenia,
                    Rol: usuario.Rol
                );

                var token = HttpContext.Session.GetString("JWT");

                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PostAsJsonAsync(
                    "https://localhost:7051/api/v1/Usuarios",
                    dto);

                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Usuario creado correctamente";
                    return RedirectToAction("Create");
                }

                TempData["Error"] = content;
                return View(usuario);
            }
            catch (Exception)
            {
                TempData["Error"] = "Error inesperado al conectar con la API";
                return View(usuario);
            }
        }
    }
}