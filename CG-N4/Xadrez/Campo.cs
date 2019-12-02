using System.Collections.Generic;
using System;

namespace gcgcg
{
    class Campo
    {
        public List<Peca> Brancas = new List<Peca>();
        public List<Peca> Pretas = new List<Peca>();
        public Peca[ , ] Tabuleiro = new Peca[8, 8];
        private List<Peca> _desfazerBrancas = new List<Peca>();
        private List<Peca> _desfazerPretas = new List<Peca>();
        private Peca[ , ] _desfazerTabuleiro = new Peca[8, 8];
        private bool _podeDesfazer = false;
        public bool PodeDesfazer { get => _podeDesfazer; }

        public Campo() {
            _inicializarPeoes();
            _inicializarTorres();
            _inicializarCavalos();
        }

        public void MoverPeca(Peca peca, Coordenada coordenada)
        {
            var pecaDestino = Tabuleiro[coordenada.X, coordenada.Y];
            
            _guardarEstado();
            _podeDesfazer = true;
            
            if (pecaDestino != null) {
                if (pecaDestino.Cor == COR.PRETO)
                {
                    Pretas.Remove(pecaDestino);
                }
                else if (pecaDestino.Cor == COR.BRANCO)
                {
                    Brancas.Remove(pecaDestino);
                }

            }
            
            peca.Movimentar(coordenada, Tabuleiro);
            
            Tabuleiro[coordenada.X, coordenada.Y] = peca;
        }


        public void Desfazer() 
        {
            Brancas.Clear();
            Pretas.Clear();
            Array.Clear(Tabuleiro, 0, Tabuleiro.Length);

            Brancas.AddRange(_desfazerBrancas);
            Pretas.AddRange(_desfazerPretas);
            Tabuleiro.CopyTo(_desfazerTabuleiro, 0);

            _podeDesfazer = false;
        }


        private void _guardarEstado()
        {
            _desfazerBrancas.Clear();
            _desfazerPretas.Clear();
            Array.Clear(_desfazerTabuleiro, 0, _desfazerTabuleiro.Length);

            _desfazerBrancas.AddRange(Brancas);
            _desfazerPretas.AddRange(Pretas);
            Tabuleiro.CopyTo(_desfazerTabuleiro, 0);
        }
        private void _inicializarPeoes() 
        {
            for (int i = 0; i < Tabuleiro.Length; i++)
            {
                var peaoBranco = new Peao(i, 1, COR.BRANCO);
                var peaoPreto = new Peao(i, 6, COR.PRETO);
                
                Brancas.Add(peaoBranco);
                Pretas.Add(peaoPreto);

                Tabuleiro[i, 1] = peaoBranco;
                Tabuleiro[i, 6] = peaoPreto;
            }
        }
        
        private void _inicializarTorres() 
        {
            var torreBrancaEsquerda = new Torre(0, 0, COR.BRANCO);
            var torreBrancaDireita = new Torre(0, 7, COR.BRANCO);

            var torrePretaEsquerda = new Torre(7, 0, COR.PRETO);
            var torrePretaDireita = new Torre(7, 7, COR.PRETO);

            Brancas.Add(torreBrancaEsquerda);
            Brancas.Add(torreBrancaDireita);
            
            Pretas.Add(torrePretaEsquerda);
            Pretas.Add(torrePretaDireita);

            Tabuleiro[0, 0] = torreBrancaEsquerda;
            Tabuleiro[0, 7] = torreBrancaDireita;

            Tabuleiro[7, 0] = torrePretaEsquerda;
            Tabuleiro[7, 7] = torrePretaDireita;
        }

        private void _inicializarCavalos()
        {
            var cavaloBrancoEsquerdo = new Cavalo(0, 1, COR.BRANCO);
            var cavaloBrancoDireito = new Cavalo(0, 6, COR.BRANCO);

            var cavaloPretoEsquerdo = new Cavalo(7, 1, COR.PRETO);
            var cavaloPretoDireito = new Cavalo(7, 6, COR.PRETO);

            Brancas.Add(cavaloBrancoEsquerdo);
            Brancas.Add(cavaloBrancoDireito);
            
            Pretas.Add(cavaloPretoEsquerdo);
            Pretas.Add(cavaloPretoDireito);

            Tabuleiro[0, 1] = cavaloBrancoEsquerdo;
            Tabuleiro[0, 6] = cavaloBrancoDireito;

            Tabuleiro[7, 1] = cavaloPretoEsquerdo;
            Tabuleiro[7, 6] = cavaloPretoDireito;
        }

        private void _inicializarBispos()
        {
            var bispoBrancoEsquerdo = new Bispo(0, 2, COR.BRANCO);
            var bispoBrancoDireito = new Bispo(0, 5, COR.BRANCO);

            var bispoPretoEsquerdo = new Bispo(7, 2, COR.PRETO);
            var bispoPretoDireito = new Bispo(7, 5, COR.PRETO);

            Brancas.Add(bispoBrancoEsquerdo);
            Brancas.Add(bispoBrancoDireito);
            
            Pretas.Add(bispoPretoEsquerdo);
            Pretas.Add(bispoPretoDireito);

            Tabuleiro[0, 2] = bispoBrancoEsquerdo;
            Tabuleiro[0, 5] = bispoBrancoDireito;

            Tabuleiro[7, 2] = bispoPretoEsquerdo;
            Tabuleiro[7, 5] = bispoPretoDireito;
        }

        private void _inicializarRainha()
        {
            var rainhaBranca = new Rainha(0, 3, COR.BRANCO);
            var rainhaPreta = new Rainha(7, 3, COR.PRETO);

            Brancas.Add(rainhaBranca);
            Pretas.Add(rainhaPreta);

            Tabuleiro[0, 3] = rainhaBranca;
            Tabuleiro[7, 3] = rainhaPreta;
        }
    }
}