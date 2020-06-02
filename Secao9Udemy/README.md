### A seção 9 fala sobre composição e enumerações.

#### Composição

Tipo de associação que permite que um objeto contenha outro, podendo ser relação "tem-um" ou "tem- vários". Pode ser representado em UML por um diamante negro.

Há diversos tipos de composição, podendo ser entre entidades ou serviços de banco de dados, por exemplo:

![diagrama2](https://github.com/andersonmendrot/estudo-csharp/blob/master/Secao9Udemy/diagrama2.jpg)

![diagrama3](https://github.com/andersonmendrot/estudo-csharp/blob/master/Secao9Udemy/diagrama3.jpg)

O diagrama abaixo mostra um exemplo prático, em que a classe Worker contém um departamento e pode conter vários contratos. O código da classe Worker se encontra abaixo.

![diagrama](https://github.com/andersonmendrot/estudo-csharp/blob/master/Secao9Udemy/diagrama.jpg)

Para criar a relação "tem-um" da classe Worker e Department, a classe Worker possui uma propriedade Department do tipo Department. Já para criar a "tem-vários", é criada uma lista de HourContract já instanciada. Como a lista de contratos no exemplo começa vazia, então não é adicionada no construtor do projeto, sendo usada posteriormente no programa principal para cada vez que se desejar adicionar um novo contrato. 

```csharp
public class Worker
{
    public string Name { get; set; }
    public WorkerLevel WorkerLevel { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
    public List<HourContract> Contracts { get; set; } = new List<HourContract>();

    public Worker() { }

    public Worker(string name, WorkerLevel workerLevel, double baseSalary, Department department)
    {
        Name = name;
        WorkerLevel = workerLevel;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddContract(HourContract contract)
    {
        Contracts.Add(contract);
    }

    public void RemoveContract(HourContract contract)
    {
        Contracts.Remove(contract);
    }
    public double Income(int year, int month)
    {
        double sum = BaseSalary;
        foreach(HourContract contract in Contracts)
        {
            if (contract.Date.Year == year && contract.Date.Month == month)
            {
                sum += contract.TotalValue();
            }
        }
        return sum;
    }
}
```

As classes HourContract e Department se encontram abaixo:

```csharp
//Department.cs
public class Department
{
    public string Name { get; set; }

    public Department() { }

    public Department(string name)
    {
        Name = name;
    }
}

//HourContract.cs
public class HourContract
{
    public DateTime Date { get; set; }
    public double ValuePerHour { get; set; }
    public int Hours { get; set; }

    public HourContract() { }

    public HourContract(DateTime date, double valuePerHour, int hours)
    {
        Date = date;
        ValuePerHour = valuePerHour;
        Hours = hours;
    }

    public double TotalValue()
    {
        return ValuePerHour * Hours;
    }
}
```

Por fim, é criado também um enum, que é um tipo especial usado para especificar de forma literal um conjunto
de constantes relacionadas.

```csharp
public enum WorkerLevel : int
{
    Junior = 0,
    MidLevel = 1,
    Senior = 2
}
```
