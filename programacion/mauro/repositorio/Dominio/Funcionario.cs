using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.ComponentModel;


namespace Dominio
{
    public class Funcionario
    {

        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public int Id { get; set; }

        public static bool EsTextoValido(string texto)
        {
            var r = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
            return r.Match(texto).Success ? true : false;
        }

        public static bool EsCorreoValido(string texto)
        {
            Regex rx = new Regex(
        @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.Match(texto).Success ? true : false;

        }

        public static bool ValidarContrasenia(string contrasenia)
        {
            return EsTextoValido(contrasenia);
        }

        public static string GetSHA256(string password)
        {
            SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();

        }
    }
}
