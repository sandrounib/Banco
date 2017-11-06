using System;
using System.IO;
namespace Library{
    public class LogErro{

        private string Metodo { get; set; }
        private string Mensagem { get; set; }

        public LogErro(){

        }
        
        public LogErro(string metodo,string mensagem){
            this.Metodo = metodo;   
            this.Mensagem= mensagem;
            SalvarLogErro();
        }

        private void SalvarLogErro(){
            try{
                System.Console.WriteLine("Ocorreu um erro - Contate o Administrador");
                StreamWriter sw = new StreamWriter("LogErro.txt",true);
                sw.WriteLine("Metodo " + this.Metodo + "- erro: " + this.Mensagem);
                sw.WriteLine(DateTime.Now + " - " + Metodo + " - " + this.Mensagem);
                sw.Close();        
                
            }
            catch (System.Exception){
                
                Console.WriteLine("Ocorreu um erro - Contacte o Administrador");
            }            
        }
    }
}