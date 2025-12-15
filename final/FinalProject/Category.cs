class Category
{
    private string _name;
    private bool _isEssential;
    private decimal _defaltIncomeTaxRate;
    private decimal _defaultExpenseFeeRate;

    public Category(string name, bool isEssential, decimal defaltIncomeTaxRate, decimal defaultExpenseFeeRate)
    {
        _name = name;
        _isEssential = isEssential;
        _defaltIncomeTaxRate = defaltIncomeTaxRate;
        _defaultExpenseFeeRate = defaultExpenseFeeRate;
    }

    public string GetName()
    {
        return _name;
    } 

    public bool IsEssential()
    {
        return _isEssential;
    }
    public decimal GetDefaultIncomeTaxRate()
    {
        return _defaltIncomeTaxRate;
    }

    public decimal GetDefaultExpenseFeeRate()
    {
        return _defaultExpenseFeeRate;
    }

    public override string ToString()
    {
        return $"{_name} (Essential: {_isEssential}, Income Tax Rate: {_defaltIncomeTaxRate:P}, Expense Fee Rate: {_defaultExpenseFeeRate:P})";
    }
}