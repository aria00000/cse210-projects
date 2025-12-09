class Expense : Transaction
{
    private decimal _feeRate;

    public Expense(DateTime date, decimal amount, string description, Category category, Account account, decimal feeRate)
        : base(date, amount, description, category, account)
    {
        _feeRate = feeRate;
    }

    private decimal CalculateFee()
    {
        return GetAmount() * _feeRate;
    }
    public override decimal GetNetAmount()
    {
        return GetAmount() + CalculateFee();    
    }

}