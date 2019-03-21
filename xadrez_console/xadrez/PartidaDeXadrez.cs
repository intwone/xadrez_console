using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; } // contagem de de jogadas
        public Cor jogadorAtual { get; private set; } // Indicar de quem será a vez de jogar
        public bool terminada { get; private set; } 

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8); // Criação do tabuleiro
            turno = 1; // Jogadas iniciando em 1
            jogadorAtual = Cor.Branca; // Pecas brancas comecam primeiro
            terminada = false; // A partida não começa terminada .-.
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino) { // a função terá uma posicao de origem e uma posicao de destino
            Peca p = tab.retirarPeca(origem); // Peca p é retirada do tabuleiro. (tira a peça da origem)
            p.incrementarQtdMovimentos(); // Incrementa a quantidade de movimentos da peca p
            Peca pecaCapturada = tab.retirarPeca(destino); // Retira a peça do destino, caso exista
            tab.colocarPeca(p, destino); // coloca a peça no destino
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
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

        private void colocarPecas() {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao()); // Coloca a peca na posicao (c, 1) 
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());


            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao()); // Coloca a peca na posicao (c, 1) 
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8 ).toPosicao());
        } 
    }
}
