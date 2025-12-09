class Account
{
    private string _name;
    private AccountType _type;

    public Account(string name, AccountType type)
    {
        _name = name;
        _type = type;
    }

    public enum AccountType
    {
        Checking,
        Savings,
        Credit
    }

    public string GetName()
    {
        return _name;
    }

    public AccountType GetAccountType()
    {
        return _type;
    }

    public decimal GetBalance(List<Transaction> transactions)
    {
        decimal balance = 0;
        foreach (var transaction in transactions)
        {
            if (transaction.GetAccount() == this)
            {
                balance += transaction.GetNetAmount();
            }
        }
        return balance;
    }
    


    public override string ToString()
    {
        return $"{_name} ({_type})";
    }
}