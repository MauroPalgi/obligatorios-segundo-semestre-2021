using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuponera: Pago
    {
        public int Actividades { get; set; }
        public decimal MontoUnitActiv { get; set; }
        public int MaxActivSinDesc { get; set; }
        public decimal DescPrefijado { get; set; }

        public bool LimiteActividades()
        {
            return Actividades > 7 && Actividades < 61;
        }

        public override decimal Descuento()
        {
            decimal total;
            if (Actividades <= MaxActivSinDesc)
            {
                total = Actividades * MontoUnitActiv;
            }
            else
            {
                total = Actividades * MontoUnitActiv - (MontoUnitActiv * Actividades * DescPrefijado);
            }
            return total;
        }
    }
}
