using System;
using System.Collections.Generic;

namespace Desafio___Geração_de_Fatores_Primos
{
    class Program
    {
        static void Main(string[] args)
        {
            bool conti = false;
            int num,resultado,multiplicador = 0;
            do
            {
                //Entrada do número para fatoração 
                Console.WriteLine("Digite um número positivo para fatoração ou digite 0 para sair:");
                string entrada = Console.ReadLine();
                bool test = Int32.TryParse(entrada, out num);
                List<int> fatores = new List<int>();

                //Verificar se é um número digitado
                if(test == true && Convert.ToInt32(entrada) != 0){

                resultado = Convert.ToInt32(entrada);
                while (resultado != 1)
                {
                    //Verificar se é par ou impar
                    if((resultado % 2) == 0){
                        //Se for par é divisivel por 2
                        resultado = resultado / 2;
                        //Adicionar o número que foi usado para fatoração
                        fatores.Add(2);
                    }else {
                        //Caso de impar o número do multiplicador é adicionar 2 a cada rodada até sair um número inteiro
                        double verify = resultado;
                       multiplicador = 1;
                       bool run = false;
                       int saida = 0;

                       while (run == false)
                       {
                           verify = resultado;
                           //Adicionar dois a cada rodada
                           multiplicador+=2;
                           //Dividi o número pelo multiplicador
                           verify = verify / multiplicador;
                           //Verificar se o número ficou inteiro denovo
                           run = Int32.TryParse(verify.ToString(), out saida);
                       }
                       resultado = Convert.ToInt32(verify);
                       //Adicionar o número que foi usado para fatoração
                       fatores.Add(multiplicador);
                    }
                }
                //Saida do resultado da fatoração
                Console.WriteLine("===============================================");
                Console.WriteLine("Resultado da sua fatoração:");
                Console.Write($"{entrada} =");
                for (var i = 0; i < fatores.Count; i++)
                {   
                    if(i != fatores.Count -1){
                      Console.Write($" {fatores[i]} x");
                    }else{
                     Console.Write($" {fatores[i]};");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("===============================================");
            }else if(test == false){
                //Caso não for um número digitado na entrada
                Console.WriteLine("Valor incorreto coloque outro valor!!");
            }
            else{
                //Para sair do console quando apertar 0
                conti = (Convert.ToInt32(entrada) == 0)? true : false;
            }
            } while (!conti);
            
        }
    }
}
