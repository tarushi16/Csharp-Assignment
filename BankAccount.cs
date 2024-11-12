namespace BankingApp
{
    public enum AccountType { Savings, Checking }

    public class BankAccount
    {
        private static int AccountNumberSeed = 1000000;
        public int AccountNumber { get; private set; }
        public string AccountHolder { get; private set; }
        public AccountType Type { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountHolder, AccountType type, decimal initialDeposit)
        {
            AccountNumber = AccountNumberSeed++;
            AccountHolder = accountHolder;
            Type = type;
            Balance = initialDeposit;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > Balance) return false;
            Balance -= amount;
            return true;
        }
    }
}
