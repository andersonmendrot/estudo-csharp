namespace Secao4Udemy
{
    class Calculadora
    {
        //Membros estáticos (ou de classe): fazem sentido independentemente de objetos, não precisando de nomes para serem chamados
        //ex Classes utilitárias, como Math.Sqrt(double) e declaracao de constantes, como Pi
        //Uma classe que possui apenas membros estáticos pode ser estática também. No caso, ela não poderá ser instanciada

        public static double Pi = 3.14;

        public static double Circunferencia(double r)
        {
            return 2.0 * Pi * r;
        }

        public static double Volume(double r)
        {
            return Pi * r * r * r;
        }
    }
}
