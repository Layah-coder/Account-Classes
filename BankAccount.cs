//include all files in the classes namespace
namespace Classes;

public class BankAccount
{
    //Account number, read only
    public string Number { get; }
    //Account holder name, read & write
    public string Owner { get; set; }

    //Account balance, read only, adds all items in the allTransaction list
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            //sum all items in transaction list including negative/withdrawls
            foreach(var item in allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    //First account number, only accessed here
    private static int s_accountNumberSeed = 1234567890;
    //
    private readonly decimal _minimumBalance;

    //Constructor

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {
    }
    
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        //increment account number to create a unique number for each time
        s_accountNumberSeed++;
        _minimumBalance = minimumBalance;
        //Calls bankaccount class method and passes in amount, time, and that this is the initial deposit
        if (initialBalance > 0)
        {
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
    }

    //private list that accepts the type : transactions, can only be accessed here
    private List<Transaction> allTransactions = new List<Transaction>();

    //Method adds deposit transactions the the list of transactions
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        //can only deposit positive amounts
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    //method adds withdrawl transactions to list of transactions
    public void MakeWithdrawl(decimal amount, DateTime date, string note)
    {
        //can only withdraw positive amounts
        if(amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive ");
        }
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
        if (overdraftTransaction != null)
        {
            allTransactions.Add(overdraftTransaction);
        }
    }

    protected virtual Transaction? CheckWithdrawalLimit(bool isOverDrawn)
    {
        if (isOverDrawn)
        {
            throw new InvalidOperationException("Not sufficent funds for this withdrawl");
        }
        else
        {
            return default;
        }
    }

    //Method that displays account history
    public string GetAccountHistory()
    {
        //Create a stringbuilder object to hold all transactions
        var report = new System.Text.StringBuilder();
        
        decimal balance = 0;
        //add a line with headings
        report.AppendLine("Date\t\tAmount\t\tBalance\t\tNotes");
        foreach(var item in allTransactions)
        {
            //create a running balance while adding each transaction to the stringbuilder object
            balance += item.Amount;
            //for every transaction in the list create a line in the stringbuilder object
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        //return string of account history
        return report.ToString();
    }

    public virtual void PerformMonthEndTransactions() { }

}