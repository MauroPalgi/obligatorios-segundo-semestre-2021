using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Pago
    {
        public DateTime fchPago { get; set; }

        public abstract decimal Descuento();
    }
}
