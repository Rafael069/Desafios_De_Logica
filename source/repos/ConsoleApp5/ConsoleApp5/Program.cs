using System;
using System.Globalization;

namespace ConsoleApp5
{
    class Program
    {
       public 
            static void Main(string[] args)
        {
            Produto p = new Produto();
            
            Console.WriteLine("Entre com os dados do produto: ");
            Console.Write("Nome:");
            p.Nome = Console.ReadLine();
            Console.Write("Preço:");
            p.Preco = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            p.Quantidade = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.WriteLine("Dados do Produto: " + p);
            Console.WriteLine();

            Console.Write("Digite o número de produtos a ser adicionados ao estoque: ");
            int qte = int.Parse(Console.ReadLine());
            p.AdicionarProdutos(qte);

            Console.WriteLine();
            Console.WriteLine("Dados Atualizados: " + p);

            Console.WriteLine("Digite o número de produtos a ser removidos do estoque:");
            qte = int.Parse(Console.ReadLine());
            p.RemoverProdutos(qte);

            Console.WriteLine();

            Console.WriteLine("Dados Atualizados: "+ p);

            Console.ReadLine();
        }
    }
}
