using System;

class Program
{
    static void Main(string[] args)
    {
        BudgetManager manager = new BudgetManager();

        Category food = new Category("Food", true, 0.0m, 0.0m);
        manager.AddCategory(food);
        Category salary = new Category("Salary", true, 0.1m, 0.0m);
        manager.AddCategory(salary);
        Category entertainment = new Category("Entertainment", false, 0.00m, 0.05m); 
        manager.AddCategory(entertainment);

        CategoryBudget foodBudget = new CategoryBudget(food, 30000m);
        manager.AddCategoryBudget(foodBudget);           
        CategoryBudget entertainmentBudget = new CategoryBudget(entertainment, 10000m); 
        manager.AddCategoryBudget(entertainmentBudget);

        Account wallet = new Account("Wallet", Account.AccountType.Checking);
        manager.AddAccount(wallet);
        Account bank = new Account("Bank", Account.AccountType.Savings);
        manager.AddAccount(bank);

        DateTime today = DateTime.Today;
        int year = today.Year;
        int month = today.Month;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1) Add Income");
            Console.WriteLine("2) Add Expense");
            Console.WriteLine("3) Show Monthly Report");
            Console.WriteLine("4) Show Category Report");
            Console.WriteLine("5) Show Account Report");
            Console.WriteLine("6) List Categories and Accounts");
            Console.WriteLine("7) Quit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            try
            {
                if (choice == "1")
                {
                    DateTime date = ReadDate(year, month);
                    decimal amount = ReadDecimal("Amount: ");
                    Console.Write("Description: ");
                    string desc = Console.ReadLine() ?? "";
                    string category = ChooseFromList(manager.GetCategories(), c => c.GetName(), "Choose category: ");
                    string account = ChooseFromList(manager.GetAccounts(), a => a.GetName(), "Choose account: ");
                    manager.AddIncome(date, amount, desc, category, account);
                    Console.WriteLine("Income added.");
                }
                else if (choice == "2")
                {
                    DateTime date = ReadDate(year, month);
                    decimal amount = ReadDecimal("Amount: ");
                    Console.Write("Description: ");
                    string desc = Console.ReadLine() ?? "";
                    string category = ChooseFromList(manager.GetCategories(), c => c.GetName(), "Choose category: ");
                    string account = ChooseFromList(manager.GetAccounts(), a => a.GetName(), "Choose account: ");
                    manager.AddExpense(date, amount, desc, category, account);
                    Console.WriteLine("Expense added.");
                }
                else if (choice == "3")
                {
                    Console.WriteLine();
                    Console.WriteLine(manager.GetMonthlyReportString(year, month));
                }
                else if (choice == "4")
                {
                    Console.WriteLine();
                    Console.WriteLine(manager.GetCategoryReportString(year, month));
                }
                else if (choice == "5")
                {
                    Console.WriteLine();
                    Console.WriteLine(manager.GetAccountReportString(year, month));
                }
                else if (choice == "6")
                {
                    Console.WriteLine();
                    Console.WriteLine("Categories:");
                    foreach (var c in manager.GetCategories()) Console.WriteLine(" - " + c.GetName());
                    Console.WriteLine("Accounts:");
                    foreach (var a in manager.GetAccounts()) Console.WriteLine(" - " + a.GetName());
                }
                else if (choice == "7")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown choice.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


    }

    static DateTime ReadDate(int year, int month)
    {
        Console.Write("Date (YYYY-MM-DD or day number): ");
        var s = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(s)) return new DateTime(year, month, 1);
        if (s.Contains("-"))
        {
            if (DateTime.TryParse(s, out var d)) return d;
        }
        else if (int.TryParse(s, out var day))
        {
            try { return new DateTime(year, month, day); } catch { }
        }
        Console.WriteLine("Invalid date, using first of month.");
        return new DateTime(year, month, 1);
    }

    static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (decimal.TryParse(s, out var d)) return d;
            Console.WriteLine("Invalid number, try again.");
        }
    }

    static string ChooseFromList<T>(List<T> list, Func<T, string> nameSel, string prompt)
    {
        if (list.Count == 0) throw new InvalidOperationException("No items available.");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {nameSel(list[i])}");
        }
        Console.Write(prompt);
        var s = Console.ReadLine() ?? "";
        if (int.TryParse(s, out var idx) && idx >= 1 && idx <= list.Count)
        {
            return nameSel(list[idx - 1]);
        }

        return s;
    }
}