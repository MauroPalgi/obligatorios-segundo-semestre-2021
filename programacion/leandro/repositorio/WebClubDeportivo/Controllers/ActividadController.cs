using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClubDeportivo.ServicioActividades;
using Dominio;
using Auxiliar;

namespace WebClubDeportivo.Controllers
{
    public class ActividadController : Controller
    {
        // GET: Actividad
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Actividades(string cedula)
        {
            if (Session["logeado"] != null)
            {
                ServicioActividadesClient actividades = new ServicioActividadesClient();
                actividades.Open();
                List<Actividad> listActividades = actividades.GetAll();
                actividades.Close();
                ViewBag.ListActiv = listActividades;
                ViewBag.Cedula = cedula;
                return View();
            }
            else
            {
                return View("Login");
            }
        }
        
        public ActionResult RegistroEnActividad(string MensajeRegistro)
        {
          if (Session["logeado"] != null)
            {
                if (MensajeRegistro != null)
                {
                    ViewBag.MensajeRegistro = MensajeRegistro;
                }
                return View("Actividades");
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }
        [HttpPost]
        public ActionResult RegistroEnActividad(string CodigoActividad, string CedulaSocio, string cuposDisp)
        {
                bool ok= false;
                int CodigoActInt = Int32.Parse(CodigoActividad);
                Registro unRegistro = new Registro()
                {
                    CodigoAct = CodigoActInt,
                    Cedula = CedulaSocio
                };
                /* Split para arreglar error '/' */
                string[] parts = cuposDisp.Split('/');
                int cupos = int.Parse(parts[0].ToString());

                if (cupos > 0 && !FabricaRepositorio.ObtenerRepositorioRegistro().ExisteSocioEnAct(CedulaSocio, CodigoActInt)) {
                    ok = FabricaRepositorio.ObtenerRepositorioRegistro().Alta(unRegistro);
                }

                if (ok)
                {
                    ServicioActividadesClient actividades = new ServicioActividadesClient();
                    actividades.Open();
                    int CodigoAct = Int32.Parse(CodigoActividad);
                    Actividad ActActividad = actividades.UpdateCupoActividad(CodigoAct, cupos);
                    actividades.Close();
                    return RedirectToAction("RegistroEnActividad", new { MensajeRegistro = "Se registro el socio en la actividad." });
                }
                else
                {
                    return RedirectToAction("RegistroEnActividad", new { MensajeRegistro = "No se pudo registrar socio en la actividad." });
                }
            }

        public ActionResult ListarIngresos(string cedula)
        {
            if (Session["logeado"] != null)
            {
                //Lista de Actividades WCF
                ServicioActividadesClient actividades = new ServicioActividadesClient();
                actividades.Open();
                List<Actividad> listActividades = actividades.GetAll();
                actividades.Close();

                    //array actividad 
                List<Actividad> listActividadesFiltradas = new List<Actividad>();
                List<Registro> unR = FabricaRepositorio.ObtenerRepositorioRegistro().FiltrarIngresos(cedula);//trae registro
                foreach (var r in unR)
                {
                    foreach (var a in listActividades)
                    {
                        if (a.CodigoAct == r.CodigoAct)
                        {
                            Actividad act = new Actividad()
                            {
                                CodigoAct = a.CodigoAct,
                                Nombre = a.Nombre,
                                HoraComienzo = a.HoraComienzo,
                            };
                            listActividadesFiltradas.Add(act);
                        }
                    }
                }
                ViewBag.listaActividadesFiltradas = listActividadesFiltradas;
                return View();
            }
            else
            {
                return View("~/Views/Funcionario/Login.cshtml");
            }
        }
    }
}