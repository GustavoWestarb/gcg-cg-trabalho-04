using System.Collections.Generic;

namespace gcgcg
{
    class Rainha: Peca
    {
        public Rainha(int x, int y, COR cor): base(x, y, cor) { }

        public override List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro, List<Peca> adversarios)
        {
            List<Coordenada> possibilidades = new List<Coordenada>();

            possibilidades.AddRange(_movimentosDiagonal(tabuleiro));
            possibilidades.AddRange(_movimentosVertical(tabuleiro));
            
            return possibilidades;
        }
    }
}
