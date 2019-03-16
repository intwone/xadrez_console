using System;

namespace tabuleiro {
    class TabuleiroException : Exception {

        // Construtor
        public TabuleiroException(string mensagem) : base(mensagem) { // Repassa a mensagem para a classe Exception do c#
        }
        
    }
}
