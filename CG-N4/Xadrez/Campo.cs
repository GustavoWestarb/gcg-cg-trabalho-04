using System.Collections.Generic;

namespace gcgcg
{
    class Campo
    {
        public List<Peca> Brancas;
        public List<Peca> Pretas;
        public Peca[ , ] tabuleiro = new Peca[8, 8];


        public Campo() {
            _initializePawns();
        }


        private void _initializePawns() {
            for (int i = 0; i < tabuleiro.Length; i++)
            {
                var peaoPreto = new Peao(COR.PRETO, i, 6);
                var peaoBranco = new Peao(COR.BRANCO, i, 1);
                
                Brancas.Add(peaoBranco);
                Pretas.Add(peaoPreto);

                tabuleiro[i, 1] = peaoBranco;
                tabuleiro[i, 6] = peaoPreto;
            }
        }
    }
}