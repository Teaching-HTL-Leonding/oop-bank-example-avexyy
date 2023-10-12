using Bank.Logic;

Account account;

Console.Write("Type of account ([c]hecking, [b]usiness, [s]avings): ");

switch (Console.ReadLine()!)
{
    case "c": account = new CheckingAccount(); break;
    case "b": account = new BusinessAccount(); break;
    case "s": account = new Money(); break;
    default: Console.WriteLine("Invalid input"); return;
}

Console.Write("Account number: ");
account.AccountNumber = Console.ReadLine()!;

Console.Write("Account holder: ");
account.AccountHolder = Console.ReadLine()!;

Console.Write("Current balance: ");
account.CurrentBalance = decimal.Parse(Console.ReadLine()!);

var transaction = new Transaction();

Console.Write("Transaction acount number: ");
transaction.AccountNumber = Console.ReadLine()!;

Console.Write("Transaction description: ");
transaction.Description = Console.ReadLine()!;

Console.Write("Transaction amount: ");
transaction.Amount = decimal.Parse(Console.ReadLine()!);

Console.Write("Transaction timestamp: ");
transaction.Timestamp = DateTime.Parse(Console.ReadLine()!);

if (account.TryExecute(transaction))
{
    Console.WriteLine($"Transaction executed successfully. The new current balance is {account.CurrentBalance}.");
}
else
{
    Console.WriteLine("Transaction not allowed.");
}