using System.Collections.Generic;

namespace gcgcg
{
    class Campo
    {
        public List<Peca> Brancas;
        public List<Peca> Pretas;
        public Peca[ , ] tabuleiro = new Peca[8, 8];


        public Campo() {
            
        }


        private void initializePawns() {
            for (int i = 0; i < tabuleiro.Length; i++)
            {
                tabuleiro[1, i] = new Peao(COR.BRANCO);
                tabuleiro[6, i] = new Peao(COR.PRETO);
            }
        }
    }
}