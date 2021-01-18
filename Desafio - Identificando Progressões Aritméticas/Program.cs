using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio___Identificando_Progressões_Aritméticas
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = true,polo = true;
            int num;
            do
            {                
            Console.WriteLine("Identificando Progressões Aritméticas no subconjuto de números inteiros ou digite 0 para sair:");
            Console.WriteLine("Por exemplo (1,2,3,5,6,7,9) ou 1,2,3,5,6,7,9 dessas formas com parênteses e vírgula ou sem parênteses e vírgula!!!");
            //Entrada do programa pode inserir os números conforme as instruções acima
            string resultado = Console.ReadLine();

            //Preparar string recebida para converter para números
            bool inicia = Int32.TryParse(resultado, out num);
            //Tirar os parênteses e os espaços da string
            string limpa = resultado.Replace("(","").Replace(")","").Trim();
            //Separar números pela vírgula da string, transformação em pequenas strings
            string[] cortes = limpa.Split(",");


            //Verficar se não existe uma letra entre os números 
            foreach (var item in cortes)
            {
                bool giro = Int32.TryParse(item, out num);
                if (giro == false)
                {
                    polo = false;
                    break;
                }
            }

            //Iniciar 
            if(!inicia && polo == true){
            int[] nums = new int[cortes.Length];

            //Converter para números as mini strings
            for (var i = 0; i < cortes.Length; i++)
            {
                nums[i] = Convert.ToInt32(cortes[i]);
            }

            //Tirar todos os números iguais do array
            var hash = new HashSet<int>(nums);
            nums = hash.ToArray();
            //Ordenar o array do menor para maior
            nums = nums.OrderBy(x => x).ToArray();
          
            List<int[]> arrays = new List<int[]>(); 

            //Achar todos os P.A a partir do array
            for (int i = 0; i < nums.Length; i++)
            {
                int valor = nums[i];
                int[] matriz = nums;
                //Tirar número selecionando para não ocorre conflito com aquele número
                matriz = matriz.Except(new int[]{valor}).ToArray();

                //Número mais alto do array
                int high = matriz.Max();

                List<int> stock = new List<int>();
                stock.Add(valor);
                //Começar achar as sequencias de P.A 
               for (var j = 0; j < high; j++)
               {
                   //Próximo número que deve se achado
                   int n = valor + j;
                   foreach (var item in matriz)
                   {
                       if(item == n){
                           stock.Add(item);
                           //Caso achar adicionar a razão no número é procurar o próximo P.A
                           n+=j;
                       }
                   }
                   //Caso não achar 3 números para forma uma sequencia de P.A
                   if(stock.Count < 3){
                       //Limpar o array
                       stock.Clear();
                       //Adicionar o primeiro valor no array
                       stock.Add(valor);   
                   }
                   //Caso tiver mais de 3 posições no array 
                   if(stock.Count >= 3){
                       //Adicionar o array no array principal
                        arrays.Add(stock.ToArray());
                        //Limpar o array
                        stock.Clear();
                        //Adicionar o primeiro valor no array
                        stock.Add(valor);
                    }                   
               }
            }
            //Fazer uma cópia do array principal
            int[][] copia = arrays.ToArray(); 
            List<int[]> novos = copia.ToList();

            //Tirar as sequencias repetidas do array
            foreach (var item in arrays)
            {
                int[][] itens = arrays.ToArray();
                //Tirar o item do array para não ocorre conflito
                itens = itens.Except(new int[][]{item}).ToArray();
                foreach (var one in itens)
                {
                    //Verificar se ITEM é do mesmo tamanho de ONE
                    if(item.Length == one.Length){
                        //Remove o ONE caso ele for parecido com ITEM
                        bool auth = item.SequenceEqual(one);
                        if(auth){                          
                            novos.Remove(one);
                        }
                    }else{
                        //Manipluar os arrays para verificar se não sequencias repetidas
                        int tam = one.Length;
                        int tam1 = item.Length;
                        int total = tam - tam1;
                        int som = 0;
                        for (var i = 0; i < (tam - tam1)+1; i++)
                        {
                           List<int> ast = one.ToList();
                           int init = total;
                           //Retirar os últimos números do array
                           for (var j = one.Length; init != 0; j--)
                           {
                               ast.RemoveAt(j-1);
                               init--;
                           }
                                //Retirar os primeiros números do array
                           if(som != 0){
                                for (var k = 0; k < som; k++)
                                {
                                    ast.RemoveAt(0);
                                }
                           }
                        //Retirar os números repetidos
                           bool auth = item.SequenceEqual(ast);
                            if(auth){                          
                                novos.Remove(item);
                            }
                            total--;
                            som++;
                        }
                        
                        
                    }
                }               
            }

            //Saida do identificado
            Console.WriteLine("=====================================");
            for (var i = 0; i < novos.Count; i++)
            {
                for (var j = 0; j < novos[i].Length; j++)
                {
                    //Formatação ver melhor os números
                    if (j == 0)
                    {
                        Console.Write($"({novos[i][j]}");
                    }else if(j == novos[i].Length -1){
                        Console.Write($", {novos[i][j]})");
                    }
                    else
                    {
                        Console.Write($", {novos[i][j]}");                
                    }
                }   
                Console.WriteLine();
            }
                Console.WriteLine("=====================================");

            
            }else if(polo == false){
                continue;
            }
            else{
                sair = false;
            }
            } while (sair);

        }        
    }
}
