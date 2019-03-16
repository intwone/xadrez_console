using tabuleiro;

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

        // Sobrecarga
        public Peca peca(Posicao pos) {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos) { // testar se existe uma peça em uma determinada posição
            validarPosicao(pos); // Se tiver algum erro na funcao validarPosicao, esse método será cortado, e lancará a exceção criada
            return peca(pos) != null; // se a peça na posição pos for diferente de null, ou seja, se for verdade significa que existe uma peça na posição determinada
        }

        // Função para colocar uma peca
        public void colocarPeca(Peca p, Posicao pos) {
            if (existePeca(pos)) { 
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p; // Acessa a matriz na posicao (linha, coluna) e coloca a peca p
            p.posicao = pos; // Posicao da peca p receberá a posicao pos
        }

        // Metodo de posição válida
        public bool posicaoValida(Posicao pos) { // Testa se a posicao pos é valida ou não
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas) {
                return false;
            }
            else {
                return true;
            }
        }

        public void validarPosicao(Posicao pos) { // Se a posição não for válida, lançará uma excessão
            if (!posicaoValida(pos)) { // Se a posição pos NÃO for válida, lançará um exceção
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}
