using System;
using Course.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Course
{
    class Program
    {
        // Função Auxiliar
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }



        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };


            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer" , Price= 1100.0 , Category = c2},
                new Product() { Id = 2, Name = "Hammer" , Price= 90.0 , Category = c1},
                new Product() { Id = 3, Name = "TV" , Price= 1700.0 , Category = c3},
                new Product() { Id = 4, Name = "Notebook" , Price= 1300.0 , Category = c2},
                new Product() { Id = 5, Name = "Saw" , Price= 80.0 , Category = c1},
                new Product() { Id = 6, Name = "Tablet" , Price= 700.0 , Category = c2},
                new Product() { Id = 7, Name = "Camera" , Price= 700.0 , Category = c3},
                new Product() { Id = 8, Name = "Printer" , Price= 350.0 , Category = c3},
                new Product() { Id = 9, Name = "MacBook" , Price= 1800.0 , Category = c2},
                new Product() { Id = 10, Name = "Sound Bar" , Price= 700.0 , Category = c3},
                new Product() { Id = 11, Name = "Level" , Price= 70.0 , Category = c1},
            };


            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            //Console.WriteLine("TIER 1 AND PRICE <900");
            Print("TIER 1 AND PRICE <900:", r1);


            // Nomes dos Produtos da Categoria TOOLS

            // Mas como só quero os nomes dos produtos e não o nome do OBJETO INTEIRO
            // Eu utilizo select
            var r2 = products.Where(p => p.Category.Name == "TOOLS").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);


            // Começando com a Letra C
            // Eu vou querer o nome, preço e nome da categoria
            // No select eu decido por um objeto anônimo
            // Utilizo um Alias no Category Name pra não repetir
            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new {p.Name, p.Price, CategoryName = p.Category.Name});
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT ", r3);

            // COM O TIER 1
            // Usando ordenação
            // E o Then BY seria uma segunda ordenação
            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);


            // Skip muito usando em paginação
            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            // Pegando elementos
            var r6 = products.FirstOrDefault();
            Console.WriteLine("First or default test1: " + r6);
            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("First or default test2: " + r7);
            Console.WriteLine();

            var r8 = products.Where(p => p.Id ==3).SingleOrDefault();
            Console.WriteLine("Single or default test1: " + r8);

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("Single or default test1: " + r9);
            Console.WriteLine();

            // Agregações
            // Máximo Produto com base no preço

            var r10 = products.Max(p => p.Price);
            Console.WriteLine("Max price: " + r10);

            // Minimo
            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Max price: " + r11);

            // Produtoes com tier 1 e depois faço a somatória do preço deles
            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 Sum prices: " + r12);

            // Média
            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1 Average prices: " + r13);

            // Tratando pra média não ser uma coleção vazia
            // Se o resultado depois de select for vazio ai o DefaultIfEmpty aplicar o zero
            // Assim não estora excessão
            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Category 5 Average prices: " + r14);

            // Função Agregate
            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0,(x,y) => x + y);
            Console.WriteLine("Category 1 Aggregate SUM: " + r15);
            Console.WriteLine();

            // Agrupando por categoria
            // Key é uma Categoria
            var r16 = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine("Category " + group.Key.Name + ":");
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

        }
    }
}
