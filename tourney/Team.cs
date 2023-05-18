public class Team
{
    private List<Player> _roster = new List<Player>();
    private List<string> _sponsor = new List<string>();
    private string _name;
    private int _wins;
    private int _losses;

    public Team(string name, int wins = 0, int losses = 0)
    {
        _name = name;
        _wins = wins;
        _losses = losses;
    }

    public void AddPlayer(Player p)
    {
        foreach (Player existingPlayer in _roster)
        {
            if (p.GetJersey() == existingPlayer.GetJersey())
            {
                Console.WriteLine("Can't add a player with an existing Jersey number");
                return;
            }
        }
        _roster.Add(p);
    }

    public void AddWin()
    {
        _wins++;
    }

    public void AddLoss()
    {
        _losses++;
    }

    public void Display()
    {
        Console.WriteLine($"{_name} {_wins}/{_losses}");
        foreach (Player p in _roster)
        {
            p.Display();
        }
    }

    public string GetTeamName()
    {
        return _name;
    }
}