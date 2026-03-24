using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;
        const int bonusAvancoExtra = 3;
        const int penalidadeRecuo = 2;

        ExecutarPartida(limiteLinhaChegada, bonusAvancoExtra, penalidadeRecuo);
    }

    static void ExecutarPartida(
        int limiteLinhaChegada,
        int bonusAvancoExtra,
        int penalidadeRecuo
    )
    {
        while (true)
        {
            int posicaoJogador = 0;
            int posicaoComputador = 0;

            while (true)
            {
                posicaoJogador = ExecutarRodadaJogador(
                    posicaoJogador,
                    limiteLinhaChegada,
                    bonusAvancoExtra,
                    penalidadeRecuo
                );

                if (posicaoJogador >= limiteLinhaChegada)
                    break;

                posicaoComputador = ExecutarRodadaComputador(
                    posicaoComputador,
                    limiteLinhaChegada,
                    bonusAvancoExtra,
                    penalidadeRecuo
                );

                if (posicaoComputador >= limiteLinhaChegada)
                    break;
            }

            if (!JogadorDesejaContinuar())
                break;
        }
    }

    static int ExecutarRodadaJogador(
        int posicaoJogador,
        int limiteLinhaChegada,
        int bonusAvancoExtra,
        int penalidadeRecuo
    )
    {
        do
        {
            ExibirCabecalho("Jogador");

            Console.Write("Pressione ENTER para lançar um dado...");
            Console.ReadLine();

            int resultadoJogador = RandomNumberGenerator.GetInt32(1, 7);

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"O número sorteado foi: {resultadoJogador}");
            Console.WriteLine("-------------------------------------------");

            posicaoJogador += resultadoJogador;

            Console.WriteLine($"Você está na posição: {posicaoJogador} de {limiteLinhaChegada}");

            if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15 || posicaoJogador == 25)
            {
                Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} casas!");
                posicaoJogador += bonusAvancoExtra;

                Console.WriteLine($"\nVocê está na posição: {posicaoJogador} de {limiteLinhaChegada}");
            }

            else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
            {
                Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} casas");
                posicaoJogador -= penalidadeRecuo;

                Console.WriteLine($"\nVocê está na posição: {posicaoJogador} de {limiteLinhaChegada}");
            }

            if (posicaoJogador >= limiteLinhaChegada)
            {
                Console.WriteLine("\nParabéns! Você alcançou a linha de chegada.");

                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                break;
            }

            if (resultadoJogador == 6)
            {
                Console.WriteLine($"\nEVENTO: Rodada Extra!");
                Console.WriteLine("-------------------------------------------");

                Console.Write("\nPressione ENTER para jogar novamente...");
                Console.ReadLine();

                continue;
            }
            else
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                break;
            }
        } while (true);

        return posicaoJogador;
    }

    static int ExecutarRodadaComputador(
        int posicaoComputador,
        int limiteLinhaChegada,
        int bonusAvancoExtra,
        int penalidadeRecuo
    )
    {
        do
        {
            ExibirCabecalho("Computador");

            int resultadoComputador = RandomNumberGenerator.GetInt32(1, 7);

            Console.WriteLine($"O número sorteado foi: {resultadoComputador}");
            Console.WriteLine("-------------------------------------------");

            posicaoComputador += resultadoComputador;

            Console.WriteLine($"O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");

            if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
            {
                Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} casas!");
                posicaoComputador += bonusAvancoExtra;

                Console.WriteLine($"\nO computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");
            }

            else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
            {
                Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} casas");
                posicaoComputador -= penalidadeRecuo;

                Console.WriteLine($"\nO computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");
            }

            if (posicaoComputador >= limiteLinhaChegada)
            {
                Console.WriteLine("\nQue pena! O computador alcançou a linha de chegada.");

                break;
            }

            if (resultadoComputador == 6)
            {
                Console.WriteLine($"\nEVENTO: Rodada Extra!");
                Console.WriteLine("-------------------------------------------");

                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                continue;
            }
            else
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                break;
            }

        } while (true);

        return posicaoComputador;
    }

    static void ExibirCabecalho(string nomeJogador)
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Rodada do {nomeJogador}");
        Console.WriteLine("-------------------------------------------");
    }

    static bool JogadorDesejaContinuar()
    {
        Console.Write("Deseja continuar? (s/N): ");
        string? opcaoContinuar = Console.ReadLine()?.ToUpper();

        if (opcaoContinuar != "S")
            return false;

        return true;
    }
}