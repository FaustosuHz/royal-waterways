using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {

        Sistema sis = Sistema.Instancia();

        public IActionResult Index() //juaper@laEmpresa.com empleado
        {
            int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
            double gastosDelMes = sis.ObtenerGastosDelMes(idLogueado);

            if (idLogueado != null)
            {
                Usuario u = sis.ObtenerUsuarioPorId(idLogueado.Value);
                List<Usuario> miembrosEquipo = sis.ObtenerMiembrosDeEquipo(u);

                ViewBag.GastoDelMes = gastosDelMes;
                ViewBag.Miembros = miembrosEquipo;
                return View(u);
            }
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string unEmail, string unaContrasenia)
        {
            Usuario usuarioBuscado = sis.ObtenerUsuarioPorEmailYContrasenia(unEmail, unaContrasenia);
            if (usuarioBuscado != null) 
            {
                HttpContext.Session.SetString("rolUsuario", usuarioBuscado.Rol.ToString());
                HttpContext.Session.SetInt32("idUsuarioLogueado", usuarioBuscado.Id);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Mensaje = "Email o Contraseña incorrectos";

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Usuario");
        }

    }
}