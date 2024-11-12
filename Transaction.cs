using System;

namespace BankingApp
{
    public class Transaction
    {
        public int TransactionID { get; private set; }
        public DateTime Date { get; private set; }
        public string Type { get; private set; }
        public decimal Amount { get; private set; }

        public Transaction(int transactionID, string type, decimal amount)
        {
            TransactionID = transactionID;
            Date = DateTime.Now;
            Type = type;
            Amount = amount;
        }
    }
}
