using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tab) { // (função) Recebe um tabuleiro e imprimi na tela 
            for (int i = 0; i < tab.linhas; i++) { // Percorrer as linhas
                Console.Write(8 - i + " "); // Imprimi de forma decrescente os numeros do lado de cada linha
                for (int j = 0; j < tab.colunas; j++) { // Percorrer as colunas
                    if (tab.peca(i, j) == null) { // Se não tiver peça na posição(i, j), imprimir...
                        Console.Write("- ");
                    }
                    else {
                        imprimirPeca(tab.peca(i, j)); // chama a função imprmirPeca(parametro_da_peca)
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H"); // Após a impressão do tabuleiro, imprimir a linha com as letras de cada coluna
        }

        public static PosicaoXadrez lerPosicaoXadrez() { // Lê do teclado o que o usuário digitou
            string s = Console.ReadLine();
            char coluna = s[0]; // primeira letra digitada pelo usuário (ex.: (c, 1), pegará somente o c, que é a referente a linha)
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);

        }

        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branca) { // Se a peça for branca , imprimi
                Console.Write(peca); // chamando o objeto peça no método tab
            }
            else { // Senão imprimi amarelo
                ConsoleColor aux = Console.ForegroundColor; // salva na variável aux a cor do sistema (cinza)
                Console.ForegroundColor = ConsoleColor.Yellow; // A cor do sistema recebe o amarelo
                Console.Write(peca); // imprimi a cor da peça
                Console.ForegroundColor = aux ; // volta para a cor original
            }
        }
    }
}
