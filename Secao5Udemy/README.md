### A seção 5 do curso introduz construtores, palavra this, sobrecarga, encapsulamento

##### Construtores 

- A classe Produto apresenta três diferentes atributos:


```csharp
public string Nome;
public double Preco;
public int Quantidade;
```

Além disso, diversos tipos de construtores foram definidos, usando o princípio denominado sobre sobrecarga, que é um recurso que permite que uma classe possa oferecer mais de uma operação com mesmo nome, mas com listas diferentes de parâmetros. 

Um construtor por definição é usado para inicializar valores dos atributos ou permitir que o objeto receba dados na sua instanciação. O primeiro deles, chamado construtor padrão, já foi setado com o valor de quantidade como 10.

```csharp
public Produto()
{
    Quantidade = 10;
}
```

Outro possível construtor pode receber atributos como parâmetros, como no caso abaixo. Em todos os casos, uma boa prática é deixar os parâmetros inicializando em minúsculo, e os atributos em maiúsculo.

```csharp
public Produto(string nome, double preco, int quantidade)
{
    Nome = nome;
    Preco = preco;
    Quantidade = quantidade;
}
```

Caso um atributo não seja setado durante a implementação de um construtor, seu valor será automaticamente 0, como ocorre com Quantidade.

```csharp
public Produto(string nome, double preco)
{
    Nome = nome;
    Preco = preco;
}
```

##### Uso da palavra this

A palavra this contém diversos usos dentro da linguagem C#, como:

- Referenciar outro construtor em um construtor

Este ocorre se implementarmos por exemplo o construtor abaixo, o qual utiliza-se do construtor padrão para ser "extendido". Assim, quando for utilizado, já conterá o valor de Quantidade = 10, e deverá ser informado o valor de nome. O preço, no caso, terá valor padrão 0.0.

```csharp
public Produto(string nome) : this()
{
    Nome = nome;
}
```

- Diferenciar atributos de variáveis locais, mais utilizado em Java

Neste caso, o construtor seria utilizado da seguinte forma:

```csharp
// Na classe Produto.cs
public Produto(int Quantidade){
    this.Quantidade = Quantidade;
}

//Na classe Program.cs
Produto prod = new Produto(10);
```

O this.Quantidade se referiria a classe Produto (variável na Heap), e o 'prod' seria uma referência local, presente na Stack. A Stack possui tamanho menor que a Heap e é usada, por exemplo, para armazenar variáveis locais.  

##### Sintaxe alternativa de instanciação de valores 

Por fim, uma forma alternativa de se inicializar construtores é a seguinte. Para que funcione, o construtor padrão deve estar declarado na classe Produto ou mesmo que não esteja deve ser possível utilizá-lo no programa principal.

```csharp
//Na classe Program.cs
Produto p4 = new Produto { 
    Nome = nome,
    Preco = preco, 
    Quantidade = quantidade 
};
```