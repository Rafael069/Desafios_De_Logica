namespace IdadeEmDias
{
    class Program
    {
        static void Main(string[] args)
        {
            int idade = int.Parse(Console.ReadLine());

            int anos = idade / 365;
            int restoDias = idade % 365;

            int meses = restoDias / 30;
            int dias = restoDias % 30;

            Console.WriteLine(anos + " ano(s)");
            Console.WriteLine(meses + " mes(es)");
            Console.WriteLine(dias + " dia(s)");
        }
    }
}
