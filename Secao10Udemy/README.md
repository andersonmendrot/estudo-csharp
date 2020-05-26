### A seção 5 do curso introduz herança e polimorfismo

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

Um atributo pode somente ser alterado pela própria classe ou por alguma subclasse dentro ou fora do *assembly*. A classe Program.cs, por exemplo, não possui privilégios para setar valores ao atributo *number*.

##### Sobreposição ou sobrescrita (uso de virtual/override)

Implementação de método de superclasse na subclasse.

- Virtual: deve ser incluso em métodos comuns (ou seja, não abstratos) caso haja a necessidade de que sejam sobrepostos
- Override: deve ser incluso ao sobrescrever um método

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
//
```



