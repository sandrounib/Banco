using System;
namespace Library
{

    public class Validacao
    {
        public string Documento { get; private set; }
        Documento doc = new Documento();

        public bool ValidarCpfOuCnpj()
        {
            int opcaoPfPJ = 0;
            bool documentoValido = false;
            try
            {
                do
                {
                    System.Console.WriteLine("Consulta CPf | CNPJ");
                    System.Console.WriteLine("Digite [1] Consulta CPF | [2] Consulta CNPJ");
                    opcaoPfPJ = Int16.Parse(Console.ReadLine());
                    if (opcaoPfPJ != 1 && opcaoPfPJ != 2)
                        System.Console.WriteLine("Opção Inválida!");

                } while (opcaoPfPJ != 1 && opcaoPfPJ != 2);
                do
                {
                    if (opcaoPfPJ == 1)
                    {
                        System.Console.WriteLine("Informe o CPF: ");
                        Documento = Console.ReadLine();
                        documentoValido = doc.ValidarCpf(Documento);
                        if (!documentoValido)
                        {
                            System.Console.WriteLine("CPF Inválido!");
                        }
                        System.Console.WriteLine("CPF Válido.");
                    }
                    else
                    {
                        System.Console.WriteLine("Informe o CNPJ: ");
                        documentoValido = doc.ValidarCNPJ(Documento);
                        if (!documentoValido)
                        {
                            System.Console.WriteLine("CNPJ Inválido!");

                        }
                    }

                } while (!documentoValido);

            }
            catch (System.Exception)
            {

                System.Console.WriteLine("Vou tratar o erro depois!");
            }
            return false;
        }

    }
}