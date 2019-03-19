using tabuleiro;

namespace xadrez {
    class Torre : Peca { // A classe rei herda a classe peca
        // Construtor
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) { // repassa essa instrução para a classe peça
        }

        public override string ToString() {
            return "T";
        }

        // Método auxiliar
        private bool podeMover(Posicao pos) { // Essa torre pode mover para a posição pos?
            Peca p = tab.peca(pos); // Pega a peca do tabuleiro que ta na posição pos 
            return p == null || p.cor != this.cor; // Se a posicao for null || se a cor dessa peca que está na posicao pos for diferente dessa que estou movimento
        }

        public override bool[,] movimentoPossiveis() { // override sobescreve o método que está na classe Peca
            bool[,] mat = new bool[tab.linhas, tab.colunas]; // instanciação de uma nova matriz

            Posicao pos = new Posicao(0, 0);

            // Verificação acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) { // Enquanto não chegar no final do tabuleiro e enquanto atender o método podeMover
                mat[pos.linha, pos.coluna] = true;
                // Parar de mover quando encontrar uma peça adversária
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor) { // Se posição pos tiver uma peça e for diferente da cor que está movimentando
                    break; // forçar a parada
                }
                pos.linha = pos.linha - 1; // Pula uma linha para cima
            }

            // Verificação abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) { // Enquanto não chegar no final do tabuleiro e enquanto atender o método podeMover
                mat[pos.linha, pos.coluna] = true;
                // Parar de mover quando encontrar uma peça adversária
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor) { // Se posição pos tiver uma peça e for diferente da cor que está movimentando
                    break; // forçar a parada
                }
                pos.linha = pos.linha + 1; // Pula uma linha para cima
            }

            // Verificação direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) { // Enquanto não chegar no final do tabuleiro e enquanto atender o método podeMover
                mat[pos.linha, pos.coluna] = true;
                // Parar de mover quando encontrar uma peça adversária
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor) { // Se posição pos tiver uma peça e for diferente da cor que está movimentando
                    break; // forçar a parada
                }
                pos.coluna = pos.coluna + 1; // Pula uma linha para cima
            }

            // Verificação esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) { // Enquanto não chegar no final do tabuleiro e enquanto atender o método podeMover
                mat[pos.linha, pos.coluna] = true;
                // Parar de mover quando encontrar uma peça adversária
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor) { // Se posição pos tiver uma peça e for diferente da cor que está movimentando
                    break; // forçar a parada
                }
                pos.coluna = pos.coluna - 1; // Pula uma linha para cima
            }

            return mat; // retorna a matriz
        }
    }
}

