using System;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Banking App!");
            
            var app = new BankingApp();
            app.Run();
        }
    }
}