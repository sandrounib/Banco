using System;
using System.IO;
namespace Library
{
    public class Cliente
    {
        public string NomeCliente { get; private set; }
        public string EmailCliente { get; private set; }
        public string NumeroAgencia { get; private set; }
        public string NomeBanco { get; set; }

        public void CadastrarCliente()
        {
            Validacao val = new Validacao();
            val.ValidarCpfOuCnpj();
            
            System.Console.WriteLine("Cadastro do Cliente - Informe os dados abaixo: ");
            System.Console.WriteLine("Nome: ");
            this.NomeCliente = Console.ReadLine();
            System.Console.WriteLine("E-mail: ");
            this.EmailCliente = Console.ReadLine();
            System.Console.WriteLine("Número Agência:");
            this.NumeroAgencia = Console.ReadLine();
            System.Console.WriteLine("Nome Banco: ");
            this.NomeBanco = Console.ReadLine();            

            //grava informações digitadas em um arquivo texto
            GravarDados();
           
        }
        public void GravarDados(){
            StreamWriter sw = new StreamWriter("clientes.txt", true);
            sw.WriteLine(NomeCliente + ";" + EmailCliente + ";" + NumeroAgencia + ";" + NomeBanco);
            sw.Close();
            //informa aos usuários que o cliente foi salvo com sucesso.
            System.Console.WriteLine("Cliente " + this.NomeCliente + " Cadastrado com Sucesso!");
        }
        /*
         static bool VerificaClienteCadastrado(string codigoCliente){
            try
            {
                //Verifica se arquivo existe
                if (!File.Exists("clientes.txt"))
                {
                    return false;
                }
                //Caso arquivo exista obtem todos os dados do arquivo
                string[] clientes = File.ReadAllLines("clientes.txt");
                string[] arraycliente;
                //percorre o array de cliente
                foreach (var cliente in clientes)
                {
                     //Split cria um array e atribui o mesmo a váriavel arraycliente
                    arraycliente = cliente.Split(";");
                    //verifica se o produto já foi cadastrado
                    if (arraycliente[0] == codigoCliente)
                    {
                        //Caso exista retorna true
                        return true;
                    }
                }
                
                //Caso não exista retorna false
                return false;
            }
            catch (System.Exception e)
            {
                //Caso ocorra algum erro salva em um arquivo de erros
                //GravarErro("VerificaClienteCadastrado",e.Message );
                throw;
            }
            
        }
          */   
        
            

    }
}
