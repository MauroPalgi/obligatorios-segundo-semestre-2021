using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IRepoSocios : IRepositorio<Socio>
    {
        bool Baja(string cedula);
        bool VigenciaPagoSocio(string cedula);
        Socio BuscarPorCi(string cedula);
        void ActivarSocio(Socio obj);
    }   
}
