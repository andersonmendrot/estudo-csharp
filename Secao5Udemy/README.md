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

#### Encapsulamento

Esconder detalhes de implementação de componente de forma a expor apenas operações seguras e que o mantenha em um estado consistente.

Três formas de se fazer isso:

1. Implementação manual, *não* é usual em C#

- Implementa-se get/set para cada atributo de forma customizada e todo atributo é dito private.

```csharp
//Na classe Produto.cs
private string _nome;
private string _preco;
private int quantidade;

public string GetNome(){
    return _nome;
}

public string SetNome(string nome){
    if (nome != null & nome.Length > 1){
        _nome = nome;
    }
}

public string GetPreco(string preco){
    return _preco;
}

//Na classe Program.cs
Produto p = new Produto();
p.SetNome("Produto 1");
string nome = p.GetNome();
```

2. Uso de Properties

Uma propriedade é um membro que oferece um mecanismo flexível para ler, gravar ou calcular o valor de um campo particular. Elas podem ser usadas como se fossem atributos públicos, porém são métodos especiais chamados "acessadores" 

A palavra reservada *value* representa o parâmetro de entrada do método *set*

```csharp

//Na classe ProdutoEncapsulaProperties.cs
private string _nome;

public string Nome {
    get { return _nome; }
    set {
        if (value != null & value.Length > 1){
            _nome = nome;
         }
    }
}

//Na classe Program.cs
var prod2 = new ProdutoEncapsulaProperties();
prod2.Nome = "Produto2";
var nomeProd2 = prod2.Nome;

```

3. Uso de Autoproperties

Usado quando queremos declarar propriedades que não necessitam de lógicas particulares de *get* e *set*

```csharp
//Na classe ProdutoEncapsulaAutoProperties.cs
public string Nome { get; private set; }

//Na classe Program.cs
var prod3 = new ProdutoEncapsulaAutoproperties();
prod3.Nome = "Produto3";
var nomeProd3 = prod3.Nome;

```

### Ordem sugerida para implementação de classes 

Indicada em *ProdutoOrdemRecomendada.cs*

1. Atributos privados
2. Propriedades autoimplementadas
3. Construtores
4. Propriedades customizadas
5. Outros métodos da classe
