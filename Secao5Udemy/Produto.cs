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


        //construtor: utilizado para inicializar valores dos atributos ou para permitir/obrigado que o objeto receba dados no momento de sua instanciação (injeção de dependencias)

        //sobrecarga: é um recurso que uma classe possuo de oferecer mais de uma operação com o mesmo nome, porém com diferentes listas de parâmetros

        //uso de this:
        //1 - diferenciar atributos de variáveis locais (mais usado em Java)
        //2 - referenciar outro construtor em um construtor
        //3 - passar o proprio objeto como argumento na chamada de um método ou construtor
        
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

        ////////////////////////////////////////////////

        // Encapsulamento
        // Esconder detalhes de implementação de um componente expondo apenas operações seguras e que o mantenha em um estado consistente





        ////////////////////////////////////////////////

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
