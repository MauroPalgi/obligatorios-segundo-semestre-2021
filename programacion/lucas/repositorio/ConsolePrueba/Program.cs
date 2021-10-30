using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePrueba.ServicioActividades;
using Auxiliar;
using Dominio;

namespace ConsolePrueba
{
    class Program
    {
        static void Main(string[] args)
        {

            Funcionario unFuncionario = new Funcionario()
            {
                Email = "admin@admin.com",
                Contrasenia = Funcionario.GetSHA256("Admin123"),
            };
            bool ok = FabricaRepositorio.ObtenerRepositorioFuncionarios().Alta(unFuncionario);
            bool existeCorreo = FabricaRepositorio.ObtenerRepositorioFuncionarios().BuscarPorCorreo("admin@admin.com");
            Console.WriteLine("existe correo?" + existeCorreo);
            FabricaRepositorio.ObtenerRepositorioFuncionarios().ExportarTabla();
            Console.ReadLine();
;
        }
    }
}
