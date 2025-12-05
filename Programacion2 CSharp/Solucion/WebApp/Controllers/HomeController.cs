using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Sistema sis = Sistema.Instancia();
        public IActionResult Index()
        {
            int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
            if(idLogueado != null)
            {
                Usuario u = sis.ObtenerUsuarioPorId(idLogueado.Value);
                ViewBag.Usuario = u;

                return View();
            }

            return RedirectToAction("Login", "Usuario");
        }

    }
}
