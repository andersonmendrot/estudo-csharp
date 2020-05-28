### A se��o 6 do curso introduz interfaces

Interfaces s�o usadas para estabelecer um contrato entre uma classe, de forma que ela caso deseje utilizar a interface deve implementar as fun��es cujas declara��es est�o contidas na interface. � utilizada para desacoplamento de c�digo, como no exemplo abaixo. Nele, h� uma interface para taxas de servi�os de alugueis de carro.

```csharp
interface ITaxService
{
    double Tax(double amount);
}
```

