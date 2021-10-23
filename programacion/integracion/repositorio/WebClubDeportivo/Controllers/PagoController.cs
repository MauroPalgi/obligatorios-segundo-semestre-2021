using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auxiliar;
using Dominio;


namespace WebClubDeportivo.Controllers
{
    public class PagoController : Controller
    {
        private IRepoPagos repoPagos = Auxiliar.FabricaRepositorio.ObtenerRepositorioPagos();
        private IRepoSocios repoSocios = Auxiliar.FabricaRepositorio.ObtenerRepositorioSocios();
        // GET: Pago
        public ActionResult Cuponera(string cedula)
        {
            if (Session["logeado"] != null)
            {
                ViewBag.Cedula = cedula;
                return View();
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }
        public ActionResult PagoCuponera(string actividades, string cedula)
        {
            if (Session["logeado"] != null)
            {
                decimal monto = 0;
                string[] parts = cedula.Split('/');
                Socio unSocio = repoSocios.BuscarPorCi(parts[0]);
                Pago mensualidad = new Cuponera()
                {
                    Actividades = Int32.Parse(actividades),
                };
                monto = repoPagos.Alta(mensualidad, unSocio);
                string mensaje = "No se pudo Ingresar el Pago.";
                if (monto > 0)
                {
                    FabricaRepositorio.ObtenerRepositorioSocios().ActivarSocio(unSocio);
                    mensaje = "Se ingreso el monto de: " + monto;
                }
                ViewBag.Mensaje = mensaje;
                return View("ResultadoPago");
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }
        public ActionResult Mensualidad(string cedula, decimal? monto)
        {
            if (Session["logeado"] != null)
            {
                ViewBag.Cedula = cedula;
                return View();
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }

        [HttpPost]
        public ActionResult PagoMensualidad(string cedula)
        {
            if (Session["logeado"] != null)
            {
                decimal monto = 0;
                string[] parts = cedula.Split('/');
                Socio unSocio = repoSocios.BuscarPorCi(parts[0]);
                Pago mensualidad = new PaseLibre();
                monto = repoPagos.Alta(mensualidad, unSocio);
                string mensaje = "No se pudo Ingresar el Pago.";
                if (monto > 0)
                {
                    FabricaRepositorio.ObtenerRepositorioSocios().ActivarSocio(unSocio);
                    mensaje = "Se ingreso el monto de: " + monto;
                }
                ViewBag.Mensaje = mensaje;
                return View("ResultadoPago");
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }
        public ActionResult ElegirPago(string tipo, string cedula)
        {
            if (Session["logeado"] != null)
            {
                if (tipo == "cuponera")
                {
                    return RedirectToAction("Cuponera", new { cedula = cedula });
                }
                else
                {
                    return RedirectToAction("Mensualidad", new { cedula = cedula });
                }
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }
    }
}