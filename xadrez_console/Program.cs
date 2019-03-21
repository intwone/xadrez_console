using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                Tela.imprimirTabuleiro(partida.tab);

                while(!partida.terminada){ // Enquanto a partida não estiver terminada
                    try {
                        Console.Clear(); // Limpa a tela
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno); // 
                        Console.WriteLine("Aguardando jogada:" + partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao(); // Lê a posição e transforma ela na posição de matriz do sistema
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentoPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.WriteLine();
                    }
                }
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
    }
}
