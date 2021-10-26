using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorios;

namespace Auxiliar
{
    public class FabricaRepositorio
    {
        public static IRepoFuncionarios ObtenerRepositorioFuncionarios()
        {
            return new RepoFuncionarios();
        }

       public static IRepoSocios ObtenerRepositorioSocios()
        {
            return new RepoSocios();
        }

        public static IRepoPagos ObtenerRepositorioPagos()
        {
            return new RepoPagos();
        }

        public static IRepoRegistros ObtenerRepositorioRegistro()
        {
            return new RepoRegistros();
        }
    }
}
