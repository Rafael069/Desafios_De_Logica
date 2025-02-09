using System;
using System.Collections.Generic;
using System.Text;

namespace ExRetangulo
{
    class Retangulo
    {
        public double Largura;
        public double Altura;


        public double Area ()
        {
            return Largura * Altura;
        }

        public double Perimetro ()
        {
            double p = 2 * (Largura + Altura);
            return p;
        }

        public double Diagonal()
        {
            return Math.Sqrt(Largura * Largura + Altura * Altura);         
        }

    }
}
