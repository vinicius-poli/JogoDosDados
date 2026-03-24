using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;

        while (true)
        {
            int posicaoUsuario = 0;
            int posicaoComputador = 0;

            bool jogoEmAndamento = true;

            while (jogoEmAndamento)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Jogo dos Dados");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Rodada do Usuário");
                Console.WriteLine("----------------------------------");

                Console.Write("Pressione ENTER para lançar o dado...");
                Console.ReadLine();

                int resultadoUsuario = RandomNumberGenerator.GetInt32(1, 7);

                Console.WriteLine($"Resultado: {resultadoUsuario}");
                posicaoUsuario += resultadoUsuario;

                Console.WriteLine($"Posição do jogador: {posicaoUsuario} de {limiteLinhaChegada}");
                Console.WriteLine("");

                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15 || posicaoUsuario == 25)
                {
                    Console.WriteLine($"\nEVENTO: Avanço de 3 casas!");
                    posicaoUsuario += 3;

                    Console.WriteLine($"\nVocê está na posição: {posicaoUsuario} de {limiteLinhaChegada}");
                    Console.WriteLine("");
                }

                else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                {
                    Console.WriteLine($"\nEVENTO: Recuo de 2 casas");
                    posicaoUsuario -= 2;

                    Console.WriteLine($"\nVocê está na posição: {posicaoUsuario} de {limiteLinhaChegada}");
                }

                if (posicaoUsuario >= limiteLinhaChegada)
                {
                    Console.WriteLine("Você venceu!");
                    jogoEmAndamento = false;
                    continue;
                }

                Console.Write("Rodada do Computador");
                Console.ReadLine();
                
                int resultadoComputador = RandomNumberGenerator.GetInt32(1, 7);
                Console.WriteLine($"Resultado: {resultadoComputador}");
                posicaoComputador += resultadoComputador;

                Console.WriteLine($"Posição do computador: {posicaoComputador} de {limiteLinhaChegada}");

                if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
                {
                    Console.WriteLine($"\nEVENTO: Avanço de 3 casas!");
                    posicaoComputador += 3;

                    Console.WriteLine($"\nVocê está na posição: {posicaoComputador} de {limiteLinhaChegada}");
                }

                else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
                {
                    Console.WriteLine($"\nEVENTO: Recuo de 2 casas");
                    posicaoComputador -= 2;

                    Console.WriteLine($"\nVocê está na posição: {posicaoComputador} de {limiteLinhaChegada}");
                }

                if (posicaoComputador >= limiteLinhaChegada)
                {
                    Console.WriteLine("Computador venceu!");
                    jogoEmAndamento = false;
                }

                Console.ReadLine();
            }

            Console.Write("Deseja continuar? (s/N) ");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            if (opcaoContinuar != "S")
                break;
        }
    }
}