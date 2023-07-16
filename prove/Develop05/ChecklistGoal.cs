public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _completionGoal;
    private int _bonusPoints;

    public ChecklistGoal(string goal, string description, int points, int completionGoal, int bonusPoints)
    {
        _goalType = "ChecklistGoal";
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = false;
        _completionGoal = completionGoal;
        _bonusPoints = bonusPoints;
        _timesCompleted = 0;
    }

    public ChecklistGoal(string goal, string description, int points, int completionGoal, int bonusPoints, int timesCompleted)
    {
        _goalType = "ChecklistGoal";
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = false;
        _completionGoal = completionGoal;
        _bonusPoints = bonusPoints;
        _timesCompleted = timesCompleted;
    }

    public ChecklistGoal(string goal, string description, int points, int completionGoal, int bonusPoints, int timesCompleted, bool isComplete)
    {
        _goalType = "ChecklistGoal";
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = isComplete;
        _completionGoal = completionGoal;
        _bonusPoints = bonusPoints;
        _timesCompleted = timesCompleted;
    }

    public override int Record()
    {
        int reward = 0;

        reward += _points;
        _timesCompleted++;

        if (_timesCompleted >= _completionGoal)
        {
            _isComplete = true;
            reward += _bonusPoints;
        }        

        return reward;
    }

    public override void Display()
    {
        base.Display();

        Console.Write($" --- Completed {_timesCompleted}/{_completionGoal}");
    }

    public void SetTimesCompleted(int timesCompleted)
    {
        _timesCompleted = timesCompleted;
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }

    public void SetCompletionGoal(int completionGoal)
    {
        _completionGoal = completionGoal;
    }

    public int GetCompletionGoal()
    {
        return _completionGoal;
    }

    public void SetBonusPoints(int bonusPoints)
    {
        _bonusPoints = bonusPoints;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
}