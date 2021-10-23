using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public interface IRepoFuncionarios : IRepositorio<Funcionario>
    {      
        bool BuscarFuncionario(string correo, string contrasenia);
    }
}
