using System;

namespace tabuleiro {
    class TabuleiroException : Exception {
        public TabuleiroException(string message) : base(message) {
        }

        // Construtor
        public TabuleiroException(string mensagem, Cor cor) : base(mensagem) { // Repassa a mensagem para a classe Exception do c#
        }
        
    }
}
