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
    public class RepoSocios : IRepoSocios
    {
        // string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=CLUBDEPORTIVO; Integrated Security=SSPI;";
        string strCon = @"Data Source=(local)\MSSQLSERVER01; Initial Catalog=CLUBDEPORTIVO; Integrated Security=SSPI;"; // string de conexion de Mauro
        public bool Alta(Socio obj)
        {
            bool NombreValidacion = Socio.ValidarNombre(obj.Nombre);
            bool CIValidacion = Socio.ValidarCedula(obj.Cedula);
            bool FchValidacion = Socio.ValidarFechaNac(obj.FechaNac);
            bool ret = false;
            if (obj != null && CIValidacion && NombreValidacion && FchValidacion)
            {
                SqlConnection con = new SqlConnection(strCon);
                string sql1 = "insert into SOCIO(nombre, cedula, fechaNac, fechaIngreso, activo) values(@nombre, @cedula, @fechaNac, @fechaIngreso, @activo);";
                SqlCommand com = new SqlCommand(sql1, con);

                com.Parameters.AddWithValue("@nombre", obj.Nombre.Trim());
                com.Parameters.AddWithValue("@cedula", obj.Cedula);
                com.Parameters.AddWithValue("@fechaNac", obj.FechaNac);
                com.Parameters.AddWithValue("@fechaIngreso", DateTime.Now);
                com.Parameters.AddWithValue("@activo", 1);
                try
                {
                    con.Open();
                    int afectadas = com.ExecuteNonQuery();
                    con.Close();

                    ret = afectadas == 1;
                }
                catch
                {
                    throw;
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
        public bool Baja(string cedula)
        {
            bool ret = false;

            SqlConnection con = new SqlConnection(strCon);
            string sql = "update SOCIO set activo=0 where cedula=@cedula;";

            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@cedula", cedula);
            SqlTransaction tran = null;

            try
            {
                con.Open();
                int afectadas = com.ExecuteNonQuery();
                con.Close();

                ret = afectadas == 1;
            }
            catch (Exception ex)
            {
                if (tran != null) tran.Rollback();
                //throw;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }


            return ret;
        }

        public Socio BuscarPorId(int id)
        {
            Socio unS = null;

            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Socio where Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    unS = new Socio
                    {
                        Nombre = reader.GetString(0),
                        Cedula = reader.GetString(1),
                        FechaNac = reader.GetDateTime(2),
                        FechaIngreso = reader.GetDateTime(3),
                    };
                }

                con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return unS;
        }
        public void ActivarSocio(Socio obj)
        {
            SqlConnection con = new SqlConnection(strCon);

            string sql = "update SOCIO set activo=@activo where cedula=@cedula;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@cedula", obj.Cedula);
            com.Parameters.AddWithValue("@activo", 1);
            try
            {
                con.Open();
                int afectadas = com.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }
        public bool Modificacion(Socio obj)
        {
            bool ret = false;
            SqlConnection con = new SqlConnection(strCon);

            string sql = "update SOCIO set nombre=@nombre, fechaNac=@fechaNac where cedula=@cedula;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@nombre", obj.Nombre);
            com.Parameters.AddWithValue("@fechaNac", obj.FechaNac);
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
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return ret;
        }

        public Socio BuscarPorCi(string cedula)
        {
            Socio unS = null;
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from Socio where cedula=@cedula;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@cedula", cedula);


            if (cedula != null)
            {
                try
                {
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();

                    if (reader.Read())
                    {
                        unS = new Socio
                        {
                            Nombre = reader.GetString(1),
                            Cedula = reader.GetString(2),
                            FechaNac = reader.GetDateTime(3),
                            FechaIngreso = reader.GetDateTime(4),
                            Activo = reader.GetBoolean(5),
                        };
                    }

                    con.Close();
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }

            return unS;
        }
        public bool VigenciaPagoSocio(string cedula)
        {
            bool ret = false;

            SqlConnection con = new SqlConnection(strCon);

            string sql = "select vigencia from PAGOS where cedula=@cedula;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@cedula", cedula);
            DateTime fechaVigencia;
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    fechaVigencia = reader.GetDateTime(0);
                    ret = (fechaVigencia.Month == DateTime.Now.Month) && (fechaVigencia.Year == DateTime.Now.Year);
                }

                con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return ret;
        }
        public void ExportarTabla()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from Socio";
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    using (StreamWriter file = new StreamWriter(filePath + @"\socios.txt", false))
                    {

                        while (reader.Read())
                        {
                            file.WriteLine(reader.GetDecimal(0) + "\t |" + reader.GetString(1) + "\t |" + reader.GetString(2) + "\t |" + reader.GetDateTime(3) + "\t |" + reader.GetDateTime(4) + "\t |" + reader.GetBoolean(5));
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
        public List<Socio> TraerTodo()
        {
            List<Socio> socios = new List<Socio>();
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from SOCIO;";
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Socio unSocio = new Socio
                    {
                        Nombre = reader.GetString(1),
                        Cedula = reader.GetString(2),
                        FechaNac = reader.GetDateTime(3),
                        FechaIngreso = reader.GetDateTime(4),
                        Activo = reader.GetBoolean(5),
                    };
                    socios.Add(unSocio);
                }
                socios = socios.OrderByDescending(s => s.Nombre).ThenBy(s => s.Cedula).ToList();
                con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return socios;
        }
    }
}
