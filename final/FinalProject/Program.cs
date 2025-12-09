using System;

class Program
{
    static void Main(string[] args)
    {
        BudgetManager manager = new BudgetManager();

        Category foodCategory = new Category("Food", true, 0.0m, 0.0m);
        manager.AddCategory(foodCategory);
        Category salary = new Category("Salary", true, 0.1m, 0.0m);
        manager.AddCategory(salary);

        Account wallet = new Account("Wallet", Account.AccountType.Checking);
        manager.AddAccount(wallet);

        manager.AddIncome(DateTime.Now, 1000m, "Test income", "Salary", "Wallet");
        manager.AddExpense(DateTime.Now, 500m, "Test expense", "Food", "Wallet");

        Console.WriteLine("Total Income: " + manager.GetTotalIncome(DateTime.Now.Year, DateTime.Now.Month));

    }
}