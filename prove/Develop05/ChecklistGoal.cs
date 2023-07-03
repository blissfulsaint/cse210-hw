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
}