using System;
using System.Globalization;

namespace ExAluno
{
    class Program
    {
    public static void Main(string[] args)
        {
            Aluno a1 = new Aluno();

            Console.WriteLine("Nome do Aluno: ");
            a1.Nome = Console.ReadLine();
            Console.WriteLine("Digite as três notas do Aluno: ");
            a1.Nota1 = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            a1.Nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            a1.Nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Console.WriteLine();

            Console.WriteLine("Nota Final = " + a1.NotaFinal().ToString("F2"),CultureInfo.InvariantCulture);

            if (a1.Aprovado())
            {
                Console.WriteLine("APROVADO");
            } else
            {
                Console.WriteLine("REPROVADO");
                Console.WriteLine("FALTARAM: "+a1.NotaRestante().ToString("F2"),CultureInfo.InvariantCulture+"PONTOS");
            }






            Console.ReadLine();
        }
    }
}
