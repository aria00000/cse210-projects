abstract class Goal
{
    private string name;
    private string description;
    private int points;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetPoints()
    {
        return points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStatusString();


    public virtual string GetDetailString()
    {
        return $"{name} ({description}) - {points} points";
    }

    public abstract string GetSaveString();
}