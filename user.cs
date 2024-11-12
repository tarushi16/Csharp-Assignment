namespace BankingApp
{
    public class User
    {
        public string Username { get; private set; }
        private string Password { get; set; } // Store the password securely
        public List<BankAccount> Accounts { get; private set; } = new List<BankAccount>();

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool VerifyPassword(string password)
        {
            return Password == password; // Simple verification (could be encrypted)
        }
    }
}
