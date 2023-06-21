using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaContaBancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente clientes = Banco.CriarCliente();
            Banco conta = new Banco(clientes);
            conta.AbrirConta();



        }
    }
}
