### A seção 10 do curso introduz herança e polimorfismo

##### Herança ou extensão

Quando uma classe filha herda dados e comportamentos de outra

São utilizados dois símbolos principais: 

1. ':' para extensão da classe
2. 'base' para extensão do construtor da superclasse

```csharp

//superclasse
public class Conta
{
    public int Number { get; protected set; }

    public Account(int number)
    {
        Number = number;
    }
}

//subclasse
public BusinessAccount: Account
{
    public double LoanLimit { get; set; }
    
    public BusinessAccount(int number, double loanLimit) : base(number)
    {
        LoanLimit = loanLimit;
    }
}

```

##### Upcasting / downcasting

```csharp
Account acc = new Account(1);

//upcasting
Account acc1 = new BusinessAccount(2, 200.0);

//downcasting
BusinessAccount acc2 = (BusinessAccount) acc1;

//teste 'is'
acc2 is BusinessAccount;

//sintaxe alternativa para downcasting
BusinessAccount acc3 = acc1 as BusinessAccount;
```

##### Modificador de acesso *protected*

Um atributo pode somente ser alterado pela própria classe ou por alguma subclasse dentro ou fora do *assembly*. A classe Program.cs, por exemplo, não possui privilégios para setar valores ao atributo *number* de Account, porém SavingsAccount e BusinessAccount possuem.

```csharp

//superclasse
public class Account
{
    public int Number { get; protected set; }
}
```
##### Sobreposição ou sobrescrita (uso de virtual/override)

Implementação de método de superclasse na subclasse.

- Virtual: deve ser incluso em métodos comuns (ou seja, não abstratos) caso haja a necessidade de que sejam sobrepostos
- Override: deve ser incluso ao sobrescrever um método (é utilizado tanto para a parte de virtual como também para a sobrescrita de métodos *abstratos*)

ex. Caso queiramos criar uma nova regra para saque (withdraw) na subclasse SavingsAccount (counta poupança), poderemos fazer da seguinte forma:

Também há a possibilidade do uso da palavra base, ou seja, nós antes de realizarmos nossa implementação utilizamos a implementação já existente no método base.

A palavra base já foi utilizada anteriormente quando reaproveitamos o construtor vindo de outra classe, no caso, SavingsAccount e BusinessAccount utilizaram um construtor de Account como base para implementar outro.

```csharp
//na classe Account.cs
public virtual void Withdraw(double amount)
{
    Balance -= amount - 5.0;
}

//na classe SavingsAccount.cs
public override void Withdraw(double amount)
{
    Balance -= amount;
}

//na classe SavingsAccount.cs, outra opção é usar base
public override void Withdraw(double amount)
{
    base.Withdraw(amount);
    Balance -= 2.0
}
```

##### Classes e métodos sealed

- As classes sealed impedem a derivação
- Não podem ser usadas como uma classe base (ou seja, não podem ser uma classe abstrata) 

- Classe: evita que a classe seja herdada

```csharp
sealed class SavingsAccount {
    ...
}
```

- Método: evita que método sobreposto (ou seja, com *override*) possa ser sobreposto novamente

```csharp
//na classe SavingsAccount.cs

public sealed override void Withdraw {
    ...
}
```

##### Polimorfirmo

Permite que variáveis de mesmo tipo mais genéricos apontem para outras de tipos específicos diferentes, de forma que tenham comportamentos diferentes de acordo com o tipo específico.

```csharp
//na classe Program.cs
Account acc1 = new Account(1001,"Alex", 500.00);
Account acc2 = new SavingsAccount(1002, "Anna", 500.0, 0.01);

//na classe Account.cs
public virtual void Withdraw(double amount){
    Balance -= amount + 5.0;
}

//na classe SavingsAccount.cs
public override void Withdraw(double amount){
    base.Withdraw(amount);
    Balance -= 2.0;
}
```

Se for chamado *acc1.Withdraw(10.0)*, o valor de Balance será 500-5 = 490. Ou seja, *acc1* é um *Account*.

Se for chamado *acc2.Withdraw(10.0)*, o valor de Balance será 500-5-2 = 488. Ou seja, *acc2* é um *SavingsAccount*. Além disso, acc2 também é um Account.

Dessa forma, as variáveis acc1 e acc2, que se encontram na stack, apontam para duas instanciações diferentes de *Account* e *SavingsAccount* na heap.

A associação do tipo específico com o tipo genérico é feita em tempo de execução (upcasting). O compilador não sabe para qual tipo específico a chamada do método Withdraw está sendo feita, apenas que são duas variáveis do tipo *Account*.


##### Classe abstrata

- Permite que você crie classes e membros de classe que estão incompletos e devem ser implementados em uma classe derivada.
- *PODE* conter ou *NÃO* métodos abstratos (métodos sem corpo)
- Pode conter também implementações completas, como métodos, atributos e construtores.
- Tipo especial de classe que não há como criar instâncias dela.
- Usada apenas para ser herdada, funciona como uma superclasse.
- Uma grande vantagem é que força a hierarquia para todas as subclasses.
- Diferença para interface é que a única função desta é permitir a declaração de cabeçalhos de métodos.
- É obrigatório que suas classes derivadas implementem os métodos abstratos.

```csharp
public abstract Account{
    
    public int Number { get; set; }

    public Account()
    {
    }

    public int Method1(int value){
        return value;
    }
    
    public virtual double Method2()
    {
        return 1.0;
    }

    public abstract double AbstractMethod();
}

public SavingsAccount : Account{
    public override double AbstractMethod(){
        return 2.0;
    }
    
    public override double Method2(){
        return 2.0;
    }
}
```

Segundo exemplo de classe abstrata

A classe abstrata Shape é herdada pelas classes Rectangle e Color. Testes são feitos na classe Program.cs. É utilizado um enum para armazenar as cores.


```csharp
//Shape.cs
public abstract class Shape
{
    public Color Color {get; set;}

    public Shape(Color color)
    {
        Color = color;
    }

    public abstract double Area(); 

    public virtual double Teste()
    {
        return 1.0;
    }
}

//Circle.cs
public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double radius, Color color): base(color)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return 3.14*Radius*Radius;
    }
}

//Rectangle.cs
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height, Color color) : base(color)
    {
        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public override double Teste()
    {
        return base.Teste();
    }
}

//Color.cs
public enum Color
{
    BLACK, BLUE, RED
}

//Program.cs
class Program
{
    static void Main(string[] args)
    {
        Shape rectangle = new Rectangle(2.0, 3.0, Color.BLACK);
        Shape circle = new Circle(2.0, Color.BLUE);
        Rectangle rectangle1 = new Rectangle(1.0, 2.0, Color.RED);

        List<Shape> shapes = new List<Shape>() { rectangle, circle, rectangle1 };

        foreach(Shape shape in shapes)
        {
            Console.WriteLine(shape.Area());
        }
        
        //saida: 6 12.56 2 
    }
}
```
