public class User
{
    private string _name;
    private int _points;
    private List<Goal> _goals = new List<Goal>();
    private List<Goal> _filteredGoals = new List<Goal>();

    public User()
    {
        _name = "";
        _points = 0;
    }
    
    public User(string name)
    {
        _name = name;
        _points = 0;
    }

    public User(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public User(string name, List<Goal> goals)
    {
        _name = name;
        _goals = goals;
        _points = 0;
    }

    public User(string name, int points, List<Goal> goals)
    {
        _name = name;
        _points = points;
        _goals = goals;
    }

    public void DisplayGoals()
    {
        int goalIndex = 0;
        foreach (Goal goal in _goals)
        {
            Console.Write($"{goalIndex}. ");
            goal.Display();
            Console.Write("\n");

            goalIndex++;
        }
    }

    public void DisplayFilteredGoals()
    {
        int goalIndex = 0;
        foreach (Goal goal in _filteredGoals)
        {
            Console.Write($"{goalIndex}. ");
            goal.Display();
            Console.Write("\n");

            goalIndex++;
        }
    }

    public void SetFilteredGoals(List<Goal> filteredGoals)
    {
        _filteredGoals = filteredGoals;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RemoveGoal(int index)
    {
        _goals.Remove(_goals[index]);
    }

    public void RemoveAllGoals()
    {
        _goals.Clear();
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }
}