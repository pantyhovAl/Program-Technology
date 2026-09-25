namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1=new BankAccount("Aleksei", 10000000000);
            BankAccount account2 = new BankAccount("Lena", 100);
            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}");
            Console.WriteLine($"{account2.Owner} {account2.Balance} {account2.Number}");

            account1.MakeDeposite(100000000000, DateTime.UtcNow, "");
            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}");
            account1.MakeWithdrawl(100, DateTime.UtcNow, "");
            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}");

            try
            {
                account2.MakeWithdrawl(1000000000000, DateTime.UtcNow, ""); 

            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
