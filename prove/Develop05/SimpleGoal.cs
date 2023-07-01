public class SimpleGoal : Goal
{
    public SimpleGoal(string goal, string description, int points)
    {
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = false;
    }
}