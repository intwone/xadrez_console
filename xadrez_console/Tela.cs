using System;
using tabuleiro;

namespace xadrez_console {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tab) { // (função) Recebe um tabuleiro e imprimi na tela 
            for (int i = 0; i < tab.linhas; i++) { // Percorrer as linhas
                for(int j = 0; j < tab.colunas; j++) { // Percorrer as colunas
                    if (tab.peca(i, j) == null) { // Se não tiver peça na posição(i, j), imprimir...
                        Console.Write("- ");
                    }
                    else {
                        Console.WriteLine(tab.peca(i, j) + " "); // chamando o objeto peça no método tab
                    }
                }
                Console.WriteLine();
            }
            
        }
    }
}
