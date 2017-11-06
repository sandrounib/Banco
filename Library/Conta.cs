using System;
namespace Library
{
    public class Conta
    {
        public string Banco { get; private set; }
        public string Agencia { get; private set; }
        public string NumeroDaConta { get; private set; }
        public double Saldo { get; private set; }

        Documento doc = new Documento();
        public void Sacar()
        {
            try
            {
                bool documentoValido = false;
                do
                {
                    string cpf;
                    System.Console.WriteLine("Informe o CPF ");
                    cpf = Console.ReadLine();
                    documentoValido = doc.ValidarCpf(cpf);
                    if (!documentoValido)
                        System.Console.WriteLine("Cpf Inválido");                    
                } while (documentoValido == false);

                double valor = 0;
                System.Console.WriteLine("Valor à Sacar ");
                valor = Convert.ToDouble(Console.ReadLine());
                bool valorNegativo = (valor < 0);
                bool podeSacar = (valor <= this.Saldo) && (valor >= 0);
                if (valorNegativo)
                {
                    throw new Exception("Valor Negativo informado.");
                }
                else if (podeSacar)
                {
                    this.Saldo -= valor;
                    System.Console.WriteLine("Saque realizado com sucesso | " + "Saldo atual R$ " + MeuSaldo());

                }
                else
                {
                    System.Console.WriteLine("Saldo insuficiente!");
                    System.Console.WriteLine("Saldo atual R$ " + MeuSaldo());
                    Depositar();

                }
            }
            catch (System.Exception e)
            {
                LogErro log = new LogErro("Sacar", e.Message);

            }

        }
        public double MeuSaldo()
        {
            return this.Saldo;
        }

        public void Depositar()
        {
            bool documentoValido = false;
            try
            {
                do
                {
                    string cpf = "";
                    System.Console.WriteLine("Informe o CPF ");
                    cpf = Console.ReadLine();
                    documentoValido = doc.ValidarCpf(cpf);
                    if (!documentoValido)
                        System.Console.WriteLine("CPF Inválido!");
                } while (documentoValido == false);
            }
            catch (System.Exception e)
            {
                LogErro log = new LogErro("Depositar", e.Message);

            }

            double valor;
            System.Console.WriteLine("Valor à Depositar ");
            valor = Convert.ToDouble(Console.ReadLine());
            this.Saldo += valor;
            System.Console.WriteLine("Depósito realizado com sucesso!");
            System.Console.WriteLine("Saldo atual " + MeuSaldo());
        }
        public void ObterSaldo()
        {
            bool documentoValido = false;
            try
            {
                do
                {
                    string cpf = "";
                    System.Console.WriteLine("Informe o CPF ");
                    cpf = Console.ReadLine();
                    documentoValido = doc.ValidarCpf(cpf);
                    if (!documentoValido)
                        System.Console.WriteLine("CPF Inválido! ");

                } while (documentoValido == false);
                System.Console.WriteLine("Saldo atual R$ " + MeuSaldo());
            }
            catch (System.Exception e)
            {

                LogErro log = new LogErro("ObterSaldo", e.Message);
            }
        }
        public void Transferir(double valor, Conta destino)
        {
            //saca de mim mesmo/tira do meu saldo o valor   obs. poderia usar o metodo saca pois está redudante devidoeu ter o metodo Sacar, mas, tá dando erro ao chamar ex. this.Sacar(valor);
            this.Saldo -= valor; //this sou eu, onde o método está sendo invocado
            //vou depositar, então pega a conta de destino e adiciona nela o valor.   Outro jeito aqui seria destino.Deposita(valor)           
            destino.Saldo += valor;
            //destino.Depositar(valor);
        }


    }

}