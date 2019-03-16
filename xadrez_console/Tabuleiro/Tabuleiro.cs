namespace tabuleiro {
    class Tabuleiro {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas; // matriz de peças, não podendo ser acessadas por outras classes
        
        // Na criação do tabuleiro, terá que informar a quantidade de linhas e colunas
        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas]; // peças recebe uma nova matriz[quantidade_linhas, quantidade_colunas]
        }

        // Acesso as pecas[,]
        public Peca peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        // Função para colocar uma peca
        public void colocarPeca(Peca p, Posicao pos) {
            pecas[pos.linha, pos.coluna] = p; // Acessa a matriz na posicao (linha, coluna) e coloca a peca p
            p.posicao = pos; // Posicao da peca p receberá a posicao pos
        }
    }
}
