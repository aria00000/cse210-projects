using System.Linq;

class MonthlyReport
{
    private int _year;
    private int _month;
    private decimal _totalIncome;
    private decimal _totalExpense;
    private decimal _netBalance;

    private Dictionary<Category, decimal> _categoryExpenseTotals;
    private List<OverBudgetInfo> _overBudgetCategories;

    public MonthlyReport(int year, int month, decimal totalIncome, decimal totalExpense, decimal netBalance,
                         Dictionary<Category, decimal> categoryExpenseTotals,
                         List<OverBudgetInfo> overBudgetCategories)
    {
        _year = year;
        _month = month;
        _totalIncome = totalIncome;
        _totalExpense = totalExpense;
        _netBalance = netBalance;
        _categoryExpenseTotals = categoryExpenseTotals;
        _overBudgetCategories = overBudgetCategories;
    }

    public int GetYear()
    {
        return _year;
    }

    public int GetMonth()
    {
        return _month;
    }

    public decimal GetTotalIncome()
    {
        return _totalIncome;
    }

    public decimal GetTotalExpense()
    {
        return _totalExpense;
    }

    public decimal GetNetBalance()
    {
        return _netBalance;
    }

    public Dictionary<Category, decimal> GetCategoryExpenseTotals()
    {
        return _categoryExpenseTotals;
    }

    public List<OverBudgetInfo> GetOverBudgetCategories()
    {
        return _overBudgetCategories;
    }

    public override string ToString()
    {
        return $"Monthly Report for {_month}/{_year}:\n" +
               $"Total Income: {_totalIncome:C}\n" +
               $"Total Expense: {_totalExpense:C}\n" +
               $"Net Balance: {_netBalance:C}\n" +
               $"Category Expenses: {string.Join(", ", _categoryExpenseTotals.Select(kv => $"{kv.Key.GetName()}: {kv.Value:C}"))}\n" +
               $"Over Budget Categories: {string.Join(", ", _overBudgetCategories.Select(c => $"{c.GetCategory().GetName()} (Limit: {c.GetLimit():C}, Used: {c.GetUsed():C}, Over: {c.GetOver():C})"))}";
    }

}