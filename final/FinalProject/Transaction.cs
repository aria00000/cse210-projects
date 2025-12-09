using System.Data;
using System.Security.Principal;

abstract class Transaction
{
    private DateTime _date;
    private decimal _amount;
    private string _description;
    private Category _category;
    private Account _account;

    public Transaction(DateTime date, decimal amount, string description, Category category, Account account)
    {
        _date = date;
        _amount = amount;
        _description = description;
        _category = category;
        _account = account;
    } 

    public DateTime GetDate()
    {
        return _date;
    }

    public decimal GetAmount()
    {
        return _amount;
    }

    public string GetDescription()
    {
        return _description;
    }

    public Category GetCategory()
    {
        return _category;
    }

    public Account GetAccount()
    {
        return _account;
    }

    public abstract decimal GetNetAmount();

    public virtual string GetSummaryString()
    {
        return $"{_date.ToShortDateString()} - {_description}: {_amount:C} ({_category.GetName()})";
    }

}