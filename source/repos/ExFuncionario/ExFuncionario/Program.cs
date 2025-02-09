using System;
using System.Globalization;

namespace ExFuncionario
{
    class Program
    {
       public  static void Main(string[] args)
        {

            Funcionario a = new Funcionario();

            Console.Write("Nome: ");
            a.Nome = Console.ReadLine();
            Console.Write("Salário Bruto: ");
            a.SalarioBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Imposto: ");
            a.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Funcionário: " + a);
            Console.Write("Digite a porcentagem para aumentar o salário:");
            double porce = double.Parse(Console.ReadLine());
            a.AumentarSalario(porce);

            Console.WriteLine();
            Console.WriteLine("Dados Atualizados: " + a);
            Console.ReadLine();
        }
    }
}
