﻿namespace tabuleiro {
    abstract class Peca { // Quando a classe tem pelo menos um método abstract a class também se torna abstract 
        public Posicao posicao { get; set; } // posição da peça
        // protect set; pode ser acessada por outras classes(subclasses ou a própria classe)
        public Cor cor { get; protected set; } //  
        public int qtdMovimentos { get; protected set; } // contagem de movimentos de cada peça
        public Tabuleiro tab { get; set; }

        // Construtor
        public Peca(Tabuleiro tab, Cor cor) { // Uma nova peça recebe uma nova posição, tabuleiro e cor
            this.posicao = null; // Ao criar uma peça ele não tem posição, ou seja, ela é null
            this.tab = tab;
            this.cor = cor;
            this.qtdMovimentos = 0; // quantidade de movimentos iniciando em zero
        }

        // Metodo para incrementar a quantidade de movimentos (qtdMovimentos)
        public void incrementarQtdMovimentos() {
            qtdMovimentos++;
        }

        public abstract bool[,] movimentoPossiveis(); // Matriz de booleano, método abstrato não tem implementação nessa classe pelo fato da classe ser de uma peça generica
    }
}
