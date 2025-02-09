using System;
using System.Globalization;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto();



            Console.WriteLine("Entre com os dados do Produto: ");
            Console.Write("Nome: ");
            p.Nome = Console.ReadLine();
            Console.Write("Preço:");
            p.Preco = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            p.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados do Produto: " + p);


            Console.ReadLine();
        }
    }
}
