using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7
{

  public  class Aluno
    {
        public string Nome;
        public double Nota1;
        public double Nota2;
        public double Nota3;


      public double NotFinal()

        {
            return Nota1 + Nota2 + Nota3;
        }


      public bool Aprovado()
        {
            if (NotFinal() >= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Restante()
        {
            if (Aprovado() == false)
            {
                return 60 - NotFinal();
            }
            else
            {
                return 0.0;
            }
        }

    }
}
