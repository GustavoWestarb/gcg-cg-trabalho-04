using System.Collections.Generic;

namespace gcgcg {
    internal class Torre: Peca {

        public Torre(int x, int y, COR cor): base(x, y, cor) { }
        
        public override List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro, List<Peca> adversarios)
        {
            return _movimentosVertical(tabuleiro);
        }
    }
}