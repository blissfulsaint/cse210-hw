public class EternalGoal : Goal
{
    public EternalGoal(string goal, string description, int points)
    {
        _goalType = "EternalGoal";
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public EternalGoal(string goal, string description, int points, bool isComplete)
    {
        _goalType = "EternalGoal";
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }
}