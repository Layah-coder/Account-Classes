//access all files in classes project
using Classes;

//create a bank account giving a name and balance
var account = new BankAccount("Smith, K.", 1000);
Console.WriteLine($"{ account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

//withdraw using bankaccount class method
account.MakeWithdrawl(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);

//make withdrawl using bankaccount class method
account.MakeWithdrawl(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);

/*//show example of creating an account with a negative balance
BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}

//show example of overdrafting an account with the MakeWithdrawl method
try
{
    account.MakeWithdrawl(750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}*/
//use bankaccount method to display all account transactions
Console.WriteLine(account.GetAccountHistory());

var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawl(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawl(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();

//can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "Add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawl(250, DateTime.Now, "needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());

/*var lineOfcredit = new LineOfCredit("line of credit", 0);
//how much is too much to borrow?
lineOfcredit.MakeWithdrawl(1000m, DateTime.Now, "take out monthly advance");
lineOfcredit.MakeDeposit(50m, DateTime.Now, "pay back small amount");
lineOfcredit.MakeWithdrawl(5000m, DateTime.Now, "emergency funds for repair");
lineOfcredit.MakeDeposit(150m, DateTime.Now, "partial restoration on repairs");
lineOfcredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfcredit.GetAccountHistory());
*/

var lineOfCredit = new LineOfCredit("Line of credit", 0, 2000);
//How much is too much to borrow
lineOfCredit.MakeWithdrawl(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawl(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());