### A seção 6 do curso introduz interfaces

Interfaces são usadas para estabelecer um contrato entre uma classe, de forma que ela caso deseje utilizar a interface deve implementar as funções cujas declarações estão contidas na interface. Em C#, não se pode utilizar modificadores de acesso nos membros da interface pois são por padrão todos publicos. É utilizada para desacoplamento de código, como no exemplo abaixo. Nele, há um diagrama de classes que representa um possível uso de interfaces.

![diagrama](https://github.com/andersonmendrot/estudo-csharp/blob/master/Secao11Udemy/diagram.png)

Nele, há uma interface para taxas de serviços de alugueis de carro

```csharp
interface ITaxService
{
    double Tax(double amount);
}
```

Que é implementado por uma classe BrazilTaxService de forma a tornar específica a taxa para o uso no Brasil.

```csharp
class BrazilTaxService : ITaxService
{
    public double Tax(double amount)
    {
        return amount * 0.15;
    }
}
```

Após essa implementação, a interface pode ser utilizada na classe RentalService, a qual é responsável por estabelecer um aluguel de carro. Ela é declarada de forma privativa, e sua maior vantagem está no fato de que ela fica preparada para receber qualquer implementação da interface TaxService. Assim, há um acoplamento fraco, a classe RentalService não conhece qual é a classe concreta que vai utilizar, e se a classe concreta mudar, RentalService não terá sua implementação também alterada.

```csharp
class RentalService
{
    public double PricePerDay { get; private set; }
    private ITaxService _taxService;

    public RentalService(double pricePerDay, ITaxService taxService)
    {
        PricePerDay = pricePerDay;
        _taxService = taxService;
    }
    
    public void ProcessInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
        double basicPayment = 0.0;
        basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        
        //aqui é utilizada o método concreto da interface
        double tax = _taxService.Tax(basicPayment);

        carRental.Invoice = new Invoice(basicPayment, tax);
    }
}
```

Além disso, outro conceitos associados são o de *injeção de dependência* e *inversão de controle*:
- *Inversão de controle* consiste em retirar da classe a responsabilidade de instanciar suas dependência
- *Injeção de dependência* é uma das formas de inversão de controle, quando um componente externo "injeta" uma dependência no objeto pai. O exemplo seguinte mostra uma injeção de dependência em um construtor, no caso, do programa principal no construtor do RentalService no lugar de ITaxService.

```csharp
static void Main {
    ...
    RentalService rentalService = new RentalService(..., new BrazilTaxService());
    ...
}
```

Uma interface também pode definir propriedades, as quais devem ser implementadas em uma classe que herda tal interface. 

```csharp
interface ICalculoValor
{
    decimal ValorBruto { get; set; }
}

class Calculo : ICalculoValor
{
    public decimal ValorBruto { get; set; }
}
```