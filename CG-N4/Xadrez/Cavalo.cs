using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
    internal class Cavalo : Peca
    {
        public double _red { get; set; } = 0;
        public double _green { get; set; } = 1;
        public double _blue { get; set; } = 1;

        public Cavalo(string rotulo, int x, int y, COR cor)
            : base(rotulo, x, y, cor)
        {
            base.PontosAdicionar(new Ponto4D(-1, -1, 1));
            base.PontosAdicionar(new Ponto4D(1, -1, 1));
            base.PontosAdicionar(new Ponto4D(1, 1, 1));
            base.PontosAdicionar(new Ponto4D(-1, 1, 1));
            base.PontosAdicionar(new Ponto4D(-1, -1, -1));
            base.PontosAdicionar(new Ponto4D(1, -1, -1));
            base.PontosAdicionar(new Ponto4D(1, 1, -1));
            base.PontosAdicionar(new Ponto4D(-1, 1, -1));
        }

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

        #region Métodos gráficos

        protected override void DesenharObjeto()
        {
            GL.Begin(PrimitiveType.Quads);
            // Face da frente
            GL.Color3(_red, _green, _blue);
            GL.Normal3(0, 0, 1);
            GL.Vertex3(base.pontosLista[0].X, base.pontosLista[0].Y, base.pontosLista[0].Z);
            GL.Vertex3(base.pontosLista[1].X, base.pontosLista[1].Y, base.pontosLista[1].Z);
            GL.Vertex3(base.pontosLista[2].X, base.pontosLista[2].Y, base.pontosLista[2].Z);
            GL.Vertex3(base.pontosLista[3].X, base.pontosLista[3].Y, base.pontosLista[3].Z);

            GL.Color3(_red, _green, _blue);
            GL.Normal3(0, 0, -1);
            GL.Vertex3(base.pontosLista[4].X, base.pontosLista[4].Y, base.pontosLista[4].Z);
            GL.Vertex3(base.pontosLista[7].X, base.pontosLista[7].Y, base.pontosLista[7].Z);
            GL.Vertex3(base.pontosLista[6].X, base.pontosLista[6].Y, base.pontosLista[6].Z);
            GL.Vertex3(base.pontosLista[5].X, base.pontosLista[5].Y, base.pontosLista[5].Z);

            GL.Color3(_red, _green, _blue);
            GL.Normal3(0, 1, 0);
            GL.Vertex3(base.pontosLista[3].X, base.pontosLista[3].Y, base.pontosLista[3].Z);
            GL.Vertex3(base.pontosLista[2].X, base.pontosLista[2].Y, base.pontosLista[2].Z);
            GL.Vertex3(base.pontosLista[6].X, base.pontosLista[6].Y, base.pontosLista[6].Z);
            GL.Vertex3(base.pontosLista[7].X, base.pontosLista[7].Y, base.pontosLista[7].Z);

            GL.Color3(_red, _green, _blue);
            GL.Normal3(0, -1, 0);
            GL.Vertex3(base.pontosLista[0].X, base.pontosLista[0].Y, base.pontosLista[0].Z);
            GL.Vertex3(base.pontosLista[4].X, base.pontosLista[4].Y, base.pontosLista[4].Z);
            GL.Vertex3(base.pontosLista[5].X, base.pontosLista[5].Y, base.pontosLista[5].Z);
            GL.Vertex3(base.pontosLista[1].X, base.pontosLista[1].Y, base.pontosLista[1].Z);

            GL.Color3(_red, _green, _blue);
            GL.Normal3(1, 0, 0);
            GL.Vertex3(base.pontosLista[1].X, base.pontosLista[1].Y, base.pontosLista[1].Z);
            GL.Vertex3(base.pontosLista[5].X, base.pontosLista[5].Y, base.pontosLista[5].Z);
            GL.Vertex3(base.pontosLista[6].X, base.pontosLista[6].Y, base.pontosLista[6].Z);
            GL.Vertex3(base.pontosLista[2].X, base.pontosLista[2].Y, base.pontosLista[2].Z);

            GL.Color3(_red, _green, _blue);
            GL.Normal3(-1, 0, 0);
            GL.Vertex3(base.pontosLista[0].X, base.pontosLista[0].Y, base.pontosLista[0].Z);
            GL.Vertex3(base.pontosLista[3].X, base.pontosLista[3].Y, base.pontosLista[3].Z);
            GL.Vertex3(base.pontosLista[7].X, base.pontosLista[7].Y, base.pontosLista[7].Z);
            GL.Vertex3(base.pontosLista[4].X, base.pontosLista[4].Y, base.pontosLista[4].Z);
            GL.End();
        }

        #endregion
    }
}