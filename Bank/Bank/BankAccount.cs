using System.Text;

namespace bank;
// потомок класса object
public class BankAccount
{
    private readonly decimal _minBalance;
    private List<Transaction> _allTransaction = new List<Transaction>();
    public string Owner { get; private set; }
    public string Number { get; }
    public decimal Balance
    {
        get
        {
            decimal balace = 0;
            foreach (var transaction in _allTransaction)
            {
                balace += transaction.Amount;
            }
            return balace;
        }
    }
    private static int s_accountNumberSeed = 10000000;

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {

    }
    public BankAccount(string name, decimal initialBalance, decimal minBalance)
    {
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        _minBalance = minBalance;
        if (initialBalance > 0)
        {
            MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance"); //this .Balance = initialBalance;
        }
    }

    public void MakeDeposite(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        }
        var deposite = new Transaction(amount, date, note);
        _allTransaction.Add(deposite);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        Transaction? overdrattTransaction = CheckWhithdrawlLimit(Balance - amount < _minBalance);
        Transaction? withdrawl = new(-amount, date, note);
        _allTransaction.Add(withdrawl);
        if (overdrattTransaction is not null)
            _allTransaction.Add(overdrattTransaction);

    }
    // protected модификатор доступа , котороый означает , что его можно вызвать только из текущего и дочернего классов, клиент данный метод вызватть не может
    protected virtual Transaction? CheckWhithdrawlLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient rubls for this wd");

        }
        else
        {
            return default;
        }
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        decimal balance = 0;
        report.Append("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransaction)
        {
            balance += item.Amount;
            report.AppendLine($"" + $"{item.Date.ToShortDateString()}\t" + $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }
    //virtual позволяет в дочернем классе предоставить другую реализацию в дочернем классе
    public virtual void PerformMonthAndTransactions()
    {

    }
    // преропеделяем метод базового класса object tostring возращает строку и нформацию о обекте
    public override string ToString()
    {
        return $"Owner: {Owner}\taccount number: {Number} (тип счета{GetType()}) ";
    }
}

