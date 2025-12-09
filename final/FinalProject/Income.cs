class Income: Transaction
{
    private decimal _taxRate;

    public Income(DateTime date, decimal amount, string description, Category category, Account account, decimal taxRate)
        : base(date, amount, description, category, account)
    {
        _taxRate = taxRate;
    }

    private decimal GetTaxAmount()
    {
        return GetAmount() * _taxRate;
    }
    public override decimal GetNetAmount()
    {
        return GetAmount() - GetTaxAmount();
    }
}