/* 
     O rei move em todas as direções somente uma casa
*/

using tabuleiro;

namespace xadrez {
    class Rei : Peca { // A classe rei herda a classe peca
        // Construtor
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) { // repassa essa instrução para a classe peça
        }

        public override string ToString() {
            return "R"; 
        }

        // Método auxiliar
        private bool podeMover(Posicao pos) { // Esse rei pode mover para a posição pos?
            Peca p = tab.peca(pos); // Pega a peca do tabuleiro que ta na posição pos 
            return p == null || p.cor != this.cor; // Se a posicao for null || se a cor dessa peca que está na posicao pos for diferente dessa que estou movimento
        }

        public override bool[,] movimentoPossiveis() { // override sobescreve o método que está na classe Peca
            bool[,] mat = new bool[tab.linhas, tab.colunas]; // instanciação de uma nova matriz

            Posicao pos = new Posicao(0, 0);

            // Verificação acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos)) { // Se a posição for válida e pode mover nessa posição
                mat[pos.linha, pos.coluna] = true; // Se a posição for válida e atende os parametros do método podeMover
            }
            // Verificação diagonal NE
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) { // Se a posição for válida e pode mover nessa posição
                mat[pos.linha, pos.coluna] = true; // Se a posição for válida e atende os parametros do método podeMover
            }
            // Verificação direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) { // Se a posição for válida e pode mover nessa posição
                mat[pos.linha, pos.coluna] = true; // Se a posição for válida e atende os parametros do método podeMover
            }
            // Verificação diagonal SE
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) { // Se a posição for válida e pode mover nessa posição
                mat[pos.linha, pos.coluna] = true; // Se a posição for válida e atende os parametros do método podeMover
            }
            // Verificação abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos)) { // Se a posição for válida e pode mover nessa posição
                mat[pos.linha, pos.coluna] = true; // Se a posição for válida e atende os parametros do método podeMover
            }
            // Verificação diagonal SO
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) { // Se a posição for válida e pode mover nessa posição
                mat[pos.linha, pos.coluna] = true; // Se a posição for válida e atende os parametros do método podeMover
            }
            // Verificação esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) { // Se a posição for válida e pode mover nessa posição
                mat[pos.linha, pos.coluna] = true; // Se a posição for válida e atende os parametros do método podeMover
            }
            // Verificação diagonal NO
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) { // Se a posição for válida e pode mover nessa posição
                mat[pos.linha, pos.coluna] = true; // Se a posição for válida e atende os parametros do método podeMover
            }

            return mat; // retorna a matriz
        }
    }
}
