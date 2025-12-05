using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class GastoController : Controller
    {
        Sistema sis = Sistema.Instancia();

        public IActionResult Index()
        {
            int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
            string rol = HttpContext.Session.GetString("rolUsuario");
            if (idLogueado != null && rol == "Gerente")
            {
                return View(sis.GetGastos());
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
            string rol = HttpContext.Session.GetString("rolUsuario");
            if (idLogueado != null && rol == "Gerente")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(string nombre, string descripcion)
        {
            try
            {
                if (nombre != null && descripcion != null)
                {
                  
                    sis.CargarGasto(nombre, descripcion);
                }

                ViewBag.Msg = "Gasto cargado correctamente.";
                return View();
            }
            catch
            {
                ViewBag.Msg = "No se pudo crear el gasto.";
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
            string rol = HttpContext.Session.GetString("rolUsuario");
            Gasto gastoBuscado = sis.ObtenerGastoPorId(id);

            if (gastoBuscado != null && idLogueado != null && rol == "Gerente")
            {
                return View(gastoBuscado);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Delete(Gasto g)
        {
            Gasto gastoBuscado = sis.ObtenerGastoPorId(g.Id);

            bool tienePagos = false;
            foreach (var pago in sis.GetPagos())
            {
                if (pago.TipoDeGasto.Id == g.Id)
                {
                    tienePagos = true;
                    break;
                }
            }

            if (tienePagos)
            {
                ViewBag.Mensaje = "No se puede eliminar el gasto, tiene pagos asociados.";
                return View(gastoBuscado);
            }

            sis.BajaGasto(gastoBuscado);

            return RedirectToAction("Index");
        }
    }
}
