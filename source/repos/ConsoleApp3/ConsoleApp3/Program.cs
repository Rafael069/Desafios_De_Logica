using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] vetor = new int []{14,12,11,13,14,13,
                                     12,14,13,14,11,12,
                                     12,14,10,13,15,11,
                                     15,13,16,17,14,14};

            Array.Sort(vetor);

            for(int i = 0; i<24; i++)
            {
                Console.Write(vetor[i]+",");
            }

            

            Console.ReadLine();

        }
    }
}
