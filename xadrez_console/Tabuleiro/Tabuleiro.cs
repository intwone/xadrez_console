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
    }
}
