using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFServicioActividades
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioActividades" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioActividades.svc or ServicioActividades.svc.cs at the Solution Explorer and start debugging.
    public class ServicioActividades : IServicioActividades
    {
        public Actividad GetActividad(int id)
        {
            Actividad actividad = null;
            SqlDataReader dr = DALActividad.select_byId(id);
            if (dr != null && dr.Read())
            {
                actividad = cargarActividad(dr);
            }
            return actividad;
        }

        public List<Actividad> GetAll()
        {
            List<Actividad> lst = new List<Actividad>();
            SqlDataReader dr = DALActividad.select_All();
            while (dr.Read())
            {
                lst.Add(cargarActividad(dr));
            }
            return lst;

        }

        public Actividad UpdateCupoActividad(int id, int cupoActual)
        {
            // Actividad actividad = GetActividad(id);
            Actividad actividadModificada = null;
            SqlDataReader dr = DALActividad.update_byId(id, cupoActual);
            return actividadModificada;
        }

        Actividad cargarActividad(SqlDataReader dr)
        {
            Actividad a = new Actividad();
            a.CodigoAct = int.Parse(dr["CodigoAct"].ToString());
            a.Nombre = dr["NombreAct"].ToString();
            a.HoraComienzo = DateTime.Parse(dr["HoraComienzo"].ToString());
            a.CupoActual= int.Parse(dr["CupoActual"].ToString());
            a.CupoTotal = int.Parse(dr["CupoTotal"].ToString());
            a.MinEdad = int.Parse(dr["MinEdad"].ToString());
            a.MaxEdad = int.Parse(dr["MaxEdad"].ToString());
            return a;
        }
    }
}
