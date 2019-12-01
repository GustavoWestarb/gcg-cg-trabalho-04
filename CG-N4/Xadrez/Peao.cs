using System.Collections.Generic;
using System;

namespace gcgcg
{
    class Peao: Peca {

        public Peao(COR cor, int x, int y): base(x, y, cor) { }

        public override List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro)
        {
            List<Coordenada> possibilidades = new List<Coordenada>();

            if (Cor == COR.BRANCO)
            {
                // Contablilizando o fato de o peão ter que andar duas casas caso seja seu primeiro movimento
                if (this.Y == 1) 
                {
                    possibilidades.Add(new Coordenada(this.X, this.Y + 2));
                }
                // Caso haja alguma peça para ser "comida"
                try 
                {    
                    if (tabuleiro[this.X + 1, this.Y + 1] != null) 
                    {
                        possibilidades.Add(new Coordenada(this.X + 1, this.Y + 1));
                    }
                } 
                catch(IndexOutOfRangeException) { }

                try
                {
                    if (tabuleiro[this.X + 1, this.Y - 1] != null) 
                    {
                        possibilidades.Add(new Coordenada(this.X + 1, this.Y - 1));
                    }
                }
                catch(IndexOutOfRangeException) { }

                // movimento padrão
                if (tabuleiro[X, Y + 1] == null)
                {
                    possibilidades.Add(new Coordenada(this.X, this.Y + 1));
                }

            }
            else if (Cor == COR.PRETO)
            {
                // Contablilizando o fato de o peão ter que andar duas casas caso seja seu primeiro movimento
                if (this.Y == 6) {
                    possibilidades.Add(new Coordenada(this.X, this.Y - 2));
                }
                 // Caso haja alguma peça para ser "comida"
                try 
                {    
                    if (tabuleiro[this.X - 1, this.Y - 1] != null) 
                    {
                        possibilidades.Add(new Coordenada(this.X - 1, this.Y - 1));
                    }
                } 
                catch(IndexOutOfRangeException) { }

                try
                {
                    if (tabuleiro[this.X - 1, this.Y + 1] != null) 
                    {
                        possibilidades.Add(new Coordenada(this.X + 1, this.Y - 1));
                    }
                }
                catch(IndexOutOfRangeException) { }
                
                // movimento padrão
                if (tabuleiro[X, Y - 1] == null)
                {
                    possibilidades.Add(new Coordenada(this.X, this.Y - 1));
                }
            }

            return possibilidades;
        }

        public override void Movimentar(Coordenada coordenada, Peca[,] tabuleiro)
        {
            X = coordenada.X;
            Y = coordenada.Y;
        }
    }
}