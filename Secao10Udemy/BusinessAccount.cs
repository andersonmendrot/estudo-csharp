using System;
using System.Collections.Generic;
using System.Text;

namespace Secao10Udemy
{
    //herança ou extensão: usa-se ' : '
    class BusinessAccount : Account
    {
        public double LoanLimit { get; set; }

        public BusinessAccount()
        {
        }

        //base: utilizado para herdar um construtor da superclasse Account
        public BusinessAccount(int number, string holder, double balance, double loanLimit) : base(number, holder, balance)
        {
            LoanLimit = loanLimit;
        }

        public void Loan(double amount)
        {
            if (amount <= LoanLimit)
            {
                Balance += amount;
            }
        }
    }
}
