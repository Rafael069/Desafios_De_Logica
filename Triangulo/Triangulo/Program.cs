using System;
using System.Globalization;

namespace Triangulo
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] entrada = Console.ReadLine().Split(' ');

            // Converte os valores para inteiros
            double a = double.Parse(entrada[0], CultureInfo.InvariantCulture);
            double b = double.Parse(entrada[1], CultureInfo.InvariantCulture);
            double c = double.Parse(entrada[2], CultureInfo.InvariantCulture);

            double perimetro = 0;
            double area = 0 ;

            // Verifica se os valores formam um triângulo
            if (a < b + c && b < a + c && c < a + b)
            {
                perimetro = a+ b + c;
                Console.WriteLine("Perimetro = " + perimetro.ToString("F1", CultureInfo.InvariantCulture));
            }
            else
            {
                // Se não forma um triângulo, calcula a área do trapézio
                // Sqrt significa raiz quadrada

                area = ((a + b) * c) / 2;
                Console.WriteLine("Area = " + area.ToString("F1", CultureInfo.InvariantCulture));

            }



        }
    }
}
