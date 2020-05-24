using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Secao4Udemy
{
    //toda classe em C# é uma subclasse da classe Object
    //GetType, Equals, GetHashCode, ToString()
    class Produto
    {
        //atributos começam com letra maiúscula
        public string Nome;
        public double Preco;
        public int Quantidade;

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
            return $"{Nome}, ${Preco.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
