using System;
using System.Globalization;

namespace Secao4Udemy
{
    class Program
    {
        static void Main(string[] args)
        {
            //instanciacao da classe Triangulo
            Triangulo x = new Triangulo();

            //uso de Parse para conversao de ReadLine
            //uso de InvariantCulture para leitura de dado independentemente do idioma do sistema
            x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            /////////////////////////
            // Uso de classe estática
            /////////////////////////
            
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // a calculadora pôde ser instanciada porque não foi declarada como static
            Calculadora calc = new Calculadora();

            //circ e volume apenas recebem chamadas direto dos métodos estáticos (utilitários)
            double circ = Calculadora.Circunferencia(raio);
            double volume = Calculadora.Volume(raio);

            Console.WriteLine("Circunferência: " + circ.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
