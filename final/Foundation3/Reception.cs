public class Reception : Event
{
    string _RSVPEmail;

    public Reception()
    {
        _eventType = "Reception";
    }

    public Reception(string eventTitle, string description, string date, string time, Address address, string RSVPEmail)
    {
        _eventTitle = eventTitle;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
        _RSVPEmail = RSVPEmail;
        _eventType = "Reception";
    }

    public override void DisplayFullDetails()
    {
        base.DisplayFullDetails();
        Console.WriteLine($"Email here to RSVP: {_RSVPEmail}");
    }
}