using System;
using System.Globalization;

namespace ExRetangulo
{
    class Program
    {
      public  static void Main(string[] args)
        {
            Retangulo R1 = new Retangulo();

            Console.WriteLine("Entre com a largura e a altura do retângulo: ");

            R1.Largura = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            R1.Altura = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Console.WriteLine("Area: "+R1.Area().ToString("F2"),CultureInfo.InvariantCulture);
            Console.WriteLine("Perímetro: " + R1.Perimetro().ToString("F2"), CultureInfo.InvariantCulture);
            Console.WriteLine("Diagonal: " + R1.Diagonal().ToString("F2"), CultureInfo.InvariantCulture);

            Console.ReadLine();
        }
    }
}
