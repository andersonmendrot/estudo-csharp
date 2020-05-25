### A seção 10 do curso introduz herança e polimorfismo, com conceitos como:

- Upcasting, downcasting
- Sobreposição, virtual, override, base
- Classes e métodos selados e abstratos

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

