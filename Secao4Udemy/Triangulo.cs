//importacao de dependencias
using System;

//namespace da classe
namespace Secao4Udemy
{
    class Triangulo
    {
        //membros de classe: atributos ou metodos

        //atributos de classe em C# comecam com letra maiuscula
        public double A;
        public double B;
        public double C;

        //metodos em C# comecam com letra maiuscula
        public double Area()
        {
            double p = (A + B + C) / 2.0;
            return  Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
