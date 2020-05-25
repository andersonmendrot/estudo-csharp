using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Secao5Udemy
{
    //toda classe em C# é uma subclasse da classe Object
    //GetType, Equals, GetHashCode, ToString()
    class Produto
    {
        //atributos começam com letra maiúscula
        public string Nome;
        public double Preco;
        public int Quantidade;
        
        //construtor padrão
        public Produto()
        {
            Quantidade = 10;
        }

        //Referenciar outro construtor em um construtor
        public Produto(string nome) : this()
        {
            Nome = nome;
        }

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        //Quantidade já se inicializa com 0 
        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        //métodos começam com letra maiúscula
        public double ValorTotalEmEstoque()
        {
            return Preco * Quantidade;
        }

        public void AdicionarProdutos(int qtd)
        {
            Quantidade += qtd;
        }

        //sobreposição de metodo ToString da classe Object
        //'F2' retorna apenas duas casas decimais do valor double
        public override string ToString()
        {
            return $"{Nome}, ${Preco.ToString("F2", CultureInfo.InvariantCulture)}, ${Quantidade}";
        }
    }
}
