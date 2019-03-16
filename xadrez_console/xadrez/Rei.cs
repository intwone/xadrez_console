using tabuleiro;

namespace xadrez {
    class Rei : Peca { // A classe rei herda a classe peca
        // Construtor
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) { // repassa essa instrução para a classe peça
        }

        public override string ToString() {
            return "R"; 
        }
    }
}
