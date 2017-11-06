using System;
namespace Library{
    public class Documento{
        /// <summary>
/// Validação do CPF
/// </summary>
/// <param name="cpf">recebe o cpf em formato string</param>
/// <returns>Retorna true ou false</returns>
    public bool ValidarCpf(string cpf){
        //retira os pontos e traços
        cpf = cpf.Trim().Replace(".","").Replace("-","");

        //verifica se tem 11 digitos o paramentro passado, se não tiver retornar falso
        if (cpf.Length != 11)
            return false;
        
        //verifica se o cpf digitado não possui a sequencia de números informada abaixo
        if (cpf == "00000000000" || cpf == "11111111111" || cpf =="22222222222"
         || cpf == "33333333333" || cpf == "44444444444" || cpf == "5555555555"
         || cpf == "66666666666" || cpf == "77777777777" || cpf == "8888888888" || cpf == "999999999"){
             return false;            
        }

        //cria array de inteiro para validar o primeiro digito
        int[] multiplicador1 = new int[9]{10,9,8,7,6,5,4,3,2};
        int[]multiplicador2 = new int[10]{11,10,9,8,7,6,5,4,3,2};

        //criação da variavel TempCpf para armazenar os 9 primeiros digitos que serão passados
        string tempCpf, digito;
        int soma = 0, resto = 0;

        //armazena na variável tempCpf os 9 primeiros dgitos passado como parametro, começando do zero indo até o nono
        tempCpf = cpf.Substring(0,9);

        //percorre o array MULTIPLICANDO os numeros do cpf digitado com a posição do array e soma
        for (int i = 0; i < 9; i++){
            soma += Convert.ToInt16(tempCpf[i].ToString()) * multiplicador1[i];
        }
        //armazena o resto da divisão da soma por 11
        resto = soma % 11;

        //caso o resto for menor que 2, atribuir 0(zero), caso contrario atribuir 11 - resto para obter o primeiro digito
        if (resto < 2)
            resto = 0;        
        else
            resto = 11 - resto;

        //atribui a digito o resto
        digito = resto.ToString();
        //concatena o que guardamos em tempCpf com o primeiro digito
        tempCpf = tempCpf + digito;

        //zera a variavel soma iremos usá-la agora para pegar o segundo digito
        soma = 0;

        //percorre o tempCpf concatenando e multiplicando pelos valores do array
        for (int i = 0; i < 10; i++)
        soma += Convert.ToInt16(tempCpf[i].ToString()) * multiplicador2[i];

        //armazena o resto da divisão da soma por 11
        resto = soma % 11;

        //caso o resto for menor que 2, atribuir 0(zero), caso contrario atribuir 11 - resto para obter o segundo digto
        if(resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        
         //atribui a digito o resto
        digito = digito + resto.ToString();

        //verifica se os últimos 2 digitos obtidos são iguais aos do cpf passado
        return cpf.EndsWith(digito);         
    }

    //*********************************************************************************************************** */
     /// <summary>
        /// Validação de CNPJ
        /// </summary>
        /// <param name="cnpj">Recebe como parametro de entrada um string com o valor do cnpj a ser validado</param>
        /// <returns>Retorna true ou false</returns>
        public bool ValidarCNPJ(string cnpj){

            //Retira os caracteres especiais do CNPJ
            cnpj = cnpj.Trim().Replace(".", "").Replace("-","");

            //Verifica se o CNPJ possui 14 caracteres
            if (cnpj.Length != 14){
                return false;
            }

            //Declara um array com valores a serem multiplicados para encontrar o primeiro caractere
            int[] multiplicador1 = new int[12]{5,4,3,2,9,8,7,6,5,4,3,2};
            //Declara um array com valores a serem multiplicados para encontrar o segundo caractere
            int[] multiplicador2 = new int[13]{6,5,4,3,2,9,8,7,6,5,4,3,2};


            string tempCnpj, digito;
            int soma =0,resto =0;

            //Atribui a variavel os 12 primeiros caracteres do cnpj
            tempCnpj = cnpj.Substring(0,12);

            //Percorre os 12 caracteres e otem a soma
            for (int i = 0; i < 12; i++)
             {
                 //multiplica o valor do array na poição i ao caracter na posição i
                 soma += Convert.ToInt16(tempCnpj[i].ToString())  * multiplicador1[i];
             }

            //obtêm o resto da divisão da soma por 11
            resto = soma % 11;

            //Caso o resto seja menor que 2 atribui 0 e caso seja maior atribui ao valor 11 - resto
            if(resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //Atribui o valor do resto a variável digito
            digito = resto.ToString();
            //Concatena o cnpj com 12 caracteres ao resto para validar o segundo dígito
            tempCnpj = tempCnpj + digito;

            soma = 0;
            //Percorre os 13 caracteres e otem a soma
            for (int i = 0; i < 13; i++)
            {
                 //multiplica o valor do array na poição i ao caracter na posição i
                 soma += Convert.ToInt16(tempCnpj[i].ToString())  * multiplicador2[i];
            }

            //Caso o resto seja menor que 2 atribui 0 e caso seja maior atribui ao valor 11 - resto
            resto = soma % 11;

            //Caso o resto seja menor que 2 atribui 0 e caso seja maior atribui ao valor 11 - resto
            if(resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //Atribui o valor do resto a variável digito
            digito = resto.ToString();

            //Verifica se o digito é igual aos do cnpj, caso seja retorna true caso contrário retorna false
            return cnpj.EndsWith(digito);
        }
    }

}



