### Linq e Lambda

#### Delegate 

Delegate é um tipo denominado tipo referência, que especifica uma referência para uma função. Há três tipos mais específicos para delegates:
1. Predicate
2. Action
3. Func

Seja o exemplo abaixo de uso de delegate para a classe estática CalculationService.

```csharp

public static class CalculationService
{
    public static double Max(double x, double y)
    {
        return (x > y) ? x : y;
    }

    public static double Sum(double x, double y)
    {
        return x + y;
    }

    public static void ShowMax(double x, double y)
    {
        double max = (x > y) ? x : y;
        Console.WriteLine(max);
    }

    public static void ShowSum(double x, double y)
    {
        double sum = x + y;
        Console.WriteLine(sum);
    }
}

class Program {
    delegate void MulticastDelegate(double n1, double n2);

    static void Main(){
        double a = 10;
        double b = 12;

        //sintaxe para atribuir uma função ao delegate
        Delegate d1 = CalculationService.Sum;
        Delegate d2 = CalculationService.Max;

        //sintaxe alternativa para atribuir uma função ao delegate
        Delegate del3 = new Delegate(CalculationService.Max);

        //sintaxe para chamar del1
        double result1 = del1(a, b);

        //sintaxe alternativa para chamar del2
        double result2 = del2.Invoke(a, b);

        //result1: 22
        //result2: 12
    }
}
```

Multicast delegates, por sua vez, são similares, mas utilizados para "adição" de delegates, sendo mais utilizados para execução de vários métodos void.

```csharp
class Program {
    delegate double Delegate(double n1, double n2);

    static void Main(){
        double a = 10;
        double b = 12;  

        //multi recebe primeiro ShowSum e depois ShowMax
        MulticastDelegate multi = CalculationService.ShowSum;
        multi += CalculationService.ShowMax;

        Console.WriteLine("Resultado de multicast delegate: ");

        //sintaxe para chamar multi
        multi(a, b);

        //sintaxe alternativa para chamar multi
        multi.Invoke(a, b);

        //saida: 
        //22
        //12
    }
}
```

#### Predicate

Já no caso de Predicate, ele representa um método que recebe um objeto do tipo T e retorna um valor booleano.

```csharp
public delegate bool Predicate <in T> (T obj);
```

Seja um exemplo de uso com o método RemoveAll do List:

```csharp
static void Main()
{
    List<Product> list = new List<Product>();
    list.Add(new Product("TV", 100.0));
    list.Add(new Product("Mouse", 200.0));
    list.Add(new Product("Table", 300.0));
    list.Add(new Product("HD Case", 400.0));

    //usando método ProductTest
    list.RemoveAll(ProductTest);

    //usando Predicate com função
    Predicate<Product> predicate = ProductTest;

    //usando Predicate com função lambda
    Predicate<Product> predicate1 = p => p.Price >= 100.0;

    //usando função lambda inline
    list.RemoveAll(p => p.Price >= 100.0);
}

public static bool ProductTest(Product p)
{
    return p.Price >= 100;
}
```

#### Action

Action representa método void que recebe zero ou mais argumentos

```csharp
public delegate void Action();
public delegate void Action <in T>(T obj);
public delegate void Action <in T1, in T2> (T1 arg1, T2 arg2);
//16 sobrecargas
```

Seja um exemplo de uso com ForEach de List usando a mesma lista utilizada no exemplo anterior:

```csharp
static void Main()
{
    //exemplo 1 com método 
    list.ForEach(UpdatePrice);

    //exemplo 2 com Action
    Action<Product> action = UpdatePrice;
    list.ForEach(action);

    //exemplo 3 com Action e lambda
    Action<Product> action1 = p => p.Price += p.Price * 1.1;
    list.ForEach(action1);

    //exemplo 4 com lambda inline
    list.ForEach(p => { p.Price = p.Price * 1.1; });
}

public static void UpdatePrice(Product p)
{
    p.Price = p.Price * 1.1;
}
```

#### Func

Representa método que recebe zero ou mais argumentos e retorna um valor.

```csharp
public delegate TResult Func <out TResult> ();
public delegate TResult Func <in T1, out TResult> (T obj);
public delegate TResult Func <in T1, in T2, out TResult> (T1 arg1, T2 arg2);
//16 sobrecargas
```

Seja um exemplo com o uso da função ToUpper e Select do Linq.

```csharp
static void Main()
{
    //exemplo 1 com função
    List<string> result = list.Select(NameUpper).ToList();

    //exemplo 2 com Func
    Func<Product, string> func = NameUpper;
    List<string> result3 = list.Select(func).ToList();

    //exemplo 3 com lambda
    Func<Product, string> func2 = p => p.Name.ToUpper();
    List<string> result4 = list.Select(func2).ToList();

    //exemplo 4 com lambda inline
    List<string> result5 = list.Select(p => p.Name.ToUpper()).ToList();
}

public static string NameUpper(Product p)
{
    return p.Name.ToUpper();
}
```


### LINQ

Para o exemplo, vamos utilizar duas tabelas com dados. Os resultados em geral são em IEnumerable, porém podem vir como um produto único ou IGrouping. Há duas sintaxes possíveis para cada busca, sendo a segunda "semelhante" a SQL.

A primeira delas Category.

| ID  | Name | Tier| 
| :---: |:---: |:---: 
|  1 | Tools | 2 |
|  2 | Computers | 1 |
|  3 | Electronics | 1 |

A segunda denominada Products.

| ID  | Name | Price| Category| 
| :---: |:---: |:---: |:---: 
|  1 | Computer | 1100.0 | 2 |
|  2 | Hammer | 90.0 | 1 |
|  3 | TV | 1700.0 | 3 |
|  4 | Notebook | 1300.0 | 1|
|  5 | Saw | 80.0 | 2 |
|  6 | Tablet | 700.0 | 3|
|  7 | Camera | 700.0 | 3|
|  8 | Printer | 350.0 | 3|
|  9 | MacBook | 1800.0 | 2|
|  10 | Sound Bar | 700.0 | 3|
|  11 | Level | 70.0 | 1|

#### 1. Seleção de produtos cujo tier da categoria = 1 e preço = 900 (where), com projeção (select) em Name

```csharp
var r1 = products
    .Where(p => p.Category.Tier == 1 && p.Price < 900);

var r1 =
    from p in products
    where p.Category.Tier == 1 && p.Price < 900
    select p;
/*
6, Tablet, 700.00, Computers, 1
7, Camera, 700.00, Electronics, 1
8, Printer, 350.00, Electronics, 1
10, Sound Bar, 700.00, Electronics, 1
*/
```

#### 2. Seleção de nomes de produtos com "Tools"

```csharp
var r2 = products
    .Where(p => p.Category.Name == "Tools")
    .Select(p => p.Name);

var r2 =
    from p in products
    where p.Category.Name == "Tools"
    select p.Name;

/*
Hammer
Saw
Level
*/
```

#### 3. Seleção de produtos cujo nome se inicia com 'C' (where), com projeção (select) em um objeto anônimo

```csharp
 var r3 = products
    .Where(p => p.Name[0] == 'C')
    .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name});

var r3 =
    from p in products
    where p.Name[0] == 'C'
    select new {
        p.Name,
        p.Price,
        CategoryName = p.Category.Name
    };

/*
{ Name = Computer, Price = 1100, CategoryName = Computers }
{ Name = Camera, Price = 700, CategoryName = Electronics }
*/
```

#### 4. Ordenação do resultado de 3 por preço e então por nome

```csharp
var r4 = products
    .Where(p => p.Category.Tier == 1)
    .OrderBy(p => p.Price)
    .ThenBy(p => p.Name);

var r4 =
    from p in products
    where p.Category.Tier == 1
    orderby p.Name
    orderby p.Price
    select p;

/*
8, Printer, 350.00, Electronics, 1
7, Camera, 700.00, Electronics, 1
10, Sound Bar, 700.00, Electronics, 1
6, Tablet, 700.00, Computers, 1
1, Computer, 1100.00, Computers, 1
4, Notebook, 1300.00, Computers, 1
3, TV, 1700.00, Electronics, 1
9, MacBook, 1800.00, Computers, 1
*/
```

#### 5. Seleção de quatro elementos do resultado  de 4 após ignorar os dois primeiros

```csharp
var r5 = r4.Skip(2).Take(4);

var r5 =
    (from p in r4
        select p)
    .Skip(2).Take(4);

/*
10, Sound Bar, 700.00, Electronics, 1
6, Tablet, 700.00, Computers, 1
1, Computer, 1100.00, Computers, 1
4, Notebook, 1300.00, Computers, 1
*/
```

#### 6. Seleção do primeiro resultado de 5 (ou default)

```csharp
var r6 = products.FirstOrDefault();

var r6 = (from p in products 
          select p)
        .FirstOrDefault();

/*
1, Computer, 1100.00, Computers, 1
*/

```

#### 7. Análogo ao 6, porém retorna nulo

```csharp
var r7 = products
    .Where(p => p.Price > 3000.0)
    .FirstOrDefault();

var r7 = (from p in products
        where p.Price > 3000.0
        select p)
        .FirstOrDefault();

// null
```

#### 8. Retorno de resultado como um único elemento ao invés de IEnumerable da seleção de produtos com ID = 3

```csharp
var r8 = products
    .Where(p => p.Id == 3)
    .SingleOrDefault();

var r8 = 
    (from p in products
    where p.Id == 3
    select p)
    .SingleOrDefault();
```

#### 9. Preço máximo (agregação)

```csharp
var r10 = products.Max(p => p.Price);

 var r10 = 
    (from p in products
    select p)
    .Max(p => p.Price);
//1800
```

#### 10. Preço mínimo (agregação)

```csharp
var r11 = products.Min(p => p.Price);

var r11 = (from p in products
            select p)
            .Min(p => p.Price);
//70
```

#### 11. Soma (agregação) de produtos com ID = 1

```csharp
var r12 = products
    .Where(p => p.Category.Id == 1)
    .Sum(p => p.Price);

var r12 = (from p in products
    where p.Category.Id == 1
    select p)
    .Sum(p => p.Price);
//240
```

#### 12. Média (agregação) de produtos com ID = 1

```csharp
var r13 = products
    .Where(p => p.Category.Id == 1)
    .Average(p => p.Price);

var r13 = (from p in products
    where p.Category.Id == 1
    select p)
    .Average(p => p.Price);
//80
```

#### 13. Média análoga a 12, porém com tratamento de erro em caso de falta de elementos

```csharp
var r14 = products
    .Where(p => p.Category.Id == 9)
    .Select(p => p.Price)
    .DefaultIfEmpty(0.0)
    .Average();

var r14 = (from p in products
    where p.Category.Id == 5
    select p.Price)
    .DefaultIfEmpty(0.0)
    .Average();
//0.0
```

#### 14. Uso de função de agregação personalizada (soma do preço de dois elementos) cujo ID = 1. 

```csharp
Func<double, double, double> func = (x, y) => x + y;

var r15 = products
    .Where(p => p.Category.Id == 1)
    .Select(p => p.Price)
    .Aggregate(0.0, func);

var r15 = (from p in products
    where p.Category.Id == 1
    select p.Price)
    .Aggregate(0.0, (x, y) => x + y);
//240
```

#### 15. Uso de groupby (retorna IGrouping)

```csharp
 var r16 = products
    .GroupBy(p => p.Category);

 var r16 = (from p in products
            group p by p.Category);


foreach(IGrouping<Category, Product> group in r16)
{
    Console.WriteLine("Category " + group.Key.Name + " : ");
    foreach(Product p in group)
    {
        Console.WriteLine(p);
    }
    Console.WriteLine();
}

/*
Category Computers :
1, Computer, 1100.00, Computers, 1
4, Notebook, 1300.00, Computers, 1
6, Tablet, 700.00, Computers, 1
9, MacBook, 1800.00, Computers, 1

Category Tools :
2, Hammer, 90.00, Tools, 2
5, Saw, 80.00, Tools, 2
11, Level, 70.00, Tools, 2

Category Electronics :
3, TV, 1700.00, Electronics, 1
7, Camera, 700.00, Electronics, 1
8, Printer, 350.00, Electronics, 1
10, Sound Bar, 700.00, Electronics, 1
*/
```




