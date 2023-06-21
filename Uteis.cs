using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaContaBancaria
{
    internal static class Uteis
    {

        public static void MostraMsg(string msg)
        {

            Console.WriteLine($"{msg}");
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey(true);
        } 

    }
}
