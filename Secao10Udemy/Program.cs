using System;

namespace Secao10Udemy
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(1001, "Alex", 0.0);

            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            //upcasting

            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Anna", 0.0, 0.01);

            //downcasting

            BusinessAccount acc4 = (BusinessAccount) acc2;
            acc4.Loan(100.0);

            //em tempo de execução o acc5 falha
            BusinessAccount acc5 = (BusinessAccount) acc3;

            //'is' realiza teste
            if(acc3 is BusinessAccount)
            {
                BusinessAccount acc6 = (BusinessAccount)acc3;
                BusinessAccount acc7 = acc3 as BusinessAccount;
            }

        }
    }
}
