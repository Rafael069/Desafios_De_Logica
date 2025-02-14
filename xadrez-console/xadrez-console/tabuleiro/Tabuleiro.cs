
namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        // Estrutura de dados Matriz
        private Peca[,] pecas;

        public Tabuleiro(int linhas,int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        // Encapsulamento como é privado eu faço uma função pra poder 
        // ter acesso ao meu método
        public Peca peca(int linha,int coluna)
        {
            return pecas[linha, coluna];
        }

        // Sobrecarga

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha,pos.coluna];
        }


        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }


        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }


        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }

            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }


        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha<0 || pos.linha>=linhas || pos.coluna<0 || pos.coluna>=colunas)
            {
                return false;
            }

            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            // Se a minha excessão pos não for valida eu lanço excessão
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição invalida");
            }
        }
    }
}
