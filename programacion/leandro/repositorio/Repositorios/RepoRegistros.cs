using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Repositorios
{
    public class RepoRegistros : IRepoRegistros
    {
        // string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=CLUBDEPORTIVO; Integrated Security=SSPI;";
        string strCon = @"Data Source=(local)\MSSQLSERVER01; Initial Catalog=CLUBDEPORTIVO; Integrated Security=SSPI;"; // string de conexion de Mauro
        public bool Alta(Registro obj)
        {
            bool ret = false;
            if (obj != null)
            {
                SqlConnection con = new SqlConnection(strCon);
                string sql1 = "insert into INGRESOACT(CodigoAct, cedula) values(@CodigoAct, @cedula);";
                SqlCommand com = new SqlCommand(sql1, con);
                com.Parameters.AddWithValue("@CodigoAct", obj.CodigoAct);
                com.Parameters.AddWithValue("@cedula", obj.Cedula);
                try
                {
                    con.Open();
                    int afectadas = com.ExecuteNonQuery();
                    con.Close();

                    ret = afectadas == 1;
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

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Registro BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteSocioEnAct(string cedula, int codAct)
        {
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from INGRESOACT where cedula=@cedula AND CodigoAct=@CodigoAct;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@cedula", cedula);
            com.Parameters.AddWithValue("@CodigoAct", codAct);
            bool ret = false;
            try
            {
                con.Open();
                int afectadas = com.ExecuteNonQuery();
                con.Close();

                ret = afectadas == 1;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return ret;
        }
        public List<Registro> FiltrarIngresos(string cedula)
        {
            List<Registro> unR = new List<Registro>();
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select CodigoAct from INGRESOACT where cedula=@cedula";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@cedula", cedula);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        unR.Add(new Registro()
                        {
                            CodigoAct = reader.GetInt32(0),
                            Cedula = cedula,
                        });
                    }
                }
                con.Close();

            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return unR;
        }

        public void ExportarTabla()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from Registro";
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    using (StreamWriter file = new StreamWriter(filePath + @"\funcionarios.txt", false))
                    {
                        while (reader.Read())
                        {
                            file.WriteLine(reader.GetDecimal(0) + "\t |" + reader.GetString(1) + "\t |" + reader.GetString(2));
                        }
                    }

                }

                con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

        }

        public bool Modificacion(Registro obj)
        {
            throw new NotImplementedException();
        }

        public List<Registro> TraerTodo()
        {
            throw new NotImplementedException();
        }

    }
}
