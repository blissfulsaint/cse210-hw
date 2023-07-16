public class SimpleGoal : Goal
{
    public SimpleGoal(string goal, string description, int points)
    {
        _goalType = "SimpleGoal";
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public SimpleGoal(string goal, string description, int points, bool isComplete)
    {
        _goalType = "SimpleGoal";
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }
}