using Classes;

public class LineOfCredit : BankAccount
{
    public LineOfCredit(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {
    }

    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawl(interest, DateTime.Now, "Charge monthly interest");
        }
    }

    protected override Transaction? CheckWithdrawalLimit(bool isOverDrawn)=>    
        isOverDrawn
        ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
        : default;
    
}