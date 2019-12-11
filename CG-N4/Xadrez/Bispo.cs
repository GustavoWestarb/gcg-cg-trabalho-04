using System.Collections.Generic;

namespace gcgcg 
{
    internal class Bispo: Peca
    {

        public Bispo(int x, int y, COR cor): base(x, y, cor) { }
        public override List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro, List<Peca> adversarios)
        {
            return _movimentosDiagonal(tabuleiro);
        }
    }
}