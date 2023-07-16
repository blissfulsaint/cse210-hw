public class Lecture : Event
{
    string _speaker;
    int _capacity;

    public Lecture()
    {
        _eventType = "Lecture";
    }

    public Lecture(string eventTitle, string description, string date, string time, Address address, string speaker, int capacity)
    {
        _eventTitle = eventTitle;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
        _speaker = speaker;
        _capacity = capacity;
        _eventType = "Lecture";
    }

    public override void DisplayFullDetails()
    {
        base.DisplayFullDetails();
        Console.WriteLine($"Speaker: {_speaker} \nCapacity: {_capacity}");
    }
}