using System;
using System.Collections.Generic;
using System.Linq;

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

    // Expose lists for UI to display/select
    public List<Category> GetCategories()
    {
        return _categories;
    }

    public List<Account> GetAccounts()
    {
        return _accounts;
    }

    public Category FindCategoryByName(string name)
    {
        var category = _categories.FirstOrDefault(c => c.GetName() == name);
        if (category == null)
        {
            throw new ArgumentException($"Category '{name}' was not found.");
        }
        return category;
    }

    public Account FindAccountByName(string name)
    {
        var account = _accounts.FirstOrDefault(a => a.GetName() == name);
        if (account == null)
        {
            throw new ArgumentException($"Account '{name}' was not found.");
        }
        return account;
    }

    public void AddIncome(DateTime date, decimal amount, string description, string categoryName, string accountName)
    {
        Category category = FindCategoryByName(categoryName);
        Account account = FindAccountByName(accountName);

        decimal taxRate = category.GetDefaultIncomeTaxRate();
        Transaction income = new Income(date, amount, description, category, account, taxRate);
        _transactions.Add(income);
    }

    public void AddExpense(DateTime date, decimal amount, string description, string categoryName, string accountName)
    {
        Category category = FindCategoryByName(categoryName);
        Account account = FindAccountByName(accountName);

        decimal feeRate = category.GetDefaultExpenseFeeRate();
        Transaction expense = new Expense(date, amount, description, category, account, feeRate);
        _transactions.Add(expense);

    }

    private IEnumerable<Transaction> FilterByMonth(int year, int month)
    {
        return _transactions.Where(t => t.IsInMonth(year, month));
    }

    public List<Transaction> GetTransactionsForMonth(int year, int month)
    {
        return FilterByMonth(year, month).ToList();
    }

    public List<Transaction> GetTransactionsForMonthAndCategory(int year, int month, string categoryName)
    {
        Category category = FindCategoryByName(categoryName);
        return FilterByMonth(year, month)
               .Where(t => t.MatchesCategory(category))
               .ToList();
    }

    public List<Transaction> GetTransactionsForMonthAndAccount(int year, int month, string accountName)
    {
        return FilterByMonth(year, month)
               .Where(t => t.GetAccount().GetName() == accountName)
               .ToList();
    }

    public decimal GetTotalIncome(int year, int month, bool useNetAmount = true)
    {
        var incomes = FilterByMonth(year, month)
                      .OfType<Income>();
        if (useNetAmount)
        {
            return incomes.Sum(i => i.GetNetAmount());
        }
        else
        {
            return incomes.Sum(i => i.GetAmount());
        }
    }

    public decimal GetTotalExpense(int year, int month, bool useNetAmount = true)
    {
        var expenses = FilterByMonth(year, month)
                       .OfType<Expense>();
        if (useNetAmount)
        {
            return expenses.Sum(e => e.GetNetAmount());
        }
        else
        {
            return expenses.Sum(e => e.GetAmount());
        }
    }

    public decimal GetNetBalance(int year, int month, bool useNetAmount = true)
    {
        decimal totalIncome = GetTotalIncome(year, month, useNetAmount);
        decimal totalExpense = GetTotalExpense(year, month, useNetAmount);
        return totalIncome - totalExpense;
    }

    public Dictionary<Category, decimal> GetCategoryExpenseTotals(int year, int month, bool useNetAmount = true)
    {
        var expenses = FilterByMonth(year, month)
                       .OfType<Expense>();
        var query = expenses.GroupBy(e => e.GetCategory())
                            .ToDictionary(
                                g => g.Key,
                                g => useNetAmount ? g.Sum(e => e.GetNetAmount()) : g.Sum(e => e.GetAmount())
                            );
        return query;
        
    }

    public Dictionary<Account, decimal> GetAccountBalancesUpTo(int year, int month)
    {
        var endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        var relevant = _transactions
                       .Where(t => t.GetDate() <= endDate);

        var result = new Dictionary<Account, decimal>();

        foreach (var account in _accounts)
        {
            decimal balance = 0m;

            foreach (var transaction in relevant.Where(t => t.GetAccount() == account))
            {
                if (transaction is Income)
                {
                    balance += transaction.GetNetAmount();
                }
                else if (transaction is Expense)
                {
                    balance -= transaction.GetNetAmount();
                }
            }
            result[account] = balance;

        }
        return result;
        
    }

    public List<OverBudgetInfo> GetOverBudgetCategories(int year, int month, bool useNetAmount = true)
    {
        var result = new List<OverBudgetInfo>();

        var expenseTotals = GetCategoryExpenseTotals(year, month, useNetAmount);

        foreach (var categoryBudget in _categoryBudgets)
        {
            var category = categoryBudget.GetCategory();
            decimal limit = categoryBudget.GetMonthlyLimit();
            decimal used = expenseTotals.ContainsKey(category) ? expenseTotals[category] : 0m;

            if (used > limit)
            {
                result.Add(new OverBudgetInfo(category, limit, used));
            }
        }
        return result;
    }
    public MonthlyReport GenerateMonthlyReport(int year, int month, bool useNetAmount = true)
    {
        decimal totalIncome = GetTotalIncome(year, month, useNetAmount);
        decimal totalExpense = GetTotalExpense(year, month, useNetAmount);
        decimal netBalance = totalIncome - totalExpense;

        var categoryExpenses = GetCategoryExpenseTotals(year, month, useNetAmount);
        var overBudgetCategories = GetOverBudgetCategories(year, month, useNetAmount);

        MonthlyReport report = new MonthlyReport(year, month, totalIncome, totalExpense, netBalance, categoryExpenses, overBudgetCategories);
        return report;
    }

    public string GetMonthlyReportString(int year, int month)
    {
        MonthlyReport report = GenerateMonthlyReport(year, month);
        return report.ToString();
    }

    public string GetCategoryReportString(int year, int month)
    {
        var totals = GetCategoryExpenseTotals(year, month, useNetAmount: true);

        if (totals.Count == 0)
        {
            return "No expenses recorded for this month.";
        }

        var lines = new List<string>();
        foreach (var kvp in totals)
        {
            lines.Add($"{kvp.Key.GetName()}: {kvp.Value:C}");
        }
        return string.Join(Environment.NewLine, lines);
    }

    public string GetAccountReportString(int year, int month)
    {
        var balances = GetAccountBalancesUpTo(year, month);

        if (balances.Count == 0)
        {
            return "No accounts available.";
        }

        var lines = new List<string>();
        foreach (var kvp in balances)
        {
            lines.Add($"{kvp.Key.GetName()}: {kvp.Value:C}");
        }
        return string.Join(Environment.NewLine, lines);
    }
}       



 



