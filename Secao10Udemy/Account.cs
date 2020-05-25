namespace Secao10Udemy
{
    class Account
    {
        //protected: Balance somente pode ser alterado pela propria classe ou por alguma subclasse (dentro ou fora do assembly). A classe Program.cs não possui esse privilégio
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; protected set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }
}
