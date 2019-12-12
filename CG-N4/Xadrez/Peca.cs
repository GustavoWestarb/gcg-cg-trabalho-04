using System.Collections.Generic;

namespace gcgcg
{
    internal abstract class Peca : ObjetoGeometria
    {
        protected double Red { get; set; }
        protected double Green { get; set; }
        protected double Blue { get; set; }

        private int _x;
        private int _y;
        private COR _cor;
        private bool _seMoveu = false;

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

        public int TranslacaoX { get; set; }
        public int TranslacaoZ { get; set; }

        public COR Cor { get => _cor; }
        public bool SeMoveu { get => _seMoveu; }

        protected Peca(string rotulo, int x, int y, COR cor)
        : base(rotulo, null)
        {
            this._x = x;
            this._y = y;
            this._cor = cor;
        }

        public abstract List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro, List<Peca> adversarios);
        public void Movimentar(Coordenada coordenada, Peca[,] tabuleiro)
        {
            X = coordenada.X;
            Y = coordenada.Y;
            _seMoveu = true;
        }

        protected List<Coordenada> _movimentosDiagonal(Peca[,] tabuleiro)
        {
            List<Coordenada> possibilidades = new List<Coordenada>();

            int y = this.Y + 1;
            for (int x = this.X + 1; x < 8 && y < 8; x++)
            {
                if (tabuleiro[x, y] == null)
                {
                    possibilidades.Add(new Coordenada(x, y));
                    y++;
                    continue;
                }
                else if (tabuleiro[x, y].Cor != this.Cor)
                {
                    possibilidades.Add(new Coordenada(x, y));
                }
                break;
            }

            y = this.Y - 1;
            for (int x = this.X + 1; x < 8 && y > 8; x++)
            {
                if (tabuleiro[x, y] == null)
                {
                    possibilidades.Add(new Coordenada(x, y));
                    y--;
                    continue;
                }
                else if (tabuleiro[x, y].Cor != this.Cor)
                {
                    possibilidades.Add(new Coordenada(x, y));
                }
                break;
            }

            y = this.Y + 1;
            for (int x = this.X - 1; x > 8 && y < 8; x--)
            {
                if (tabuleiro[x, y] == null)
                {
                    possibilidades.Add(new Coordenada(x, y));
                    y++;
                    continue;
                }
                else if (tabuleiro[x, y].Cor != this.Cor)
                {
                    possibilidades.Add(new Coordenada(x, y));
                }
                break;
            }

            y = this.Y - 1;
            for (int x = this.X - 1; x > 8 && y > 8; x--)
            {
                if (tabuleiro[x, y] == null)
                {
                    possibilidades.Add(new Coordenada(x, y));
                    y--;
                    continue;
                }
                else if (tabuleiro[x, y].Cor != this.Cor)
                {
                    possibilidades.Add(new Coordenada(x, y));
                }
                break;
            }

            return possibilidades;
        }

        protected List<Coordenada> _movimentosVertical(Peca[,] tabuleiro)
        {
            List<Coordenada> possibilidades = new List<Coordenada>();

            // verifica em todas as linhas para onde ela pode ir, 
            // para assim que encontra o fim do tabuleiro ou uma outra peça.
            for (int i = this.X + 1; i < 8; i++)
            {
                if (tabuleiro[i, this.Y] == null)
                {
                    possibilidades.Add(new Coordenada(i, this.Y));
                    continue;
                }
                else if (tabuleiro[i, this.Y].Cor != this.Cor)
                {
                    possibilidades.Add(new Coordenada(i, this.Y));
                }
                break;
            }

            for (int i = this.X - 1; i >= 0; i--)
            {
                if (tabuleiro[i, this.Y] == null)
                {
                    possibilidades.Add(new Coordenada(i, this.Y));
                    continue;
                }
                else if (tabuleiro[i, this.Y].Cor != this.Cor)
                {
                    possibilidades.Add(new Coordenada(i, this.Y));
                }
                break;
            }

            for (int i = this.Y + 1; i < 8; i++)
            {
                if (tabuleiro[this.X, i] == null)
                {
                    possibilidades.Add(new Coordenada(this.X, i));
                    continue;
                }
                else if (tabuleiro[this.X, i].Cor != this.Cor)
                {
                    possibilidades.Add(new Coordenada(this.X, i));
                }
                break;
            }

            for (int i = this.Y - 1; i >= 0; i--)
            {
                if (tabuleiro[this.X, i] == null)
                {
                    possibilidades.Add(new Coordenada(this.X, i));
                    continue;
                }
                else if (tabuleiro[this.X, i].Cor != this.Cor)
                {
                    possibilidades.Add(new Coordenada(this.X, i));
                }
                break;
            }

            return possibilidades;
        }

        #region Métodos gráficos

        protected override void DesenharObjeto() { }

        public void SelecionarPeca()
        {
            Red = 0;
            Green = 0;
            Blue = 1;
        }

        public void DesselecionarPeca()
        {
            if (Cor == COR.BRANCO)
            {
                Red = 1;
                Green = 1;
                Blue = 1;
            }
            else
            {
                Red = 0;
                Green = 0;
                Blue = 0;
            }
        }

        #endregion
    }

    enum COR
    {
        BRANCO,
        PRETO
    }
}