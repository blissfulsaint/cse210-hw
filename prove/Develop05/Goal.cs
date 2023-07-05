public class Goal
{
    protected string _goalType;
    protected string _goal;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public virtual int Record()
    {
        _isComplete = true;

        return _points;
    }

    public virtual void Display()
    {
        string completeStr = " ";
        if (_isComplete)
        {
            completeStr = "X";
        }

        Console.Write($"[{completeStr}] {_goal} ({_description})");
    }

    public void SetGoal(string goal)
    {
        _goal = goal;
    }

    public string GetGoal()
    {
        return _goal;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SetIncomplete()
    {
        _isComplete = false;
    }

    public bool CompletionStatus()
    {
        return _isComplete;
    }

    public string GetType()
    {
        return _goalType;
    }
}