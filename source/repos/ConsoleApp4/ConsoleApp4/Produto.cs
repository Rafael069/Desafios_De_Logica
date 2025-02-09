using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ConsoleApp4
{
    class Produto
    {
        public string Nome;
        public double Preco;
        public int Quantidade;


        public double ValorTotalEmEstoque()
        {
            return Preco * Quantidade;
        }

        // - Sobreposição
        public override string ToString()
        {
            return Nome
                + ",$ "
                + Preco.ToString("F2", CultureInfo.InstalledUICulture)
                + ", "
                + Quantidade
                + "unidades, Total $ "
                + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }


    }
}
