using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
    public class RepoPagos : IRepoPagos
    {
        string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=CLUBDEPORTIVO; Integrated Security=SSPI;";
        // string strCon = @"Data Source=(local)\MSSQLSERVER01; Initial Catalog=CLUBDEPORTIVO; Integrated Security=SSPI;"; // string de conexion de Mauro

        public decimal Alta(Pago obj, Socio unSocio)
        {
            decimal ret = 0;
            if (obj != null)
            {
                SqlConnection con = new SqlConnection(strCon);
                string sql1 = "insert into PAGOS(fchPago, cedula, monto) values(@fchPago, @cedula, @monto);";
                SqlCommand com = new SqlCommand(sql1, con);
                com.Parameters.AddWithValue("@fchPago", DateTime.Now);
                com.Parameters.AddWithValue("@cedula", unSocio.Cedula);
                decimal monto = CalcularMonto(obj, unSocio);
                ret = monto;
                com.Parameters.AddWithValue("@monto", monto);
                try
                {
                    con.Open();
                    int afectadas = com.ExecuteNonQuery();
                    con.Close();

                    // ret = afectadas == 1;
                }
                catch
                {
                    return ret;
                }
                finally
                {
                    if (con != null && con.State == ConnectionState.Open) con.Close();
                }
            }

            return ret;
        }

        public decimal CalcularMonto(Pago obj, Socio unS)
        {
            decimal monto = 0;
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from Configuraciones;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    if (obj is Cuponera)
                    {
                        Cuponera cuponera = obj as Cuponera;
                        Cuponera cupo = new Cuponera
                        {
                            DescPrefijado = reader.GetDecimal(1),
                            MaxActivSinDesc = reader.GetInt32(2),
                            MontoUnitActiv = reader.GetDecimal(3),
                            Actividades = cuponera.Actividades,
                        };
                        monto = cupo.Descuento();
                    }
                    else if (obj is PaseLibre)
                    {
                        PaseLibre pase = new PaseLibre
                        {
                            Cuota = reader.GetDecimal(0),
                            DescPrefijado = reader.GetDecimal(1),
                            Antiguedad = DateTime.Now.Year - unS.FechaIngreso.Year,
                        };
                        monto = pase.Descuento();
                    }
                }

                con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return monto;
        }
    }
}
