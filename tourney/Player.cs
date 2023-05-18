public class Player
{
    private string _firstName;
    private string _lastName;
    private int _jerseyNumber;

    public Player(string firstName, string lastName, int jerseyNumber)
    {
        _firstName = firstName;
        _lastName = lastName;
        _jerseyNumber = jerseyNumber;
    }

    public void UpdateJersey(int newNumber)
    {
        _jerseyNumber = newNumber;
    }

    public void Display()
    {
        Console.WriteLine($"{_firstName} {_lastName} : {_jerseyNumber}");
    }

    public int GetJersey()
    {
        return _jerseyNumber;
    }

}