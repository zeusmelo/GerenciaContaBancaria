using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciaContaBancaria
{
    internal class Banco
    {
        private bool ativa;
        private static List<Cliente> listaClientes;
        private int saldoEmConta;
        private Cliente cliente;

        public bool Ativa { get => ativa; set => ativa = value; }
        internal List<Cliente> ListaClientes { get => listaClientes; set => listaClientes = value; }
        public int SaldoEmConta { get => saldoEmConta; set => saldoEmConta = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }

        public Banco(Cliente cliente)
        {
            this.ativa = false;
            this.cliente = cliente;
            this.ListaClientes = new List<Cliente>();
        }

        public static Cliente CriarCliente()
        {
            Console.Clear();
            Console.WriteLine("SEJA BEM VINDO AO BANKAI BANK");
            Thread.Sleep(1000);

            try
            {
                Console.Clear();
                Console.WriteLine("Digite o nome do cliente: ");
                string name = Console.ReadLine();

                Console.WriteLine("Digite a idade do cliente: ");
                uint age = Convert.ToUInt16(Console.ReadLine());

                Console.WriteLine("Digite a data de nascimento do cliente: ");
                DateTime born = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Digite o endereço do cliente ");
                string adr = Console.ReadLine();

                Console.WriteLine("Digite o documento de identificação do cliente");
                string doc = Console.ReadLine();

                Console.WriteLine("Digite a renda mensal do cliente");
                int rendaMensal = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite o patrimonio do cliente");
                int patrimonio = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite o tipo de conta a ser criada [CC/CP]");
                string tipoDeConta = Console.ReadLine().ToLower();
                if (tipoDeConta != "cc" && tipoDeConta != "cp")
                {
                    throw new Exception("CONTA NÃO RECONHECIDA");
                }

                return new Cliente(name, age, born, adr, doc, rendaMensal, patrimonio, tipoDeConta);
            }
            catch (Exception e)
            {
                Uteis.MostraMsg(e.Message);
                CriarCliente();
                return null;
            }


        }

        public void AbrirConta()
        {
            Ativa = true;
            listaClientes.Add(this.cliente);
            show();
        }
        public void show()
        {
            Console.Clear();
            Console.WriteLine($"Ola, cliente {cliente.Name}. Como podemos auxilia-lo?");
            Console.WriteLine($" 1- PARA DEPOSITO \n 2- PARA SAQUE \n 3- PARA VISUALIZAR INFO. DA CONTA \n 4- PARA APAGAR CONTA");
            char opc = Console.ReadKey(true).KeyChar;
            switch ( opc )
            {
                case '1': Deposito(); break; //deposito
                case '2': Saque(); break; //saque
                case '3': InfoCliente();  break; //visualizar informações da conta
                case '4': ApagarConta();  break; //apagar conta
               
            }

        }
          public void Deposito()
        {
            Console.Clear();
            if (ativa == true)
            {
                try
                {
                    Console.WriteLine("Digite o valor a ser depositado");
                    int valor = Convert.ToInt32(Console.ReadLine());
                    if (valor <= 0)
                        throw new Exception("VALOR INVALIDO PARA DEPOSITO");
                    else {
                        SaldoEmConta += valor;
                        Uteis.MostraMsg("VALOR DEPOSITADO COM SUCESSO!");
                        show();
                    }

                }catch(Exception e)
                {
                    Uteis.MostraMsg(e.Message);
                    Deposito();
                }
                finally { show(); }
            }
            else
                Uteis.MostraMsg("USUARIO NÃO POSSUI CONTA ATIVA!");
                
        }

        public void Saque()
        {
            int valor;
            if (ativa == true) {
                
                try
                {
                  
                    Console.WriteLine("Digite o valor a ser sacado");
                     valor = Convert.ToInt32(Console.ReadLine());
                    if (valor > SaldoEmConta || valor < 0)
                        throw new Exception("VALOR SELECIONADO É MAIOR QUE SALDO EM CONTA");
                    else
                    {
                        SaldoEmConta -= valor;
                        Cliente.Patrimonio += valor;
                    }
                 }catch (Exception e)
                {
                    Uteis.MostraMsg(e.Message);
                    Saque();
                }
                
            
            } else
                Uteis.MostraMsg("USUARIO NÃO POSSUI CONTA ATIVA!");
                show();
        }  

        public void InfoCliente()
        {
            Console.Clear();
            Console.WriteLine($"NOME DO CLIENTE: {Cliente.Name}");
            Console.WriteLine($"CONTA EM FUNCIONAMENTO? {Ativa}");
            Console.WriteLine($"SALDO EM CONTA: {saldoEmConta}");
            Uteis.MostraMsg("INFORMAÇÕES ADICIONAIS EM SIGILO");
            show();
        } 

        public void ApagarConta()
        {
            if(ativa == true && saldoEmConta >0)
            {
                Console.Clear();
                Console.WriteLine("TEM CERTEZA QUE QUER APAGAR SUA CONTA? [SIM/NAO]");
                string resp = Console.ReadLine();
                if (resp == "sim")
                {
                    Console.Clear();
                    Uteis.MostraMsg("APAGANDO CONTA E FECHANDO SISTEMA");
                    Thread.Sleep(5000);
                    System.Environment.Exit(0);
                }
                else if (resp == "nao")
                    show();
                else
                    ApagarConta();
            }
        }
    }
}
