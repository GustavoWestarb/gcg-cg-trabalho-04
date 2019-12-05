using System.Collections.Generic;

namespace gcgcg
{
    class Cavalo: Peca
    {
        public Cavalo(int x, int y, COR cor): base(x, y, cor) { }

        public override List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro, List<Peca> adversarios)
        {
            List<Coordenada> possibilidades = new List<Coordenada>();

            var XSuperiorEsquerdo = this.X - 1;
            var YSuperiorEsquerdo = this.Y + 2;

            var XSuperiorDireito = this.X + 1;
            var YSuperiorDireito = this.Y + 2;

            var XInferiorEsquerdo = this.X - 1;
            var YInferiorEsquerdo = this.Y - 2;

            var XInferiorDireito = this.X + 1;
            var YInferiorDireito = this.Y - 2;


            if (XSuperiorEsquerdo > 8 && YSuperiorEsquerdo < 8)
            {
                possibilidades.Add(new Coordenada(XSuperiorEsquerdo, YSuperiorEsquerdo));
            }
            
            if (XSuperiorDireito < 8 && YSuperiorDireito < 8)
            {
                possibilidades.Add(new Coordenada(XSuperiorDireito, YSuperiorDireito));
            }

            if (XInferiorEsquerdo > 8 && YInferiorEsquerdo > 8)
            {
                possibilidades.Add(new Coordenada(XInferiorEsquerdo, YInferiorEsquerdo));
            }

            if (XInferiorDireito < 8 && YInferiorDireito > 8)
            {
                possibilidades.Add(new Coordenada(XInferiorDireito, YInferiorDireito));
            }

            return possibilidades;
        }
    }
}