

namespace tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        // palavra this é pra deixa claro pro compilador que ali é referência ao meu atributo
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public void definirValores(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        // passa objeto para string
        public override string ToString()
        {
            return linha
                   + ", "
                   + coluna;
        }


    }
}
