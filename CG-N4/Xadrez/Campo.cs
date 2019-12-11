using System.Collections.Generic;
using System;

namespace gcgcg
{
    internal class Campo : ObjetoGeometria
    {
        public List<Peca> Brancas = new List<Peca>();
        public List<Peca> Pretas = new List<Peca>();
        public RegistroObjeto[,] Tabuleiro = new RegistroObjeto[8, 8];
        private List<Peca> _desfazerBrancas = new List<Peca>();
        private List<Peca> _desfazerPretas = new List<Peca>();
        private Peca[,] _desfazerTabuleiro = new Peca[8, 8];
        private bool _podeDesfazer = false;
        public bool PodeDesfazer { get => _podeDesfazer; }

        public Campo(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
        {
            // _inicializarPeoes();
            // _inicializarTorres();
            // _inicializarCavalos();
            // _inicializarBispos();
            // _inicializarRainha();
            // _inicializarRei();
            // CriarRegistros();
            // ArrumarTranslacao();

            // for (int i = 0; i < 8; i++)
            // {
            //     for (int j = 0; j < 8; j++)
            //     {
            //         // if (Tabuleiro[i, j] != null)
            //         // {
            //         //     if (Tabuleiro[i, j].Cor == COR.BRANCO)
            //         //     {
            //         //         var a = Tabuleiro[i, j].MovimentosPossiveis(Tabuleiro, Pretas);
            //         //         Tabuleiro[i, j].Movimentar(a?[0], Tabuleiro);
            //         //     }
            //         //     else
            //         //     {
            //         //         var a = Tabuleiro[i, j].MovimentosPossiveis(Tabuleiro, Brancas);
            //         //         Tabuleiro[i, j].Movimentar(a?[0], Tabuleiro);
            //         //     }
            //         // }
            //         Console.Write(Tabuleiro[i, j] + ", ");
            //     }
            //     Console.WriteLine();
            // }
            // // var piroquinha = Tabuleiro[0, 1].MovimentosPossiveis(Tabuleiro, Pretas);
            // // MoverPeca(Tabuleiro[0, 1], piroquinha[0]);
            // // var pirocao = Tabuleiro[0, 0].MovimentosPossiveis(Tabuleiro, Pretas);

            // Console.WriteLine();
            // for (int i = 0; i < 8; i++)
            // {
            //     for (int j = 0; j < 8; j++)
            //     {
            //         // if (Tabuleiro[i, j] != null)
            //         // {
            //         //     if (Tabuleiro[i, j].Cor == COR.BRANCO)
            //         //     {
            //         //         var a = Tabuleiro[i, j].MovimentosPossiveis(Tabuleiro, Pretas);
            //         //         Tabuleiro[i, j].Movimentar(a?[0], Tabuleiro);
            //         //     }
            //         //     else
            //         //     {
            //         //         var a = Tabuleiro[i, j].MovimentosPossiveis(Tabuleiro, Brancas);
            //         //         Tabuleiro[i, j].Movimentar(a?[0], Tabuleiro);
            //         //     }
            //         // }
            //         Console.Write(Tabuleiro[i, j] + ", ");
            //     }
            //     Console.WriteLine();
            // }
        }

        protected override void DesenharObjeto()
        {
            // CriarTabuleiro();

            Cubo obj_Cubo = new Cubo("F", null);
            // obj_Cubo.EscalaXYZ(50, 20, 50);
            FilhoAdicionar(obj_Cubo);

            Cubo obj_Cubo2 = new Cubo("F", null);
            // obj_Cubo2.EscalaXYZ(50, 20, 50);
            obj_Cubo2.TranslacaoXYZ(0, 0, 75);
            FilhoAdicionar(obj_Cubo2);
        }

        private void CriarTabuleiro()
        {
            int transladarX = 0;
            int transladarZ = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Cubo cubo = new Cubo(i + ":" + j, null, false);
                    // cubo.EscalaXYZ(50, 10, 50);
                    cubo.TranslacaoXYZ(transladarX, 0, transladarZ);
                    FilhoAdicionar(cubo);
                    transladarX += 75;
                }
                transladarZ += 75;
                transladarX = 0;
            }
        }

        public void ArrumarTranslacao()
        {
            int transladarX = 0;
            int transladarZ = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cubo cubo = Tabuleiro[i, j].Cubo;
                    cubo.TranslacaoXYZ(transladarX, 0, transladarZ);
                    FilhoAdicionar(cubo);
                    transladarX += 75;
                }
                transladarZ += 75;
                transladarX = 0;
            }
        }

        public void CriarRegistros()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    RegistroObjeto registroObjeto = new RegistroObjeto()
                    {
                        Cubo = new Cubo("ChaoPeao", null),
                        Peca = null,
                        PosicaoTabuleiroX = i,
                        PosicaoTabuleiroY = j
                    };

                    Tabuleiro[i, j] = registroObjeto;
                }
            }
        }

        // public void MoverPeca(Peca peca, Coordenada coordenada)
        // {
        //     var pecaDestino = Tabuleiro[coordenada.X, coordenada.Y];

        //     // _guardarEstado();
        //     _podeDesfazer = true;

        //     if (pecaDestino != null)
        //     {
        //         if (pecaDestino.Cor == COR.PRETO)
        //         {
        //             Pretas.Remove(pecaDestino);
        //         }
        //         else if (pecaDestino.Cor == COR.BRANCO)
        //         {
        //             Brancas.Remove(pecaDestino);
        //         }

        //     }
        //     Tabuleiro[peca.X, peca.Y] = null;

        //     peca.Movimentar(coordenada, Tabuleiro);

        //     Tabuleiro[coordenada.X, coordenada.Y] = peca;
        // }


        // public void Desfazer()
        // {
        //     Brancas.Clear();
        //     Pretas.Clear();
        //     Array.Clear(Tabuleiro, 0, 8);

        //     Brancas.AddRange(_desfazerBrancas);
        //     Pretas.AddRange(_desfazerPretas);
        //     Tabuleiro.CopyTo(_desfazerTabuleiro, 0);

        //     _podeDesfazer = false;
        // }

        // private void _guardarEstado()
        // {
        //     _desfazerBrancas.Clear();
        //     _desfazerPretas.Clear();
        //     Array.Clear(_desfazerTabuleiro, 0, 8);

        //     _desfazerBrancas.AddRange(Brancas);
        //     _desfazerPretas.AddRange(Pretas);
        //     Tabuleiro.CopyTo(_desfazerTabuleiro, 0);
        // }
        private void _inicializarPeoes()
        {
            for (int i = 0; i < 8; i++)
            {
                RegistroObjeto registroObjetoBranco = new RegistroObjeto()
                {
                    Cubo = new Cubo("ChaoPeao", null),
                    Peca = new Peao(i, 1, COR.BRANCO),
                    PosicaoTabuleiroX = i,
                    PosicaoTabuleiroY = 1
                };
                Brancas.Add(registroObjetoBranco.Peca);

                RegistroObjeto registroObjetoPreto = new RegistroObjeto()
                {
                    Cubo = new Cubo("ChaoPeao", null),
                    Peca = new Peao(i, 6, COR.PRETO),
                    PosicaoTabuleiroX = i,
                    PosicaoTabuleiroY = 6
                };
                Pretas.Add(registroObjetoPreto.Peca);

                Tabuleiro[i, 1] = registroObjetoBranco;
                Tabuleiro[i, 6] = registroObjetoPreto;

                // FilhoAdicionar(registroObjetoBranco.Cubo);
                // FilhoAdicionar(registroObjetoPreto.Cubo);
            }
        }

        private void _inicializarTorres()
        {
            RegistroObjeto registroObjetoTorreBrancaEsquerda = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Torre(0, 0, COR.BRANCO),
                PosicaoTabuleiroX = 0,
                PosicaoTabuleiroY = 0
            };
            Brancas.Add(registroObjetoTorreBrancaEsquerda.Peca);

            RegistroObjeto registroObjetoTorreBrancaDireta = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Torre(7, 0, COR.BRANCO),
                PosicaoTabuleiroX = 7,
                PosicaoTabuleiroY = 0
            };
            Brancas.Add(registroObjetoTorreBrancaDireta.Peca);

            Tabuleiro[0, 0] = registroObjetoTorreBrancaEsquerda;
            Tabuleiro[7, 0] = registroObjetoTorreBrancaDireta;

            // FilhoAdicionar(registroObjetoTorreBrancaEsquerda.Cubo);
            // FilhoAdicionar(registroObjetoTorreBrancaDireta.Cubo);

            RegistroObjeto registroObjetoTorrePretaEsquerda = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Torre(0, 7, COR.PRETO),
                PosicaoTabuleiroX = 0,
                PosicaoTabuleiroY = 7
            };
            Pretas.Add(registroObjetoTorrePretaEsquerda.Peca);

            RegistroObjeto registroObjetoTorrePretaDireita = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Torre(7, 7, COR.PRETO),
                PosicaoTabuleiroX = 7,
                PosicaoTabuleiroY = 7
            };
            Pretas.Add(registroObjetoTorrePretaDireita.Peca);

            Tabuleiro[0, 7] = registroObjetoTorrePretaEsquerda;
            Tabuleiro[7, 7] = registroObjetoTorrePretaDireita;

            // FilhoAdicionar(registroObjetoTorrePretaEsquerda.Cubo);
            // FilhoAdicionar(registroObjetoTorrePretaDireita.Cubo);
        }

        private void _inicializarCavalos()
        {
            RegistroObjeto registroObjetoCavaloBrancoEsquerdo = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Cavalo(1, 0, COR.BRANCO),
                PosicaoTabuleiroX = 1,
                PosicaoTabuleiroY = 0
            };
            Brancas.Add(registroObjetoCavaloBrancoEsquerdo.Peca);

            RegistroObjeto registroObjetoCavaloBrancoDireito = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Cavalo(6, 0, COR.BRANCO),
                PosicaoTabuleiroX = 6,
                PosicaoTabuleiroY = 0
            };
            Brancas.Add(registroObjetoCavaloBrancoDireito.Peca);

            Tabuleiro[1, 0] = registroObjetoCavaloBrancoEsquerdo;
            Tabuleiro[6, 0] = registroObjetoCavaloBrancoDireito;

            // FilhoAdicionar(registroObjetoCavaloBrancoEsquerdo.Cubo);
            // FilhoAdicionar(registroObjetoCavaloBrancoDireito.Cubo);

            RegistroObjeto registroObjetoCavaloPretoEsquerdo = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Cavalo(1, 7, COR.PRETO),
                PosicaoTabuleiroX = 1,
                PosicaoTabuleiroY = 7
            };
            Pretas.Add(registroObjetoCavaloPretoEsquerdo.Peca);

            RegistroObjeto registroObjetoCavaloPretoDireito = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Cavalo(6, 7, COR.PRETO),
                PosicaoTabuleiroX = 6,
                PosicaoTabuleiroY = 7
            };
            Pretas.Add(registroObjetoCavaloPretoDireito.Peca);

            Tabuleiro[1, 7] = registroObjetoCavaloPretoEsquerdo;
            Tabuleiro[6, 7] = registroObjetoCavaloPretoDireito;

            // FilhoAdicionar(registroObjetoCavaloPretoEsquerdo.Cubo);
            // FilhoAdicionar(registroObjetoCavaloPretoDireito.Cubo);
        }

        private void _inicializarBispos()
        {
            RegistroObjeto registroObjetoBispoBrancoEsquerdo = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Bispo(2, 0, COR.BRANCO),
                PosicaoTabuleiroX = 2,
                PosicaoTabuleiroY = 0
            };
            Brancas.Add(registroObjetoBispoBrancoEsquerdo.Peca);

            RegistroObjeto registroObjetoBispoBrancoDireito = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Bispo(5, 0, COR.BRANCO),
                PosicaoTabuleiroX = 5,
                PosicaoTabuleiroY = 0
            };
            Brancas.Add(registroObjetoBispoBrancoDireito.Peca);

            Tabuleiro[2, 0] = registroObjetoBispoBrancoEsquerdo;
            Tabuleiro[5, 0] = registroObjetoBispoBrancoDireito;

            // FilhoAdicionar(registroObjetoBispoBrancoEsquerdo.Cubo);
            // FilhoAdicionar(registroObjetoBispoBrancoDireito.Cubo);

            RegistroObjeto registroObjetoBispoPretoEsquerdo = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Bispo(2, 7, COR.PRETO),
                PosicaoTabuleiroX = 2,
                PosicaoTabuleiroY = 7
            };
            Pretas.Add(registroObjetoBispoPretoEsquerdo.Peca);

            RegistroObjeto registroObjetoBiscoPretoDireito = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Bispo(5, 7, COR.PRETO),
                PosicaoTabuleiroX = 5,
                PosicaoTabuleiroY = 7
            };
            Pretas.Add(registroObjetoBiscoPretoDireito.Peca);

            Tabuleiro[2, 7] = registroObjetoBispoPretoEsquerdo;
            Tabuleiro[5, 7] = registroObjetoBiscoPretoDireito;

            // FilhoAdicionar(registroObjetoBispoPretoEsquerdo.Cubo);
            // FilhoAdicionar(registroObjetoBiscoPretoDireito.Cubo);
        }

        private void _inicializarRainha()
        {
            RegistroObjeto registroObjetoRainhaBranca = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Rainha(3, 0, COR.BRANCO),
                PosicaoTabuleiroX = 3,
                PosicaoTabuleiroY = 0
            };
            Brancas.Add(registroObjetoRainhaBranca.Peca);

            RegistroObjeto registroObjetoRainhaPreta = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Rainha(3, 7, COR.PRETO),
                PosicaoTabuleiroX = 3,
                PosicaoTabuleiroY = 7
            };
            Pretas.Add(registroObjetoRainhaPreta.Peca);

            Tabuleiro[3, 0] = registroObjetoRainhaBranca;
            Tabuleiro[3, 7] = registroObjetoRainhaPreta;

            // FilhoAdicionar(registroObjetoRainhaBranca.Cubo);
            // FilhoAdicionar(registroObjetoRainhaPreta.Cubo);
        }

        private void _inicializarRei()
        {
            RegistroObjeto registroObjetoReiBranco = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Rei(4, 0, COR.BRANCO),
                PosicaoTabuleiroX = 4,
                PosicaoTabuleiroY = 0
            };
            Brancas.Add(registroObjetoReiBranco.Peca);

            RegistroObjeto registroObjetoReiPreto = new RegistroObjeto()
            {
                Cubo = new Cubo("ChaoPeao", null),
                Peca = new Rei(4, 7, COR.PRETO),
                PosicaoTabuleiroX = 4,
                PosicaoTabuleiroY = 7
            };
            Pretas.Add(registroObjetoReiPreto.Peca);

            Tabuleiro[4, 0] = registroObjetoReiBranco;
            Tabuleiro[4, 7] = registroObjetoReiPreto;

            // FilhoAdicionar(registroObjetoReiBranco.Cubo);
            // FilhoAdicionar(registroObjetoReiPreto.Cubo);
        }
    }
}