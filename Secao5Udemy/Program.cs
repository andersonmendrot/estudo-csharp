using System;
using System.Globalization;

namespace Secao5Udemy
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome = Console.ReadLine();
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int quantidade = int.Parse(Console.ReadLine());

            Produto p = new Produto(nome, preco, quantidade);
            Console.WriteLine(p);

            Produto p2 = new Produto(nome, preco);

            Produto p3 = new Produto();

            //Para que esta sintaxe alternativa funcione, o construtor padrão deve estar declarado na classe Produto ou mesmo que não esteja deve ser possível utilizá-lo
            Produto p4 = new Produto { 
                Nome = nome,
                Preco = preco, 
                Quantidade = quantidade 
            };
        }
    }
}
