namespace Bank.Logic;

public abstract class Account
{
    public string AccountNumber { get; set; } = "";
    public string AccountHolder { get; set; } = "";
    public decimal CurrentBalance { get; set; }
    public abstract bool IsAllowed(Transaction transaction);

    public bool TryExecute(Transaction transaction)
    {
        if (IsAllowed(transaction))
        {
            CurrentBalance += transaction.Amount;
            return true;
        }
        return false;
    }
}
public class Money : Account
{
    public override bool IsAllowed(Transaction transaction)
    {
        return transaction.AccountNumber == AccountNumber && (CurrentBalance + transaction.Amount) is >= 0 and <= 100000000;
    } 
}
public class CheckingAccount : Account
{
    public override bool IsAllowed(Transaction transaction)
    {
        return transaction.AccountNumber == AccountNumber && (CurrentBalance + transaction.Amount) is >= -10000 and <= 10000000 && Math.Abs(transaction.Amount) <= 10000 ; 
    }
}
public class BusinessAccount : Account
{
    public override bool IsAllowed(Transaction transaction)
    {
        return transaction.AccountNumber == AccountNumber && (CurrentBalance + transaction.Amount) is >= -1000000 and <= 100000000 && Math.Abs(transaction.Amount) <= 100000 ;
    }
}
public class Transaction
{
    public string AccountNumber { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
}