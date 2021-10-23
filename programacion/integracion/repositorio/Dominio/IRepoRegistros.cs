using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IRepoRegistros: IRepositorio<Registro>
    {
        bool ExisteSocioEnAct(string cedula, int codAct);
        List<Registro> FiltrarIngresos(string cedula);
    }
}
