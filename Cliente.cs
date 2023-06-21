using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaContaBancaria
{
    internal class Cliente : User
    {
        private int rendaMensal;
        private int patrimonio;
        private string tipoDeConta;

        public string TipoDeConta { get => tipoDeConta; set => tipoDeConta = value; }
        public int RendaMensal { get => rendaMensal; set => rendaMensal = value; }
        public int Patrimonio { get => patrimonio; set => patrimonio = value; }

        public Cliente(string name, uint age, DateTime born, string adr, string doc, int rendaMensal, int patrimonio, string tipoDeConta) : base(name, age, born, adr, doc)
        {
            name = name.Trim();
            this.rendaMensal = rendaMensal;
            this.patrimonio = patrimonio;
            this.tipoDeConta= tipoDeConta;
        }


       
    }
}
