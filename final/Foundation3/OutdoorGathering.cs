public class OutdoorGathering : Event
{
    string _forecast;

    public OutdoorGathering()
    {
        _eventType = "Outdoor Gathering";
    }

    public OutdoorGathering(string eventTitle, string description, string date, string time, Address address, string forecast)
    {
        _eventTitle = eventTitle;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
        _forecast = forecast;
        _eventType = "Outdoor Gathering";
    }

    public override void DisplayFullDetails()
    {
        base.DisplayFullDetails();
        Console.WriteLine($"Forecast: {_forecast}");
    }
}