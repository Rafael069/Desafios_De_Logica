using System;
using System.Linq;

namespace Multiplos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numeros = Console.ReadLine().Split().Select(int.Parse).ToArray();



            int a = numeros[0];
            int b = numeros[1];


            if (a % b == 0 || b % a == 0)
            {
                Console.WriteLine("Sao Multiplos");
            }
            else
            {
                Console.WriteLine("Nao sao Multiplos");
            }

        }
    }
}
