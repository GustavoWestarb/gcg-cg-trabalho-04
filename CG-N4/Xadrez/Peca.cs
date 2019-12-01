using System.Collections.Generic;

namespace gcgcg 
{
    abstract class Peca
    {
        protected Peca(int x, int y) {

        }
        public int X;
        public int Y;
        public abstract List<Coordenada> MovimentosPossiveis();
        public abstract void Movimentar(Coordenada coordenada);
    }

    enum COR 
    {
        BRANCO,
        PRETO
    }
}