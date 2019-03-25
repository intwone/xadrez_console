using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; } // contagem de de jogadas
        public Cor jogadorAtual { get; private set; } // Indicar de quem será a vez de jogar
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas; // Conjunto para guardar as peças
        private HashSet<Peca> capturadas;
        private Cor cor;
        public bool xeque { get; private set; }

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8); // Criação do tabuleiro
            turno = 1; // Jogadas iniciando em 1
            jogadorAtual = Cor.Branca; // Pecas brancas comecam primeiro
            terminada = false; // A partida não começa terminada .-.
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino) { // a função terá uma posicao de origem e uma posicao de destino
            Peca p = tab.retirarPeca(origem); // Peca p é retirada do tabuleiro. (tira a peça da origem)
            p.incrementarQtdMovimentos(); // Incrementa a quantidade de movimentos da peca p
            Peca pecaCapturada = tab.retirarPeca(destino); // Retira a peça do destino, caso exista
            tab.colocarPeca(p, destino); // coloca a peça no destino
            if (pecaCapturada != null) { // Se a peca capturada for diferente de null
                capturadas.Add(pecaCapturada); // A peca capturada será guardada na conjunto capturadas
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if (pecaCapturada != null) { // Se a peça capturada for diferente de null
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino);
            if (estaEmXeque(jogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque");
            }
            if (estaEmXeque(adversaria(jogadorAtual))) { // Se está em xeque o adversário do jogador atual
                xeque = true;
            }
            else {
                xeque = false;
            }
            turno++; // incrementa o turno, passando para a próxima jogada
            mudaJogador();
        }

        // Tratamento de exeções 
        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null) { // Se no tabuleiro a peca que está na posicao pos for igual a null
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor) { // Só pode escolher uma peça na posição onde tem uma peça da mesma cor do jogador atual
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) { // Se não existe movimentos possíveis
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).podeMoverPara(destino)) { // Se a peça de origem NÃO pode mover para a posição de destino
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        public void mudaJogador() {
            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        // Método que retorna um conjunto de pecas (capturadas)
        public HashSet<Peca> pecasCapturadas(Cor cor) { // método utilizado para fazer a separação das cores de pecas capturadas
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) { // percorrer todas as pecas x no conjunto capturadas
                if (x.cor == cor) { // Se x.cor for igual a cor informada no parâmetro
                    aux.Add(x); // adiciona a peca x no conjunto aux (criando um conjunto separado de pecas)
                }
            }
            return aux; // retorna o conjunto aux
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) { // método utilizado para retornar quem são as pecas em jogo de uma dada cor
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) { // percorrer todas as pecas do jogo no conjunto pecas
                if (x.cor == cor) {  
                    aux.Add(x); 
                }
            }
            aux.ExceptWith(pecasCapturadas(cor)); // retirar todas as pecas capturadas da cor informada no parâmetro
            return aux;
        }

        // Verificação de cores (adversária)
        private Cor adversaria(Cor cor) {
            if(cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }

        // Verifica quem é o rei de uma determinada cor
        private Peca rei(Cor cor) {
            foreach(Peca x in pecasEmJogo(cor)) {
                if (x is Rei) { // se a peça x é uma instancia da peca rei
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor) { // está em xeque o rei de uma determinada cor
            Peca R = rei(cor);
            if (R == null) { // Se R for igual a null, significa que não tem rei
                throw new TabuleiroException("Não tem rei da cor {0} no tabuleiro!", cor); // Lança a exceção
            }

            foreach (Peca x in pecasEmJogo(adversaria(cor))) { // Para cada peca x no conjunto(pecas adversárias)
                bool[,] mat = x.movimentoPossiveis(); // Matriz de movimentos possíveis
                if (mat[R.posicao.linha, R.posicao.coluna]) {
                    return true;
                }
            }
            return false;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) { // Dado uma coluna e linha de uma peça, faz...
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao()); // irá no tabuleiro da partida e colocará a peca
            pecas.Add(peca); // No conjunto pecas, adicionar uma peca no conjunto
        }

        private void colocarPecas() {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));

        } 
    }
}
