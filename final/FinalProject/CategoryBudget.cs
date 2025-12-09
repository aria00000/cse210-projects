class CategoryBudget
{
    private Category _category;
    private decimal _monthlyLimit;

    public CategoryBudget(Category category, decimal monthlyLimit)
    {
        _category = category;
        _monthlyLimit = monthlyLimit;
    }

    public Category GetCategory()
    {
        return _category;
    }

    public decimal GetMonthlyLimit()
    {
        return _monthlyLimit;
    }

    public decimal CalculateRemainingAmount(decimal usedAmountThisMonth)
    {
        return _monthlyLimit - usedAmountThisMonth;
    }

    public bool IsOverBudget(decimal usedAmountThisMonth)
    {
        return usedAmountThisMonth > _monthlyLimit;
    }
}