using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auxiliar;
using Dominio;

namespace WebClubDeportivo.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Login");
        }

        public ActionResult ExportarTexto()
        {
            // texto funcionarios
            IRepoFuncionarios repoFuncionario = Auxiliar.FabricaRepositorio.ObtenerRepositorioFuncionarios();
            repoFuncionario.ExportarTabla();

            // texto socios
            IRepoSocios repoSocios = Auxiliar.FabricaRepositorio.ObtenerRepositorioSocios();
            repoSocios.ExportarTabla();

            // texto registro
            //IRepoRegistros repoRegistros = Auxiliar.FabricaRepositorio.ObtenerRepositorioRegistro();
            //repoRegistros.ExportarTabla();

            // texto pagos
            IRepoPagos repoPagos = Auxiliar.FabricaRepositorio.ObtenerRepositorioPagos();
            repoPagos.ExportarTabla();

            return RedirectToAction("Inicio");

        }
        public ActionResult Inicio()
        {
            if (Session["logeado"] != null)
            {
                IRepoSocios repoSocios = Auxiliar.FabricaRepositorio.ObtenerRepositorioSocios();
                List<Socio> listaSocio = repoSocios.TraerTodo();
                ViewBag.listaSocios = listaSocio;
                return View();
            }
            else
            {
                return View("Login");
            }

        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string correo, string contrasenia)
        {
            Funcionario unFuncionario = new Funcionario()
            {
                Email = correo,
                Contrasenia = Funcionario.GetSHA256(contrasenia),
            };
            bool existeFuncionario = FabricaRepositorio.ObtenerRepositorioFuncionarios().BuscarFuncionario(unFuncionario.Email, unFuncionario.Contrasenia);
            // validation de todo
            if (existeFuncionario)
            {
                Session["logeado"] = true;
                return RedirectToAction("Inicio");
            }
            else
            {
                ViewBag.ErrorFunc = "El email o la contraseña no es correcta";
                return View("Login");
            }
        }
        public ActionResult AltaFuncionario(string MensajeFuncionario)
        {

            if (MensajeFuncionario != null)
            {
                ViewBag.MensajeFuncionario = MensajeFuncionario;
            }
            return View();
        }
        [HttpPost]
        public ActionResult AltaFuncionario(string email, string contrasenia)
        {
            bool valPass = Funcionario.ValidarContrasenia(contrasenia);
            if (valPass && email != "")
            {
                Funcionario unFuncionario = new Funcionario()
                {
                    Email = email,
                    Contrasenia = Funcionario.GetSHA256(contrasenia),
                };

                bool ok = FabricaRepositorio.ObtenerRepositorioFuncionarios().Alta(unFuncionario);
                if (ok)
                {
                    return RedirectToAction("AltaFuncionario", new { MensajeFuncionario = "Se registro el funcionario." });
                }
                else
                {
                    return RedirectToAction("AltaFuncionario", new { MensajeFuncionario = "No se pudo registrar el funcionario." });
                }
            }
            else
            {
                return RedirectToAction("AltaFuncionario", new { MensajeFuncionario = "No se pudo registrar el funcionario." });
            }
        }
    }
}