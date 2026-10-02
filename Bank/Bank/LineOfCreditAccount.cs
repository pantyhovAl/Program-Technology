using System.Data;

namespace bank;

public class LineOfCreditAccount : BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {

    }
    public override void PerformMonthAndTransactions()
    {
        if (Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge");
        }
    }
    protected override Transaction? CheckWhithdrawlLimit(bool isOverdrawn) => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;
    
        
    
}
