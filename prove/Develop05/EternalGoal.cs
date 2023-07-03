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
}