using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Logueado]
        public IActionResult Index()
        {
            ViewBag.Rol = HttpContext.Session.GetString("rol");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.UserId = HttpContext.Session.GetString("userId");
            ViewBag.Token = HttpContext.Session.GetString("JWT");

            return View();
        }


    }
}
