using System.Numerics;

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        int total = GetPoints();

        if (_currentCount == _targetCount)
        {
            total += _bonusPoints;
        }
        return total;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStatusString()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        return $"{check} {GetName()} ({GetDescription()}) -- Currently completed: {_currentCount}/{_targetCount}";
    }

    public override string GetDetailString()
    {
        return $"{GetName()} ({GetPoints()} points each, bonus {_bonusPoints} at {_targetCount} times)";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal: {GetName()}, {GetDescription()}, {GetPoints()}, {_targetCount}, {_bonusPoints}, {_currentCount}";
    }
}
