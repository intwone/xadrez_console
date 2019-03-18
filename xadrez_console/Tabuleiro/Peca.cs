namespace tabuleiro {
    class Peca {
        public Posicao posicao { get; set; } // posição da peça
        // protect set; pode ser acessada por outras classes(subclasses ou a própria classe)
        public Cor cor { get; protected set; } //  
        public int qtdMovimentos { get; protected set; } // contagem de movimentos de cada peça
        public Tabuleiro tabuleiro { get; set; }

        // Construtor
        public Peca(Tabuleiro tab, Cor cor) { // Uma nova peça recebe uma nova posição, tabuleiro e cor
            this.posicao = null; // Ao criar uma peça ele não tem posição, ou seja, ela é null
            this.tabuleiro = tab;
            this.cor = cor;
            this.qtdMovimentos = 0; // quantidade de movimentos iniciando em zero
        }

        // Metodo para incrementar a quantidade de movimentos (qtdMovimentos)
        public void incrementarQtdMovimentos() {
            qtdMovimentos++;
        }
    }
}
