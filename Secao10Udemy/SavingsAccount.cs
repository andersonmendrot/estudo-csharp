using System;
using System.Collections.Generic;
using System.Text;

namespace Secao10Udemy
{
    class SavingsAccount : Account
    {
        public double InterestRate { get; set; }
    
        public SavingsAccount()
        {
        }

        public SavingsAccount(int number, string holder, double balance, double interestRate) : base(number, holder, balance)
        {
            InterestRate = interestRate;
        }

        public void UpdateBalance()
        {
            Balance += Balance * InterestRate;
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount - 2.0;
        }
    }
}
