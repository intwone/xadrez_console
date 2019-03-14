namespace Tabuleiro {
    class Posicao {
        public int linha { get; set; }
        public int coluna { get; set; }

        public Posicao(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }

        // ToString da classe posição
        public override string ToString() {
            return linha + ", " + coluna;
        }
    }
}
