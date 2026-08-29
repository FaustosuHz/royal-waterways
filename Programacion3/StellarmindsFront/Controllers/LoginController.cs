using Microsoft.AspNetCore.Mvc;
using StellarmindsFront.Models.Dtos.Usuario;
using System.IdentityModel.Tokens.Jwt;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private HttpClient _httpClient;

        public LoginController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(
                    "https://localhost:7051/api/v1/Login",
                    dto);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["Error"] = "Usuario o contraseña incorrectos";
                    return View(dto);
                }

                var resultado =
                    await response.Content.ReadFromJsonAsync<TokenResponse>();

                var token = resultado.token;

                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);

                var rol = jwt.Claims
                    .FirstOrDefault(c => c.Type == "rol")?.Value;

                var nombre = jwt.Claims
                    .FirstOrDefault(c => c.Type == "nombre")?.Value;

                var email = jwt.Claims
                    .FirstOrDefault(c => c.Type == "email")?.Value;

                var id = jwt.Claims
                    .FirstOrDefault(c => c.Type == "id")?.Value;

                HttpContext.Session.SetString("JWT", token);

                if (rol != null)
                    HttpContext.Session.SetString("rol", rol);

                if (nombre != null)
                    HttpContext.Session.SetString("nombre", nombre);

                if (email != null)
                    HttpContext.Session.SetString("email", email);

                if (id != null)
                    HttpContext.Session.SetString("userId", id);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                TempData["Error"] = "Error conectando con el servidor";
                return View(dto);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Login");
        }
    }

    public class TokenResponse
    {
        public string token { get; set; }
    }
}