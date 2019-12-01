using System.Collections.Generic;

namespace gcgcg
{
    class Peao: Peca {
        private COR _cor;

        public Peao(COR cor, int x, int y): base(x, y)
        {
            this._cor = cor;
        }

        public override List<Coordenada> MovimentosPossiveis()
        {
            List<Coordenada> possibilidades = new List<Coordenada>();

            if (_cor == COR.BRANCO)
            {
                if (this.Y == 1) {
                    possibilidades.Add(new Coordenada(this.X, this.Y + 2));
                }
                possibilidades.Add(new Coordenada(this.X, this.Y + 1));
            }
            else
            {
                if (this.Y == 6) {
                    possibilidades.Add(new Coordenada(this.X, this.Y - 2));
                }
                possibilidades.Add(new Coordenada(this.X, this.Y + 1));
            }


            return possibilidades;
        }

        public override void Movimentar(Coordenada coordenada)
        {
            X = coordenada.X;
            Y = coordenada.Y;
        }
    }
}