# Final Project - Budget Tracker

> This allows users to record income and expenses, calculate totals by category and account, generate monthly reports, and detect budget overruns by category.

**Main Features**
- Add income (Income) and expenses (Expense)
- Aggregate expenses by category (Category)
- Calculate balances by account (Account)
- Detect monthly budget overruns using category budgets (CategoryBudget)
- Generate and display monthly reports (MonthlyReport)



**RUn**
Menu（`Program.cs`:
- `1) Add Income`
- `2) Add Expense`
- `3) Show Monthly Report`
- `4) Show Category Report`
- `5) Show Account Report`
- `6) List Categories and Accounts`
- `7) Quit`

**Design and Main Source Files**
- [Program.cs](final/FinalProject/Program.cs#L1) - Entry point; provides a simple console-based UI(menu)
- [BudgetManager.cs](final/FinalProject/BudgetManager.cs#L1) - Manages transactions, categories, accounts, budgets, and report generation 
- [Category.cs](final/FinalProject/Category.cs#L1) - Represents categories
- [CategoryBudget.cs](final/FinalProject/CategoryBudget.cs#L1) - Monthly budgets per category
- [Account.cs](final/FinalProject/Account.cs#L1) - Accounts
- [Transaction.cs](final/FinalProject/Transaction.cs#L1) - Base class for all transactions
- [Income.cs](final/FinalProject/Income.cs#L1) - Income transactions
- [Expense.cs](final/FinalProject/Expense.cs#L1) - Expense transactions
- [MonthlyReport.cs](final/FinalProject/MonthlyReport.cs#L1) - Representation of a monthly report
- [OverBudgetInfo.cs](final/FinalProject/OverBudgetInfo.cs#L1) - Information about budget overruns


**Sample Output**
```
Monthly Report for 12/2025:
Total Income: ¥100,000
Total Expense: ¥45,000
Net Balance: ¥55,000
Category Expenses: Food: ¥30,000, Entertainment: ¥15,000
Over Budget Categories: Entertainment (Limit: ¥10,000, Used: ¥15,000, Over: ¥5,000)
```

***

