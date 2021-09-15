using System;

namespace Exercise2_Account
{
    class Account
    {
        private readonly string name;
        private readonly int accountNumber;
        private double balance;

        public Account(string name, int accountNumber, double initialAmount)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            this.balance = initialAmount;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Withdraw(double amount)
        {
            balance -= amount;
        }

        public void Dumb()
        {
            Console.WriteLine(name + ", " + accountNumber + ", balance: $" + balance);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account("Pablito Mix", 54321, 5000);
            Account a2 = new Account("Bid Binny", 54311, 10000);

            a1.Deposit(500);
            a1.Withdraw(1500);
            a1.Dumb();

            a2.Withdraw(1500);
            a2.Deposit(500);
            a2.Dumb();
        }
    }
}
