using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Desafios_do_Dojo_Puzzles___Intelitrader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Amigo> amigos = new List<Amigo>();
            int opcao;
            //Lista de amigos com alguns dados já inseridos
            amigos.Add( new Amigo { Nome = "Pedro Cabral",  Latitude = -22.67484735,Longitude = -49.24072266}); //São Paulo
            amigos.Add( new Amigo { Nome = "Sonia Braz",  Latitude = -18.98422042,Longitude = -41.99798584}); // Minas
            amigos.Add( new Amigo { Nome = "Erika Jorgino",  Latitude = 50.95842672,Longitude = -1.88964844}); //Reino Unido
            amigos.Add( new Amigo { Nome = "Kaique Kinoa",  Latitude = -9.40571004,Longitude = -70.0378418}); // Acre
            amigos.Add( new Amigo { Nome = "Gustavo Caminhos",  Latitude = 40.01078714,Longitude = -76.22314453}); // USA
           // amigos.Add( new Amigo { Nome = "Henrique",  Latitude = -22.8859288,Longitude = -48.6153066}); // USA

            bool sair = true;
            do
            {
                //Quadro de opções para o usuário
            Console.WriteLine("Escolha uma opção para continuar.");
            Console.WriteLine("Digite sua 1 para adicionar um amigo:");
            Console.WriteLine("Digite sua 2 ver os amigos mais próximos:");
            Console.WriteLine("Digite sua 0 para sair:");

            string entrada = Console.ReadLine();

            //Switch para saber qual opção o usuário seleciono: 1 Criar um amgio e 2 Calcular distância entre os amigos
            bool resultado = Int32.TryParse(entrada, out opcao);
            if(resultado == true){
                switch (opcao)
                {
                    //Adicionar novo amigo na lista
                    case 1:
                        Amigo novo = new Amigo();
                        Console.WriteLine("Digite o nome do seu amigo:");
                        novo.Nome = Console.ReadLine();
                        bool reul = true;
                        double do1, do2;
                        //Verificar se é um número digitado na latitude pelo usuário
                        do
                        {
                        Console.WriteLine("Digite a latitude do seu amigo:");
                        string entre = Console.ReadLine();
                        reul = Double.TryParse(entre, out do1 );
                        novo.Latitude = Convert.ToDouble(entre,new CultureInfo("en-US"));
                        } while (!reul);

                        //Verificar se é um número digitado na longitude pelo usuário
                        do
                        {
                        Console.WriteLine("Digite a longitude do seu amigo:");
                        string entre = Console.ReadLine();
                        reul = Double.TryParse(entre, out do2);
                        novo.Longitude = Convert.ToDouble(entre.ToString(),new CultureInfo("en-US"));
                        } while (!reul);

                        amigos.Add(novo);
                    break;
                    //Calcular distância entre amigos
                        case 2:
                        foreach (var item in amigos)
                        {
                            Amigo[] arr = new Amigo[amigos.Count];
                            arr = amigos.ToArray();
                            //Tirar o amigo do array, oque está sendo calculado para saber quais amigos estão mais perto
                            arr = arr.Except(new Amigo[]{item}).ToArray();
                            Console.WriteLine($"Todos os amigos perto de {item.Nome}");
                            //Verificar a distância entre um amigo e outros 
                            foreach (var one in arr)
                            {
                                double distance = Distancia(item.Latitude,item.Longitude,one.Latitude,one.Longitude);
                                one.Distancia = Math.Round(distance);
                            }
                            //Ordenar o array para mais perto até o mais longe
                             arr = arr.OrderBy(A => A.Distancia).ToArray();
                            for (var i = 0; i < 3; i++)
                            {
                                Console.WriteLine($"Nome {arr[i].Nome} distancia {arr[i].Distancia} KM");
                            }
                            Console.WriteLine();
                        }
                        break;
                        //Em caso de opção inválida
                        default:
                        if(opcao != 0){
                        Console.WriteLine("Opção inválida!!!");
                        }else if(opcao == 0){
                            sair = false;
                        }
                        break;
                }
            }
            } while (sair);
        }
        //Método que retonar um double, calcular a distância entre dois pontos e retonar quantos KM está de distância
        public static double Distancia(double lat1, double lon1, double lat2, double lon2)
        {
            //Calculo para pegar o ângulo para multiplicação
            double deg2radMultiplier = Math.PI / 180;

            lat1 = lat1 * deg2radMultiplier;
            //Latitude do ponto A 
            lon1 = lon1 * deg2radMultiplier;
            //Longitude do ponto A
            lat2 = lat2 * deg2radMultiplier;
            //Latitude do ponto B
            lon2 = lon2 * deg2radMultiplier;
            //Longitude do ponto B

            double radius = 6378.137; 
            //Calcular a distancia da longitude
            double dlon = lon2 - lon1;
            //Calcular distância usado Seno,Cosseno e tangente e devolver em KM do ponto A até o ponto B
            double distance = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(dlon)) * radius;

            return distance;
        }
    }
}


