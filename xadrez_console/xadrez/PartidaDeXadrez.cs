using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        private int turno; // contagem de de jogadas
        private Cor jogadorAtual; // Indicar de quem será a vez de jogar
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
