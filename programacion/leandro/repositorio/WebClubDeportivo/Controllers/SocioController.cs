using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Auxiliar;

namespace WebClubDeportivo.Controllers
{
    public class SocioController : Controller
    {
        private IRepoSocios repoSocios = Auxiliar.FabricaRepositorio.ObtenerRepositorioSocios();
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Pagos(string cedula)
        {
            ViewBag.Cedula = cedula;
            return View();
        }

        [HttpPost]
        public ActionResult Eliminar(string cedula)
        {
            Socio unSocio = this.repoSocios.BuscarPorCi(cedula);
            ViewBag.Socio = unSocio;
            string mensaje = "Socio elimiando correctamente.";
            bool seModifico = repoSocios.Baja(unSocio.Cedula);
            return RedirectToAction("Detalles", new { cedula = unSocio.Cedula, mensaje = mensaje });
        }
        public ActionResult AltaSocio(string MensajeSocio)
        {
            if (Session["logeado"] != null)
            {
                ViewBag.MensajeSocio = MensajeSocio;

                return View(new Socio());
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }
        [HttpPost]
        public ActionResult AltaSocio(Socio socio)
        {
            if (Session["logeado"] != null)
            {
                bool ok = FabricaRepositorio.ObtenerRepositorioSocios().Alta(socio);
                if (ok)
                {
                    return RedirectToAction("AltaSocio", new { MensajeSocio = "Se registro el socio" });
                }
                else
                {
                    return RedirectToAction("AltaSocio", new { MensajeSocio = "No se pudo registrar el socio" });
                }
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }

        }


        [HttpPost]
        public ActionResult BuscarSocio(string cedula)
        {
            if (Session["logeado"] != null)
            {
               Socio unSocio = null;
            List<Socio> socioEncontrado = new List<Socio>();
            if (cedula != "")
            {
                unSocio = this.repoSocios.BuscarPorCi(cedula);
                socioEncontrado.Add(unSocio);
                if (unSocio != null)
                {
                    ViewBag.Socio = socioEncontrado;
                    return RedirectToAction("Detalles", new { cedula = cedula });
                }
                else
                {
                    return View("~/Views/Funcionario/Inicio.cshtml");
                }
            }
            else
            {
                return View("~/Views/Funcionario/Inicio.cshtml");
            }
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }

        public ActionResult Detalles(string cedula, string mensaje)
        {
            if (Session["logeado"] != null)
            {
                Socio unSocio = this.repoSocios.BuscarPorCi(cedula);
                ViewBag.Socio = unSocio;
                if (mensaje != " ")
                {
                    ViewBag.Mensaje = mensaje;
                }
                return View();
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }
        [HttpPost]
        public ActionResult Modificar(string nombre, string fechaNacimiento, string cedula)
        {
            if (Session["logeado"] != null)
            {
                Socio unSocio = repoSocios.BuscarPorCi(cedula);
                Socio socioMod = null;
                string mensaje = "No se realizo Ningun cambio.";

                if (fechaNacimiento != "" && nombre != "")
                {
                    string[] fecha = fechaNacimiento.Split('-');
                    Console.WriteLine(fecha);
                    socioMod = new Socio()
                    {
                        Nombre = nombre,
                        Cedula = unSocio.Cedula,
                        FechaNac = new DateTime(Convert.ToInt32(fecha[0]), Convert.ToInt32(fecha[1]), Convert.ToInt32(fecha[2])),
                    };
                }else
                if (nombre != "" && fechaNacimiento == "")
                {
                    socioMod = new Socio()
                    {
                        Nombre = nombre,
                        Cedula = unSocio.Cedula,
                        FechaNac = unSocio.FechaNac,
                    };
                }else
                if (fechaNacimiento != "" && nombre == "")
                {
                    string[] fecha = fechaNacimiento.Split('-');
                    Console.WriteLine(fecha);
                    socioMod = new Socio()
                    {   
                        Nombre = unSocio.Nombre,
                        Cedula = unSocio.Cedula,
                        FechaNac = new DateTime(Convert.ToInt32(fecha[0]), Convert.ToInt32(fecha[1]), Convert.ToInt32(fecha[2])),
                    };
                }

                if (socioMod != null)
                {
                    bool seModifico = repoSocios.Modificacion(socioMod);
                    if (seModifico)
                    {
                        mensaje = "Se modifico correctamente.";
                    }
                }
                return RedirectToAction("Detalles", new { cedula = cedula, mensaje = mensaje });
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }

        }
    }
}