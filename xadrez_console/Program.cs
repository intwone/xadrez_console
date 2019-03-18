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
                    Console.Clear(); // Limpa a tela
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao(); // Lê a posição e transforma ela na posição de matriz do sistema
                    Console.WriteLine("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.executaMovimento(origem, destino);
                }
               
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }
    }
}
