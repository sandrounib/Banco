using System;
using Library;

namespace Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {  
                Cliente cli = new Cliente(); 
                Conta conta = new Conta();          
                
                int opcao = 0;
                do
                {
                    System.Console.WriteLine("Informe a opção: ");
                    System.Console.WriteLine("1 - Cadastrar Cliente ");
                    System.Console.WriteLine("2 - Depositar");
                    System.Console.WriteLine("3 - Sacar ");                     
                    System.Console.WriteLine("4 - Obter Saldo ");
                    System.Console.WriteLine("5 - Sair ");                    
                    opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1 :                        
                            cli.CadastrarCliente();
                            break;

                        case 2 :                        
                            conta.Depositar();                                                 
                            break;

                        case 3 :
                            conta.Sacar();
                            break;

                        case 4 :
                            conta.ObterSaldo();
                            break;
                        //case 5 :
                        //    conta.Transferir();
                        //    break;
                        case 5 :
                        System.Console.WriteLine("Deseja realmente sair? ");
                            string sair = Console.ReadLine();
                            if (sair.ToLower().Contains("s"))
                                Environment.Exit(0);
                            else if (sair.ToLower().Contains("n"))
                            {
                                opcao = 0;
                                System.Console.WriteLine("Opção inválida!");
                            }
                            else
                            {
                                opcao = -0;
                            }
                            break;
                        default:
                            System.Console.WriteLine("Opção inválida");                          
                            break;
                    }                    
                     
                } while (opcao != 5);
            }
            catch (System.Exception e)
            {
                
                LogErro log = new LogErro("Main ",e.Message);
            }            
           
        }
    }
}
