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

            Produto p4 = new Produto { 
                Nome = nome,
                Preco = preco, 
                Quantidade = quantidade 
            };

            //////////////////////////////
            
            var prod1 = new ProdutoEncapsula1();
            prod1.SetNome("Produto1");
            var nomeProd1 = prod1.GetNome();

            var prod2 = new ProdutoEncapsulaProperties();
            prod2.Nome = "Produto2";
            var nomeProd2 = prod2.Nome;

            var prod3 = new ProdutoEncapsulaAutoproperties();
            prod3.Nome = "Produto3";
            var nomeProd3 = prod3.Nome;

        }
    }
}
