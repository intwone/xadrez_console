using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Tela {
        public static void imprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.tab);
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada) {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque) {
                    Console.WriteLine("XEQUE!");
                }
            }
            else {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: {0}", partida.jogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach(Peca x in conjunto) {
                Console.Write("{0} ",x);
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab) { // (função) Recebe um tabuleiro e imprimi na tela 
            for (int i = 0; i < tab.linhas; i++) { // Percorrer as linhas
                Console.Write(8 - i + " "); // Imprimi de forma decrescente os numeros do lado de cada linha
                for (int j = 0; j < tab.colunas; j++) { // Percorrer as colunas
                    imprimirPeca(tab.peca(i, j)); // chama a função imprmirPeca(parametro_da_peca)
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H"); // Após a impressão do tabuleiro, imprimir a linha com as letras de cada coluna
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) { // (função) Recebe um tabuleiro e imprimi na tela 
            ConsoleColor fundoOriginal = Console.BackgroundColor; // A variável fundoOriginal recebe o fundo padrão (preto)
            ConsoleColor fundoAlterado = ConsoleColor.DarkGreen;  // A varíável fundoAlterado recebe o fundo verde

            for (int i = 0; i < tab.linhas; i++) { // Percorrer as linhas
                Console.Write(8 - i + " "); // Imprimi de forma decrescente os numeros do lado de cada linha
                for (int j = 0; j < tab.colunas; j++) { // Percorrer as colunas
                    if (posicoesPossiveis[i, j] == true) { // Se as posicoesPossiveis[i, j] for verdade
                        Console.BackgroundColor = fundoAlterado; // BackgroundColor recebe o fundoAlterado (verde)
                    }
                    else { // Senão
                        Console.BackgroundColor = fundoOriginal; // O fundo fica padrão (preto)
                    }
                    imprimirPeca(tab.peca(i, j)); // chama a função imprmirPeca(parametro_da_peca)
                    Console.BackgroundColor = fundoOriginal; // O fundo fica padrão (preto)
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H"); // Após a impressão do tabuleiro, imprimir a linha com as letras de cada coluna
            Console.BackgroundColor = fundoOriginal;
        }


        public static PosicaoXadrez lerPosicaoXadrez() { // Lê do teclado o que o usuário digitou
            string s = Console.ReadLine();
            char coluna = s[0]; // primeira letra digitada pelo usuário (ex.: (c, 1), pegará somente o c, que é a referente a linha)
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca) {
            if (peca == null) { // Ou seja, não tem peça
                Console.Write("- ");
            }
            else {
                if (peca.cor == Cor.Branca) { // Se a peça for branca , imprimi
                    Console.Write(peca); // chamando o objeto peça no método tab
                }
                else { // Senão imprimi amarelo
                    ConsoleColor aux = Console.ForegroundColor; // salva na variável aux a cor do sistema (cinza)
                    Console.ForegroundColor = ConsoleColor.Yellow; // A cor do sistema recebe o amarelo
                    Console.Write(peca); // imprimi a cor da peça
                    Console.ForegroundColor = aux; // volta para a cor original
                }
                Console.Write(" ");
            }
        }
    }
}
