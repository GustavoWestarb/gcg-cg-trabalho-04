using System.Collections.Generic;
using System;

namespace gcgcg
{
    internal class Peao: Peca {

        public Peao(int x, int y, COR cor): base(x, y, cor) { }

        public override List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro, List<Peca> adversarios)
        {
            List<Coordenada> possibilidades = new List<Coordenada>();

            if (Cor == COR.BRANCO)
            {
                // Contablilizando o fato de o peão ter que andar duas casas caso seja seu primeiro movimento
                if (!SeMoveu) 
                {
                    possibilidades.Add(new Coordenada(this.X, this.Y + 2));
                }
                // Caso haja alguma peça para ser "comida"
                try 
                {    
                    if (tabuleiro[this.X + 1, this.Y + 1] != null && tabuleiro[this.X + 1, this.Y + 1].Cor != COR.BRANCO) 
                    {
                        possibilidades.Add(new Coordenada(this.X + 1, this.Y + 1));
                    }
                } 
                catch(IndexOutOfRangeException) { }

                try
                {
                    if (tabuleiro[this.X + 1, this.Y - 1] != null && tabuleiro[this.X + 1, this.Y - 1].Cor != COR.BRANCO) 
                    {
                        possibilidades.Add(new Coordenada(this.X + 1, this.Y - 1));
                    }
                }
                catch(IndexOutOfRangeException) { }

                // movimento padrão
                try
                {
                    if (tabuleiro[X, Y + 1] == null)
                    {
                        possibilidades.Add(new Coordenada(this.X, this.Y + 1));
                    }
                }
                catch(IndexOutOfRangeException) { }

            }
            else if (Cor == COR.PRETO)
            {
                // Contablilizando o fato de o peão ter que andar duas casas caso seja seu primeiro movimento
                if (!SeMoveu) 
                {
                    possibilidades.Add(new Coordenada(this.X, this.Y - 2));
                }
                 // Caso haja alguma peça para ser "comida"
                try 
                {    
                    if (tabuleiro[this.X - 1, this.Y - 1] != null && tabuleiro[this.X - 1, this.Y - 1].Cor != COR.PRETO) 
                    {
                        possibilidades.Add(new Coordenada(this.X - 1, this.Y - 1));
                    }
                } 
                catch(IndexOutOfRangeException) { }

                try
                {
                    if (tabuleiro[this.X + 1, this.Y - 1] != null && tabuleiro[this.X + 1, this.Y - 1].Cor != COR.PRETO) 
                    {
                        possibilidades.Add(new Coordenada(this.X + 1, this.Y - 1));
                    }
                }
                catch(IndexOutOfRangeException) { }
                
                // movimento padrão
                try
                {
                    if (tabuleiro[X, Y - 1] == null)
                    {
                        possibilidades.Add(new Coordenada(this.X, this.Y - 1));
                    }
                }
                catch(IndexOutOfRangeException) { }
            }

            return possibilidades;
        }
    }
}