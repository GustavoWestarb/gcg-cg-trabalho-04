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
            _inicializarBispos();
            _inicializarRainha();
            _inicializarRei();
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // if (Tabuleiro[i, j] != null)
                    // {
                    //     if (Tabuleiro[i, j].Cor == COR.BRANCO)
                    //     {
                    //         var a = Tabuleiro[i, j].MovimentosPossiveis(Tabuleiro, Pretas);
                    //         Tabuleiro[i, j].Movimentar(a?[0], Tabuleiro);
                    //     }
                    //     else
                    //     {
                    //         var a = Tabuleiro[i, j].MovimentosPossiveis(Tabuleiro, Brancas);
                    //         Tabuleiro[i, j].Movimentar(a?[0], Tabuleiro);
                    //     }
                    // }
                    Console.Write(Tabuleiro[i, j] + ", ");
                }
                Console.WriteLine();
            }
            // var piroquinha = Tabuleiro[0, 1].MovimentosPossiveis(Tabuleiro, Pretas);
            // MoverPeca(Tabuleiro[0, 1], piroquinha[0]);
            // var pirocao = Tabuleiro[0, 0].MovimentosPossiveis(Tabuleiro, Pretas);

            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // if (Tabuleiro[i, j] != null)
                    // {
                    //     if (Tabuleiro[i, j].Cor == COR.BRANCO)
                    //     {
                    //         var a = Tabuleiro[i, j].MovimentosPossiveis(Tabuleiro, Pretas);
                    //         Tabuleiro[i, j].Movimentar(a?[0], Tabuleiro);
                    //     }
                    //     else
                    //     {
                    //         var a = Tabuleiro[i, j].MovimentosPossiveis(Tabuleiro, Brancas);
                    //         Tabuleiro[i, j].Movimentar(a?[0], Tabuleiro);
                    //     }
                    // }
                    Console.Write(Tabuleiro[i, j] + ", ");
                }
                Console.WriteLine();
            }
        }



        public void MoverPeca(Peca peca, Coordenada coordenada)
        {
            var pecaDestino = Tabuleiro[coordenada.X, coordenada.Y];
            
            // _guardarEstado();
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
            Tabuleiro[peca.X, peca.Y] = null;

            peca.Movimentar(coordenada, Tabuleiro);
            
            Tabuleiro[coordenada.X, coordenada.Y] = peca;
        }


        public void Desfazer() 
        {
            Brancas.Clear();
            Pretas.Clear();
            Array.Clear(Tabuleiro, 0, 8);

            Brancas.AddRange(_desfazerBrancas);
            Pretas.AddRange(_desfazerPretas);
            Tabuleiro.CopyTo(_desfazerTabuleiro, 0);

            _podeDesfazer = false;
        }


        private void _guardarEstado()
        {
            _desfazerBrancas.Clear();
            _desfazerPretas.Clear();
            Array.Clear(_desfazerTabuleiro, 0, 8);

            _desfazerBrancas.AddRange(Brancas);
            _desfazerPretas.AddRange(Pretas);
            Tabuleiro.CopyTo(_desfazerTabuleiro, 0);
        }
        private void _inicializarPeoes() 
        {
            for (int i = 0; i < 8; i++)
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
            var torreBrancaDireita = new Torre(7, 0, COR.BRANCO);

            var torrePretaEsquerda = new Torre(0, 7, COR.PRETO);
            var torrePretaDireita = new Torre(7, 7, COR.PRETO);

            Brancas.Add(torreBrancaEsquerda);
            Brancas.Add(torreBrancaDireita);
            
            Pretas.Add(torrePretaEsquerda);
            Pretas.Add(torrePretaDireita);

            Tabuleiro[0, 0] = torreBrancaEsquerda;
            Tabuleiro[7, 0] = torreBrancaDireita;

            Tabuleiro[0, 7] = torrePretaEsquerda;
            Tabuleiro[7, 7] = torrePretaDireita;
        }

        private void _inicializarCavalos()
        {
            var cavaloBrancoEsquerdo = new Cavalo(1, 0, COR.BRANCO);
            var cavaloBrancoDireito = new Cavalo(6, 0, COR.BRANCO);

            var cavaloPretoEsquerdo = new Cavalo(1, 7, COR.PRETO);
            var cavaloPretoDireito = new Cavalo(6, 7, COR.PRETO);

            Brancas.Add(cavaloBrancoEsquerdo);
            Brancas.Add(cavaloBrancoDireito);
            
            Pretas.Add(cavaloPretoEsquerdo);
            Pretas.Add(cavaloPretoDireito);

            Tabuleiro[1, 0] = cavaloBrancoEsquerdo;
            Tabuleiro[6, 0] = cavaloBrancoDireito;

            Tabuleiro[1, 7] = cavaloPretoEsquerdo;
            Tabuleiro[6, 7] = cavaloPretoDireito;
        }

        private void _inicializarBispos()
        {
            var bispoBrancoEsquerdo = new Bispo(2, 0, COR.BRANCO);
            var bispoBrancoDireito = new Bispo(5, 0, COR.BRANCO);

            var bispoPretoEsquerdo = new Bispo(2, 7, COR.PRETO);
            var bispoPretoDireito = new Bispo(5, 7, COR.PRETO);

            Brancas.Add(bispoBrancoEsquerdo);
            Brancas.Add(bispoBrancoDireito);
            
            Pretas.Add(bispoPretoEsquerdo);
            Pretas.Add(bispoPretoDireito);

            Tabuleiro[2, 0] = bispoBrancoEsquerdo;
            Tabuleiro[5, 0] = bispoBrancoDireito;

            Tabuleiro[2, 7] = bispoPretoEsquerdo;
            Tabuleiro[5, 7] = bispoPretoDireito;
        }

        private void _inicializarRainha()
        {
            var rainhaBranca = new Rainha(3, 0, COR.BRANCO);
            var rainhaPreta = new Rainha(3, 7, COR.PRETO);

            Brancas.Add(rainhaBranca);
            Pretas.Add(rainhaPreta);

            Tabuleiro[3, 0] = rainhaBranca;
            Tabuleiro[3, 7] = rainhaPreta;
        }

        private void _inicializarRei()
        {
            var reiBranco = new Rei(4, 0, COR.BRANCO);
            var reiPreto = new Rei(4, 7, COR.PRETO);

            Brancas.Add(reiBranco);
            Pretas.Add(reiPreto);

            Tabuleiro[4, 0] = reiBranco;
            Tabuleiro[4, 7] = reiPreto;
        }
    }
}