public class Event
{
    protected string _eventTitle;
    protected string _description;
    protected string _date;
    protected string _time;
    protected Address _address = new Address();
    protected string _eventType;

    public void DisplayStandardDetails()
    {
        Console.WriteLine($"Title: {_eventTitle} \nDescription: {_description} \nDate: {_date} \nTime: {_time} \nAddress: {_address.GetAddress()}");
    }

    public virtual void DisplayFullDetails()
    {
        DisplayStandardDetails();
    }

    public void DisplayBriefDetails()
    {
        Console.WriteLine($"Event Type: {_eventType} \nEvent Title: {_eventTitle} \nDate: {_date}");
    }
}