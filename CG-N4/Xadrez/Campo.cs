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
        private Peca _pecaSelecionada;
        private int _posicaoPecaSelecionadaNaLista;

        public enum ORDEM { ANTERIOR, POSTERIOR }

        public Campo(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
        {
            InicializarPeoes();
            InicializarTorres();
            InicializarCavalos();
            InicializarBispos();
            InicializarRainha();
            InicializarRei();
            CriarObjetosVazios();
            CriarTabuleiro();
        }

        protected override void DesenharObjeto() { }

        private void CriarTabuleiro()
        {
            int transladarX = 0;
            int transladarZ = 0;
            bool corPreta = true;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    RegistroObjeto registroObjeto = Tabuleiro[i, j];
                    COR cor = COR.BRANCO;

                    if (!corPreta)
                    {
                        cor = COR.PRETO;
                    }

                    if (registroObjeto != null)
                    {
                        registroObjeto.Chao.AjustarCor(cor);
                        registroObjeto.AjustarInformacoes(transladarX, transladarZ);
                        FilhoAdicionar(registroObjeto.Chao);

                        if (registroObjeto.Peca != null)
                        {
                            FilhoAdicionar(registroObjeto.Peca);
                        }
                    }

                    transladarX += 100;
                    corPreta = !corPreta;
                }

                transladarZ += 100;
                transladarX = 0;
                corPreta = !corPreta;
            }
        }

        public void CriarObjetosVazios()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    RegistroObjeto registroObjetoVazio = new RegistroObjeto();
                    registroObjetoVazio.Chao = new Cubo("Chao", null, COR.BRANCO);
                    registroObjetoVazio.Peca = null;
                    Tabuleiro[i, j] = registroObjetoVazio;
                }
            }
        }

        public void RetornarPecaSelecionada(COR corJogadorDaVez, ORDEM ordem)
        {
            List<int> listaPosicoes = new List<int>(RetornarListaDePosicoes(corJogadorDaVez));
            int posicaoAtual = 0;

            if (_pecaSelecionada == null)
            {
                _pecaSelecionada = (Peca)RetornarListaObjetos()[listaPosicoes[posicaoAtual]];
                _pecaSelecionada.SelecionarPeca();
            }
            else
            {
                posicaoAtual = RetornarListaObjetos().IndexOf(_pecaSelecionada);
                posicaoAtual = listaPosicoes.IndexOf(posicaoAtual);
                _pecaSelecionada.DesselecionarPeca();
                int novaPosicao = 0;

                switch (ordem)
                {
                    case ORDEM.ANTERIOR:
                        if (posicaoAtual == 0)
                        {
                            novaPosicao = listaPosicoes.Count - 1;
                        }
                        else
                        {
                            novaPosicao = posicaoAtual - 1;
                        }
                        break;
                    case ORDEM.POSTERIOR:
                        if (posicaoAtual == (listaPosicoes.Count - 1))
                        {
                            novaPosicao = 0;
                        }
                        else
                        {
                            novaPosicao = posicaoAtual + 1;
                        }
                        break;
                }

                _pecaSelecionada = (Peca)RetornarListaObjetos()[listaPosicoes[novaPosicao]];
                _pecaSelecionada.SelecionarPeca();
            }
        }

        public void MoverPeca()
        {
            if (_pecaSelecionada != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        RegistroObjeto registro = Tabuleiro[i, j];

                        if (registro.TranslacaoX == _pecaSelecionada.TranslacaoX
                            && registro.TranslacaoZ == _pecaSelecionada.TranslacaoZ)
                        {
                            registro.Peca = null;

                            RegistroObjeto registroMigracao = Tabuleiro[i + 1, j - 1];
                            registroMigracao.Peca = _pecaSelecionada;
                            _pecaSelecionada.TranslacaoXYZ(registroMigracao.TranslacaoX, 0, registroMigracao.TranslacaoZ);
                        }
                    }
                }
            }
        }

        private IEnumerable<int> RetornarListaDePosicoes(COR corJogadorDaVez)
        {
            foreach (Objeto objeto in RetornarListaObjetos())
            {
                if (objeto is Peca && ((Peca)objeto).Cor.Equals(corJogadorDaVez))
                {
                    yield return RetornarListaObjetos().IndexOf(objeto);
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

        private void InicializarPeoes()
        {
            for (int i = 0; i < 8; i++)
            {
                RegistroObjeto registroObjetoBranco = new RegistroObjeto();
                registroObjetoBranco.Chao = new Cubo("Chao", null, COR.BRANCO);
                registroObjetoBranco.Peca = new Peao($"Peao_B_{i}", i, 1, COR.BRANCO);
                Brancas.Add(registroObjetoBranco.Peca);

                RegistroObjeto registroObjetoPreto = new RegistroObjeto();
                registroObjetoPreto.Chao = new Cubo("Chao", null, COR.BRANCO);
                registroObjetoPreto.Peca = new Peao($"Peao_P_{i}", i, 6, COR.PRETO);
                Pretas.Add(registroObjetoPreto.Peca);

                Tabuleiro[i, 1] = registroObjetoBranco;
                Tabuleiro[i, 6] = registroObjetoPreto;
            }
        }

        private void InicializarTorres()
        {
            RegistroObjeto registroObjetoTorreBrancaEsquerda = new RegistroObjeto();
            registroObjetoTorreBrancaEsquerda.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoTorreBrancaEsquerda.Peca = new Torre("Torre_B_E", 0, 0, COR.BRANCO);
            Brancas.Add(registroObjetoTorreBrancaEsquerda.Peca);

            RegistroObjeto registroObjetoTorreBrancaDireta = new RegistroObjeto();
            registroObjetoTorreBrancaDireta.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoTorreBrancaDireta.Peca = new Torre("Torre_B_D", 7, 0, COR.BRANCO);
            Brancas.Add(registroObjetoTorreBrancaDireta.Peca);

            Tabuleiro[0, 0] = registroObjetoTorreBrancaEsquerda;
            Tabuleiro[7, 0] = registroObjetoTorreBrancaDireta;

            RegistroObjeto registroObjetoTorrePretaEsquerda = new RegistroObjeto();
            registroObjetoTorrePretaEsquerda.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoTorrePretaEsquerda.Peca = new Torre("Torre_P_E", 0, 7, COR.PRETO);
            Pretas.Add(registroObjetoTorrePretaEsquerda.Peca);

            RegistroObjeto registroObjetoTorrePretaDireita = new RegistroObjeto();
            registroObjetoTorrePretaDireita.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoTorrePretaDireita.Peca = new Torre("Torre_P_D", 7, 7, COR.PRETO);
            Pretas.Add(registroObjetoTorrePretaDireita.Peca);

            Tabuleiro[0, 7] = registroObjetoTorrePretaEsquerda;
            Tabuleiro[7, 7] = registroObjetoTorrePretaDireita;
        }

        private void InicializarCavalos()
        {
            RegistroObjeto registroObjetoCavaloBrancoEsquerdo = new RegistroObjeto();
            registroObjetoCavaloBrancoEsquerdo.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoCavaloBrancoEsquerdo.Peca = new Cavalo("Cavalo_B_E", 1, 0, COR.BRANCO);
            Brancas.Add(registroObjetoCavaloBrancoEsquerdo.Peca);

            RegistroObjeto registroObjetoCavaloBrancoDireito = new RegistroObjeto();
            registroObjetoCavaloBrancoDireito.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoCavaloBrancoDireito.Peca = new Cavalo("Cavalo_B_D", 6, 0, COR.BRANCO);
            Brancas.Add(registroObjetoCavaloBrancoDireito.Peca);

            Tabuleiro[1, 0] = registroObjetoCavaloBrancoEsquerdo;
            Tabuleiro[6, 0] = registroObjetoCavaloBrancoDireito;

            RegistroObjeto registroObjetoCavaloPretoEsquerdo = new RegistroObjeto();
            registroObjetoCavaloPretoEsquerdo.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoCavaloPretoEsquerdo.Peca = new Cavalo("Cavalo_P_E", 1, 7, COR.PRETO);
            Pretas.Add(registroObjetoCavaloPretoEsquerdo.Peca);

            RegistroObjeto registroObjetoCavaloPretoDireito = new RegistroObjeto();
            registroObjetoCavaloPretoDireito.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoCavaloPretoDireito.Peca = new Cavalo("Cavalo_P_D", 6, 7, COR.PRETO);
            Pretas.Add(registroObjetoCavaloPretoDireito.Peca);

            Tabuleiro[1, 7] = registroObjetoCavaloPretoEsquerdo;
            Tabuleiro[6, 7] = registroObjetoCavaloPretoDireito;
        }

        private void InicializarBispos()
        {
            RegistroObjeto registroObjetoBispoBrancoEsquerdo = new RegistroObjeto();
            registroObjetoBispoBrancoEsquerdo.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoBispoBrancoEsquerdo.Peca = new Bispo("Bispo_B_E", 2, 0, COR.BRANCO);
            Brancas.Add(registroObjetoBispoBrancoEsquerdo.Peca);

            RegistroObjeto registroObjetoBispoBrancoDireito = new RegistroObjeto();
            registroObjetoBispoBrancoDireito.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoBispoBrancoDireito.Peca = new Bispo("Bispo_B_D", 5, 0, COR.BRANCO);
            Brancas.Add(registroObjetoBispoBrancoDireito.Peca);

            Tabuleiro[2, 0] = registroObjetoBispoBrancoEsquerdo;
            Tabuleiro[5, 0] = registroObjetoBispoBrancoDireito;

            RegistroObjeto registroObjetoBispoPretoEsquerdo = new RegistroObjeto();
            registroObjetoBispoPretoEsquerdo.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoBispoPretoEsquerdo.Peca = new Bispo("Bispo_P_E", 2, 7, COR.PRETO);
            Pretas.Add(registroObjetoBispoPretoEsquerdo.Peca);

            RegistroObjeto registroObjetoBiscoPretoDireito = new RegistroObjeto();
            registroObjetoBiscoPretoDireito.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoBiscoPretoDireito.Peca = new Bispo("Bispo_P_D", 5, 7, COR.PRETO);
            Pretas.Add(registroObjetoBiscoPretoDireito.Peca);

            Tabuleiro[2, 7] = registroObjetoBispoPretoEsquerdo;
            Tabuleiro[5, 7] = registroObjetoBiscoPretoDireito;
        }

        private void InicializarRainha()
        {
            RegistroObjeto registroObjetoRainhaBranca = new RegistroObjeto();
            registroObjetoRainhaBranca.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoRainhaBranca.Peca = new Rainha("Rainha_B", 3, 0, COR.BRANCO);
            Brancas.Add(registroObjetoRainhaBranca.Peca);

            RegistroObjeto registroObjetoRainhaPreta = new RegistroObjeto();
            registroObjetoRainhaPreta.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoRainhaPreta.Peca = new Rainha("Rainha_P", 3, 7, COR.PRETO);
            Pretas.Add(registroObjetoRainhaPreta.Peca);

            Tabuleiro[3, 0] = registroObjetoRainhaBranca;
            Tabuleiro[3, 7] = registroObjetoRainhaPreta;
        }

        private void InicializarRei()
        {
            RegistroObjeto registroObjetoReiBranco = new RegistroObjeto();
            registroObjetoReiBranco.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoReiBranco.Peca = new Rei("Rei_B", 4, 0, COR.BRANCO);
            Brancas.Add(registroObjetoReiBranco.Peca);

            RegistroObjeto registroObjetoReiPreto = new RegistroObjeto();
            registroObjetoReiPreto.Chao = new Cubo("Chao", null, COR.BRANCO);
            registroObjetoReiPreto.Peca = new Rei("Rei_P", 4, 7, COR.PRETO);
            Pretas.Add(registroObjetoReiPreto.Peca);

            Tabuleiro[4, 0] = registroObjetoReiBranco;
            Tabuleiro[4, 7] = registroObjetoReiPreto;
        }
    }
}