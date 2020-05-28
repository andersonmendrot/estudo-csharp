### A seção 6 do curso introduz interfaces

Interfaces são usadas para estabelecer um contrato entre uma classe, de forma que ela caso deseje utilizar a interface deve implementar as funções cujas declarações estão contidas na interface. É utilizada para desacoplamento de código, como no exemplo abaixo. Nele, há uma interface para taxas de serviços de alugueis de carro.

```csharp
interface ITaxService
{
    double Tax(double amount);
}
```

