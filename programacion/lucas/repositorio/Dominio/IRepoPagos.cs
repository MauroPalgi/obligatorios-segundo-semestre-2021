using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IRepoPagos
    {
        decimal Alta(Pago obj, Socio documento);
        // poner logica pagos
        void ExportarTabla();

    }
}
