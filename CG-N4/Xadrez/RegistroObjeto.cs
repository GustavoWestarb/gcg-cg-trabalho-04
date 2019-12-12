namespace gcgcg
{
    internal class RegistroObjeto
    {
        public Cubo Chao { get; set; }
        public Peca Peca { get; set; }
        public int TranslacaoX { get; set; }
        public int TranslacaoZ { get; set; }

        public RegistroObjeto() { }

        public void AjustarInformacoes(int translacaoX, int translacaoZ)
        {
            Chao.EscalaXYZ(50, 10, 50);
            Chao.TranslacaoXYZ(translacaoX, 0, translacaoZ);

            if (Peca != null)
            {
                Peca.EscalaXYZ(30, 70, 30);
                Peca.TranslacaoXYZ(translacaoX, 75, translacaoZ);
                Peca.TranslacaoX = translacaoX;
                Peca.TranslacaoZ = translacaoZ;
            }

            TranslacaoX = translacaoX;
            TranslacaoZ = translacaoZ;
        }
    }
}