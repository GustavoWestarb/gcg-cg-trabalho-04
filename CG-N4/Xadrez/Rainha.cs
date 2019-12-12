using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
    internal class Rainha : Peca
    {
        public double _red { get; set; } = 1;
        public double _green { get; set; } = 0;
        public double _blue { get; set; } = 0;


        public Rainha(string rotulo, int x, int y, COR cor)
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

            possibilidades.AddRange(_movimentosDiagonal(tabuleiro));
            possibilidades.AddRange(_movimentosVertical(tabuleiro));

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
