using System;
using System.Collections.Generic;

namespace BankingApp
{
    public class BankingApp
    {
        private List<User> Users = new List<User>();
        private User loggedInUser = null;

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                if (loggedInUser == null)
                    ShowLoginOrRegisterMenu();
                else
                    ShowUserMenu();
            }
        }

        private void ShowLoginOrRegisterMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            var choice = Console.ReadLine();

            if (choice == "1") RegisterUser();
            else if (choice == "2") LoginUser();
        }

        private void RegisterUser()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            var user = new User(username, password);
            Users.Add(user);
            Console.WriteLine("Registration successful!");
        }

        private void LoginUser()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            loggedInUser = Users.Find(u => u.Username == username && u.VerifyPassword(password));

            if (loggedInUser != null)
                Console.WriteLine("Login successful!");
            else
                Console.WriteLine("Invalid credentials.");
        }

        private void ShowUserMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Open New Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Logout");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": OpenAccount(); break;
                case "2": Deposit(); break;
                case "3": Withdraw(); break;
                case "4": CheckBalance(); break;
                case "5": loggedInUser = null; break;
            }
        }

        public void OpenAccount()
        {
            Console.Write("Enter account type (Savings/Checking): ");
            string accountTypeInput = Console.ReadLine();
            AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), accountTypeInput, true);

            Console.Write("Enter initial deposit amount: ");
            decimal initialDeposit = decimal.Parse(Console.ReadLine());

            var account = new BankAccount(loggedInUser.Username, accountType, initialDeposit);
            loggedInUser.Accounts.Add(account);
            Console.WriteLine("Account created successfully!");
        }

        public void Deposit()
        {
            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            var account = loggedInUser.Accounts.Find(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Withdraw()
        {
            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter amount to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            var account = loggedInUser.Accounts.Find(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                if (account.Withdraw(amount))
                    Console.WriteLine("Withdrawal successful.");
                else
                    Console.WriteLine("Insufficient balance.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void CheckBalance()
        {
            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            var account = loggedInUser.Accounts.Find(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                Console.WriteLine($"Current balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

    }
}
