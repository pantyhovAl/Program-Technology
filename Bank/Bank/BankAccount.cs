using System.Text;

namespace Bank;

internal class BankAccount
{
    private List<Transaction> _allTransactions = new List<Transaction>();
    public string Owner { get; private set; }
    public string Number { get; }
    public decimal Balance 
    {
        get 
        {
            decimal balance = 0;
            foreach (var transaction in _allTransactions) 
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }
    private static int s_accountNumber = 100000000;
    public BankAccount(string name, decimal initaiBalacne)
    {
        MakeDeposite(initaiBalacne, DateTime.UtcNow, "initalBalacne");
        Owner = name;
        Number = s_accountNumber.ToString();
        s_accountNumber++;
    }
    public void MakeDeposite(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout));
        }
    }
    public void MakeWithdrawl(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout));
        }
        if (Balance < amout)
        {
            //throw new InvalidOperationException("vgvjgh");
        }
        var withdrawal = new Transaction(-amout, date, note);
        _allTransactions.Add(withdrawal);
    }
    public string GetAccountHistory()

    {
        var report = new StringBuilder();
        decimal balance = 0;
report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
        balance += item.Amount;
        report.AppendLine($"" + $"{item.Date.ToShortDateString()}\t" + $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }
}
