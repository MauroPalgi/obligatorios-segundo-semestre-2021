using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxiliar;
using Dominio;
using DebugConsole.;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioListadosClient cliente = new ServicioListadosClient();
            cliente.Open();
            Persona[] lista = cliente.GetAll();
            foreach (Persona p in lista)
                Console.WriteLine(p.Apellido + ", " + p.Nombre);
            cliente.Close();
            Console.ReadKey();
        }
    }
}
