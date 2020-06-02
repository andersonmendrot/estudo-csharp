## O módulo 3 aborda tópicos como 
- Generics 
- Extensions
- Exceptions
- Coleções
- Linq e Lambda
- Leitura e escrita em arquivos textos (StreamReader/ StreamWriter)
- Extensão de metadados através de atributos
- Reflexão no .NET
- Acesso a atributos personalizados

## 1. Generics

Permite que classes, interfaces e métodos possam ser parametrizados por tipo, de forma que haja reuso, type safety e performance. Um exemplo clássico de uso é em coleções.

```csharp
List<int> lista = new List<int>();
lista.Add(10);
int numero = lista[0];
```

Uma forma genérica de se declarar uma classe é dada abaixo, como um exemplo para serviço de impressão. É utilizado o parâmetro *T*, de forma que a classe ao ser utilizada por outra possa aceitar qualquer tipo de valor. Dessa forma, é garantido que haja reúso por conta dessa escolha de valores, além de type safety, pois "poderíamos utilizar" object no lugar de T, porém isto impediria que o compilador avisasse sobre diferentes erros de conversão em outros pontos do programa, e de performance. 

```csharp
public class PrintService<T>
{
    private T[] _values = new T[10];
    private int _count = 0;

    public void AddValue(T value)
    {
        if(_count < 10)
        {
            _values[_count] = value;
            _count++;
        }
    }

    public T First()
    {
        return _values[0];
    }
}
```

Então no programa principal pode ser utilizado por exemplo o parâmetro *string*, ou *int*, etc.

```csharp
class Program
{
    static void Main(string[] args)
    {
        PrintService<string> printService = new PrintService<string>();
        printService.AddValue("Texto1");
        printService.AddValue("Texto2");

        PrintService<int> printService2 = new PrintService<int>();
        printService.AddValue(10);
        printService.AddValue(20);

        Console.WriteLine(printService.First());
    }
}
```

#### Restrição de Generics

Podemos restringir quais *classes* ou *métodos* podem utilizar os Generics com o uso da palavra *where*. Por exemplo, suponha que queremos que apenas as classes genéricas que implementam a interface ICalculoValor possam utilizar o Generics. Dessa forma, teriamos:

```csharp
public class CalculoGenerico<T> where T : ICalculoValor {
    private float _imposto = 0.05;
    private float _lucro = 0.10;

    public void CalcularValorUnitario(T obj){
        obj.ValorFinal += obj.ValorBruto;
        obj.ValorFinal += obj.ValorBruto * _imposto;
        obj.ValorFinal += obj.ValorBruto * _lucro;
    }
}
```

Uma classe exemplo DevDeSoftware que implementa ICalculoValor:

```csharp
public class DevDeSoftware : ICalculoValor
{
    public float ValorBruto { get; set; }
    public float ValorFinal { get; set; }

    public DevDeSoftware()
    {
        ValorBruto = 50;
    }
}
```

A classe principal:

```csharp
class Program
{
    static void Main(string[] args)
    {
        CalculoGenerico<DevDeSoftware> calculoGenerico = new CalculoGenerico<DevDeSoftware>();
        DevDeSoftware devDeSoftware = new DevDeSoftware();
        calculoGenerico.CalcularValorUnitario(devDeSoftware);
    }   
}
```

O método CalcularValorUnitario no programa principal pode então receber como tipo o DevDeSoftware (o que foi restrito pelo where). Se DevDeSoftware não implementasse ICalculoValor, isso não seria possível.

Outro exemplo de uso é quando queremos fazer isso com apenas um *método*. O exemplo abaixo utiliza, ao invés de ICalculoValor, a interface IComparable, como no exemplo, que retorna o maior item dentro da lista. O retorno da lista é um tipo T, a lista como parâmetro é parametrizada com o tipo T e a função também é. O método apenas funciona se T implementa IComparable. 

```csharp
class EmployeeService 
{
    public T Max<T>(List<T> list) where T: IComparable
    {
        T max = list[0];
        for(int i = 0; i < list.Count; i++)
        {
            if(list[i].CompareTo(max) > 0)
            {
                max = list[i];
            }
        }
        return max;
    }
}
```

Dado que Employee implementa IComparable, então ele poderia utilizar esse método, o qual poderia ser utilizado no programa principal da seguinte forma, e *max* conteria o empregado com o maior salário (critério que foi utilizado na implementação do CompareTo pela classe Employee).

```csharp
static void Main() {
    List<Employee> list = new List<Employee>();
    ...
    EmployeeService employeeService = new EmployeeService();
    Employee max = employeeService.Max(list);
}
```

## 2. Extension methods

Métodos que estendem a funcionalidade de um tipo, sem que seja necessário mudar o código fonte do tipo, nem herdar do tipo.

Passos:
1. Criar uma classe estática
2. Na classe, criar um método estático
3. O primeiro parâmetro do método deverá ter o prefixo this, seguido da declaração de um parâmetro do tipo que se deseja estender. Esta será uma referência pra o próprio objeto.

O exemplo abaixo cria um extension method que conta o número de palavras para o tipo *string*.

```csharp
public static class MeuExtensionMethodString
{
    public static int ContaPalavras(this string str)
    {
        char[] meuChar = new char[] { ' ', '.', '?' };
        return str.Split(meuChar, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
```

Ele pode ser utilizado no programa principal da seguinte forma:

```csharp
static void Main() {
    string texto = "anderson silvério mendrot? filho.";
    Console.WriteLine(texto.ContadorDePalavras());

    //resultado: 4
}
```

## 3. Exception

Duas formas de se trabalhar com exceções aparecem abaixo. É possível lançar uma exceção de acordo com alguma necessidade do negócio, assim como é possível utilizar um bloco try-catch, inclusive podendo ter vários blocos catch, desde os mais específicos até um mais geral denominado Exception.

```csharp
static void ProcessaString(string s)
{
    if (s == null)
    {
        throw new ArgumentNullException();
    }
}

static void Main()
{
    try
    {
        string s = null;
        ProcessaString(s);
    }
    catch (ArgumentNullException e)
    {
        Console.WriteLine("Primeira exceção");
    }
    catch (Exception e)
    {
        Console.WriteLine("Segunda Exceção");
    }
}
```

#### Coleções

Há diversos tipos de coleções em C#. Alguns exemplos estão citados a seguir, sendo que métodos importantes são:
- *Add*, que adiciona informações às coleções
- *Count*, que retorna o numero de elementos
- *Clear*, que limpa as coleções
- *Remove*, que remove pela chave (no caso do Dictionary, SortedList e SortedDictionary) e pelo valor (na List).
- *Sort*, que ordena a List
- *Dequeue*, *queue* e *peek* para as filas
- *Push*, *pop* e *peek* para pilhas

1. List e SortedList

As listas são tipos fortemente tipados utilizados para adicionar uma informação por vez, e são representadas da seguinte forma:

```csharp
List<string> dados = new List<string>() {"c"};
dados.Add("b");
dados.Add("a");
```

Pode-se usar a função Sort para ordenar as entradas de uma lista, além de ForEach para interagir com as informações dentro dela.

```csharp
Console.WriteLine(dados[0]);
dados.Sort();
foreach(var a in dados)
{
    Console.WriteLine(a);
}

Console.WriteLine("---------");

dados.ForEach(x =>
{
    Console.WriteLine(x);
});

/*saida:
c
a
b
c
---------
a
b
c*/
```

Já as SortedList são coleções que armazenam chave e valor, de forma que as entradas são ordenadas pelas chaves e acessível apenas por elas. Há por exemplo funções para pesquisar se há determinada chave ou valor.

```csharp
SortedList<string, int> sortedList = new SortedList<string, int>();

//key deve ser única
sortedList.Add("Entrada2", 2);
sortedList.Add("Entrada1", 1);

foreach (var item in sortedList)
{
    Console.WriteLine("Key: " + item.Key);
    Console.WriteLine("Value:" + item.Value);
}

Console.WriteLine(sortedList.ContainsKey("data 1"));
Console.WriteLine(sortedList.ContainsValue(1));

/*saida: 
Key: Entrada1
Value: 1
Key: Entrada2
Value: 2
True
True*/
```

2. Dictionary e SortedDictionary

Os dictionaries são estruturas de dados semelhantes às SortedList, porém não realizam ordenação por chaves.

```csharp
Dictionary<string, int> dic = new Dictionary<string, int>();
dic.Add("item 1", 1);
dic.Add("item 2", 2);
Console.WriteLine(dic["item 1"]);
Console.WriteLine(dic.ContainsKey("item 1"));
Console.WriteLine(dic.ContainsValue(1));

/*saida 
1
True
True*/
```

Já os SortedDictionary são semelhantes aos SortedList, com a diferença de que usam mais memória e são mais lentas para pesquisas que a SortedList. Porém, para inserções é preferível utilizar SortedDictionary.

```csharp
SortedDictionary<string, int> sortedDic = new SortedDictionary<string, int>();

sortedDic.Add("data 1", 1);
sortedDic.Add("data 3", 2);
sortedDic.Add("data 2", 3);

foreach (var item in sortedDic)
{
    Console.WriteLine(item);
}

Console.WriteLine(sortedDic["data 1"]);

/*saida:
1
True
True
[data 1, 1]
[data 2, 3]
[data 3, 2]
1*/
```



3. Queue e Stack

Queues (filas) e Stack (pilhas) são duas estruturas de dados que podem ser utilizadas da seguinte forma em C#. No primeiro caso o valor 1 é colocado na fila usando Enqueue, o valor é impresso usando Peek e por fim sai da fila usando Dequeue. Analogamente isto ocorre para a pilha com push e pop.

```csharp
Queue<int> fila = new Queue<int>();
fila.Enqueue(1);
Console.WriteLine(fila.Peek());
fila.Dequeue();

Stack<int> pilha = new Stack<int>();
pilha.Push(1);
Console.WriteLine(pilha.Peek());
pilha.Pop();

/*saida:
1
1
*/
```
