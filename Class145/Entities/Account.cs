using System.Globalization;
using Class145.Entities.Exceptions;

namespace Class145.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("A tentativa de saque ultrapassou o limite de saque.");
            }

            if (amount > Balance)
            {
                throw new DomainException("A tentativa de saque ultrapassou o seu saldo atual.");
            }

            Balance -= amount;
        }

        public override string ToString()
        {
            return "New balance: "
                + Balance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
