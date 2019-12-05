using System.Collections.Generic;
using System.Linq;

namespace gcgcg
{
    class Rei: Peca
    {

        public Rei(int x, int y, COR cor): base(x, y, cor) { }
        public override List<Coordenada> MovimentosPossiveis(Peca[,] tabuleiro, List<Peca> adversarios)
        {
            List<Coordenada> possibilidades = new List<Coordenada>();

            possibilidades.Add(new Coordenada(this.X + 1, this.Y));
            possibilidades.Add(new Coordenada(this.X - 1, this.Y));
            possibilidades.Add(new Coordenada(this.X, this.Y + 1));
            possibilidades.Add(new Coordenada(this.X, this.Y - 1));

            var impossibilidades = adversarios
                    .SelectMany(adversario => adversario.MovimentosPossiveis(tabuleiro, adversarios));

            return possibilidades.Except(impossibilidades).ToList();
        }

        public bool estouEmCheck(List<Peca> adversarios, Peca[,] tabuleiro)
        {
            var impossibilidades = adversarios
                    .SelectMany(adversario => {
                        if (adversario is Peao && adversario.X == this.X) 
                        {
                            return adversario.MovimentosPossiveis(tabuleiro, adversarios);
                        }
                    return new List<Coordenada>();
                    });

            var coordenada = new Coordenada(this.X, this.Y);
            var possibilidades = new List<Coordenada>() { coordenada };
            
            return possibilidades.Except(impossibilidades).Count() != 0;
        }
    }
}