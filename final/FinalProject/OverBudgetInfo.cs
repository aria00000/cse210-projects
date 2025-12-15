class OverBudgetInfo
{
    private Category _category;
    private decimal _limit;
    private decimal _used;

    public OverBudgetInfo(Category category, decimal limit, decimal used)
    {
        _category = category;
        _limit = limit;
        _used = used;
    }

    public Category GetCategory()
    {
        return _category;
    }

    public decimal GetLimit()
    {
        return _limit;
    }

    public decimal GetUsed()
    {
        return _used;
    }

    public decimal GetOver()
    {
        return _used - _limit;
    }
}

