using System;
using System.Globalization;

namespace ConsoleApp6
{
  public  class Program
    {
      public  static void Main(string[] args)
        {
            Funcionario p1 = new Funcionario();

            Console.WriteLine("Nome: ");
            p1.Nome = Console.ReadLine().ToString();

            Console.WriteLine("Salário Bruto: ");
            p1.SalarioBruto = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Console.WriteLine("Imposto: ");
            p1.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Funcionario: " + p1);
            Console.WriteLine();

            Console.Write("Digite a porcentagem  para aumentar o salario: ");
            double valorPorcentagem = double.Parse( Console.ReadLine());
            p1.AumentarSalario(valorPorcentagem);
            
            Console.WriteLine("Dados Atualizados: "+p1);
           
            
            
            

            Console.ReadLine();
        }
    }
}
