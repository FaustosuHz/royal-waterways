using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PagoController : Controller
    {
        Sistema sis = Sistema.Instancia();

        public IActionResult Index()
        {
            int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
            if (idLogueado != null)
            {
                return View(sis.ObtenerPagoPorUsuarioPorId(idLogueado.Value));
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
            if (idLogueado != null)
            {
                return View(sis.GetGastos());

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(string tipoPago, int selectGasto, string metodoPago, double monto, int numeroDeRecibo, string descripcion, DateTime? fechaPago, DateTime? fechaInicial, DateTime? fechaFinal)
        {
            try
            {
                if (selectGasto == -1 || metodoPago == "-1" || monto < 0)
                {
                    ViewBag.Msg = "Debe seleccionar un gasto, un método de pago y un monto válidos";
                    return View(sis.GetGastos());
                }

                int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
                Usuario usuario = sis.ObtenerUsuarioPorId(idLogueado.Value);

                Gasto gasto = sis.ObtenerGastoPorId(selectGasto);
                MetodoDePago metodo = Enum.Parse<MetodoDePago>(metodoPago);

                if (tipoPago == "unico")
                {
                    if (fechaPago == null)
                    {
                        ViewBag.Msg = "Debe ingresar la fecha de pago.";
                        return View(sis.GetGastos());
                    }

                    sis.AltaPagoUnico(gasto, metodo, usuario, descripcion, monto, numeroDeRecibo, fechaPago.Value);
                }

                else if (tipoPago == "recurrente")
                {
                    if (fechaInicial == null)
                    {
                        ViewBag.Msg = "Debe ingresar la fecha inicial.";
                        return View(sis.GetGastos());
                    }

                    if (fechaFinal != null && fechaInicial > fechaFinal)
                    {
                        ViewBag.Msg = "La fecha inicial no puede ser posterior a la fecha final.";
                        return View(sis.GetGastos());
                    }

                    sis.AltaPagoRecurrente(gasto, metodo, usuario, descripcion, monto, fechaInicial.Value, fechaFinal);
                }

                ViewBag.Msg = "Pago creado correctamente.";
                return View(sis.GetGastos());
            }
            catch
            {
                ViewBag.Msg = "No se pudo crear el pago.";
                return View(sis.GetGastos());
            }
        }

        [HttpGet]
        public IActionResult Lista(int? mesSeleccionado, int? anioSeleccionado)
        {
            int? idLogueado = HttpContext.Session.GetInt32("idUsuarioLogueado");
            string rol = HttpContext.Session.GetString("rolUsuario");

            if (idLogueado == null || rol != "Gerente")
            {
                return RedirectToAction("Index", "Home");
            }

            Usuario gerente = sis.ObtenerUsuarioPorId(idLogueado.Value);
            List<Pago> listaCompleta = sis.ObtenerPagosDeMiembrosDeEquipo(gerente);

            // si no elijo año ni nada, viene por default el mes actual
            int mesReal = mesSeleccionado ?? DateTime.Now.Month;
            int anioReal = anioSeleccionado ?? DateTime.Now.Year;

            List<Pago> listaFiltrada = new List<Pago>();

            foreach (Pago p in listaCompleta)
            {
                DateTime f = p.Fecha();

                if (f.Month == mesReal && f.Year == anioReal)
                {
                    listaFiltrada.Add(p);
                }
            }

            return View(listaFiltrada);
        }
    }
}