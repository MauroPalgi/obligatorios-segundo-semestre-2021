using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Socio : IComparable<Socio>
    {
        //public int IDSocio { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }

        public static bool ValidarCedula(string cedula)
        {
            return cedula.Length >= 7 && cedula.Length <= 9;
        }

        public static bool ValidarNombre(string nombre)
        {
            bool exito = false;
            if (nombre.Length >= 6)
            {
                for (int i = 0; i < nombre.Length; i++)
                {
                    if (char.IsLetter(nombre, i) || char.IsWhiteSpace(nombre, i))
                    {
                        exito = true;
                    }
                }
            }
            return exito;
        }
        public static bool ValidarFechaNac(DateTime fechaNac)
        {
            bool exito = false;
            DateTime fechaActual = DateTime.Now;
            if( (fechaActual.Year - fechaNac.Year) > 3 && (fechaActual.Year - fechaNac.Year) < 90)
            {
                exito = true;
            }
            return exito;
        }

        public int CompareTo(Socio other)
        {
            Socio unS = other as Socio;
            int orden = Nombre.CompareTo(unS.Nombre);
            if (orden == 0)
            {
                orden = Cedula.CompareTo(unS.Cedula);
            }
            return orden;
        }
    }
}
