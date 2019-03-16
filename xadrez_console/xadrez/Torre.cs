using tabuleiro;

namespace xadrez {
    class Torre : Peca { // A classe rei herda a classe peca
        // Construtor
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) { // repassa essa instrução para a classe peça
        }

        public override string ToString() {
            return "T";
        }
    }
}
