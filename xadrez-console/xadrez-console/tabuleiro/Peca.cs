using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
   abstract class Peca
    {
        public Posicao posicao { get; set; }

        // pode ser acessado por outras classes mas pra modificar
        // só por ela msm e sub classes
        public Cor cor { get; protected set; }

        // pode ser acessado por outras classes mas pra modificar
        // só por ela msm e sub classes
        public int qteMovimentos { get; protected set; }

        // pode ser acessado por outras classes mas pra modificar
        // só por ela msm e sub classes
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab,Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
            
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }



        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public bool movimentoPossivel(Posicao pos)
        {
            // vai pegar os movimentos possiveis dessa peça
            // e testar na matriz essa linha e coluna é verdadeira
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        #region "Explicação do método movimentosPossiveis"
        // vai ter que me retornar uma matriz de booleano
        // Método abstrato é um método que não tem implementação nessa classe 
        // se uma classe possui um método abstrato automaticamente ela é abstrata
        // com abstract nao precisa colocar o virtual pq automaticamente ele será
        // usado no polimorfismo
        #endregion

        public abstract bool[,] movimentosPossiveis();
        
    }
}
