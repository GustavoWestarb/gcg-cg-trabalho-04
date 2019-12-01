using System.Collections.Generic;

namespace gcgcg 
{
    abstract class Peca
    {
        private int _x;
        private int _y;
        private readonly COR _cor;

        public int X 
        { 
            get => _x; 
            set => _x = value; 
        }
        public int Y 
        { 
            get => _y; 
            set => _y = value; 
        }

        public COR Cor { get => _cor; }

        protected Peca(int x, int y, COR cor) {
            this._x = x;
            this._y = y;
            this._cor = cor;
        }

        public abstract List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro);
        public abstract void Movimentar(Coordenada coordenada, Peca[,] tabuleiro);
    }

    enum COR 
    {
        BRANCO,
        PRETO
    }
}