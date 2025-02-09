using System;
using System.Globalization;


namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno Robert = new Aluno();

            Console.Write("Nome do Aluno: ");
            Robert.Nome = Console.ReadLine();

            Console.WriteLine("Digite três notas: ");
            Robert.Nota1 = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Robert.Nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Robert.Nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.WriteLine("Nota Final: " + Robert.NotFinal(),CultureInfo.InvariantCulture);
            if (Robert.Aprovado() == true)
            {
                Console.WriteLine("Aprovado");
            }
            else
            {
                Console.WriteLine("Reprovado");
                Console.WriteLine("Faltaram: "+ Robert.Restante());
            }
            Console.ReadLine();
        }
    }
}
