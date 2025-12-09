using System.Net.Http.Headers;

class BudgetManager
{
    private List<Transaction> _transactions;
    private List<Category> _categories;
    private List<Account> _accounts;
    private List<CategoryBudget> _categoryBudgets;

    public BudgetManager()
    {
        _transactions = new List<Transaction>();
        _categories = new List<Category>();
        _accounts = new List<Account>();
        _categoryBudgets = new List<CategoryBudget>();
    }


    public void AddCategory(Category category)
    {
        _categories.Add(category);
    }
    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    public void AddCategoryBudget(CategoryBudget categoryBudget)
    {
        _categoryBudgets.Add(categoryBudget);
    }

    public Category FindCategoryByName(string name)
    {
        return _categories.FirstOrDefault(c => c.GetName() == name);
    }

    public Account FindAccountByName(string name)
    {
        return _accounts.FirstOrDefault(a => a.GetName() == name);
    }

    public void AddIncome(DateTime date, decimal amount, string description, string categoryName, string accountName)
    {
        return ;
    }

    public void AddExpense(DateTime date, decimal amount, string description, string categoryName, string accountName)
    {
        return ;

    }

    public List<Transaction> GetTransactionsForMonth(int year, int month)
    {
        return null;
    }

    public List<Transaction> GetTransactionsForMonthAndCategory(int year, int month, string categoryName)
    {
        return null;
    }

    public List<Transaction> GetTransactionsForMonthAndAccount(int year, int month, string accountName)
    {
        return null;
    }

    public decimal GetTotalIncome(int year, int month, bool useNetAmount = true)
    {
        return 0;
    }

    public decimal GetTotalExpense(int year, int month, bool useNetAmount = true)
    {
        return 0;
    }

    public decimal GetNetBalance(int year, int month, bool useNetAmount = true)
    {
        return 0;
    }

    public Dictionary<Category, decimal> GetCategoryExpenseTotals(int year, int month, bool useNetAmount = true)
    {
        return null;
        
    }

    public Dictionary<Account, decimal> GetAccountBalancesUpTo(int year, int month)
    {
        return null;
        
    }

    public List<(Category category, decimal limit, decimal used, decimal over)>
        GetOverBudgetCategories(int year, int month, bool useNetAmount = true)
    {
        return null;
    }
    public MonthlyReport GenerateMonthlyReport(int year, int month, bool useNetAmount = true)
    {
        return null;
    }

    public string GetMonthlyReportString(int year, int month)
    {
        return "";
    }

    public string GetCategoryReportString(int year, int month)
    {
        return "";
    }

    public string GetAccountReportString(int year, int month)
    {
        return "";
    }
}       



 



