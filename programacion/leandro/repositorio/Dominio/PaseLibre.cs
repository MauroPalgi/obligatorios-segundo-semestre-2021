using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PaseLibre: Pago
    {
        public decimal Cuota { get; set; }
        public decimal DescPrefijado { get; set; }
        public int Antiguedad { get; set; }

        public override decimal Descuento()
        {
            decimal total;
            if (Antiguedad <= 1)
            {
                total = Cuota;
            }
            else
            {
                total = Cuota - (Cuota * DescPrefijado);
            }
            return total;
        }
    }
}
