using Classes;

public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }

    public override void PerformMonthEndTransactions()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.5m;
            MakeDeposit(interest, DateTime.Now, "apply monthly interest");
        }
    }
}
