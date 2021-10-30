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
    public class RepoFuncionarios : IRepoFuncionarios
    {
        string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=CLUBDEPORTIVO; Integrated Security=SSPI;";
        // string strCon = @"Data Source=(local)\MSSQLSERVER01; Initial Catalog=CLUBDEPORTIVO; Integrated Security=SSPI;"; // string de conexion de Mauro
        public bool Alta(Funcionario obj)
        {
            bool ret = false;
            bool ValidarCon = Funcionario.ValidarContrasenia(obj.Contrasenia);
            bool ValidarEmail = Funcionario.EsCorreoValido(obj.Email);
            if (!BuscarPorCorreo(obj.Email))
            {
                if (obj != null && ValidarCon && ValidarEmail)
                {
                    SqlConnection con = new SqlConnection(strCon);
                    string sql1 = "insert into FUNCIONARIO(email, contrasena) values(@email, @contrasena);";
                    SqlCommand com = new SqlCommand(sql1, con);
                    com.Parameters.AddWithValue("@email", obj.Email);
                    com.Parameters.AddWithValue("@contrasena", obj.Contrasenia);

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

            }
            return ret;
        }
        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public bool BuscarFuncionario(string correo, string contrasenia)
        {
            Funcionario func = null;
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from FUNCIONARIO where email=@correo;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@correo", correo);
            bool ret = false;
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    func = new Funcionario
                    {
                        Email = reader.GetString(1),
                        Contrasenia = reader.GetString(2),
                    };
                }
                if (func != null && func.Contrasenia == contrasenia)
                    ret = true;
                con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return ret;
        }

        public Funcionario BuscarPorId(int id)
        {
            Funcionario func = null;
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from Funcionario where Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    func = new Funcionario
                    {
                        Id = reader.GetInt32(0),
                        Email = reader.GetString(1),
                        Contrasenia = reader.GetString(2),
                    };
                }

                con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return func;

        }

        public bool BuscarPorCorreo(string correo)
        {
            bool respuesta = false;
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from Funcionario where email=@email;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@email", correo);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        respuesta = true;
                    }
                }

                con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return respuesta;

        }

        public void ExportarTabla()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SqlConnection con = new SqlConnection(strCon);
            string sql = "select * from Funcionario";
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


        public bool Modificacion(Funcionario obj)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
