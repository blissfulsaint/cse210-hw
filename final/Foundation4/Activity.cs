public class Activity
{
    protected string _activityType;
    protected string _date;
    protected int _length;
    protected double _speed;
    protected double _pace;
    protected double _distance;

    protected virtual void CalculateMissingInfo()
    {
    }

    public void DisplaySummary()
    {
        CalculateMissingInfo();
        Console.WriteLine($"{_date} {_activityType} ({_length} min)- Distance: {_distance} km, Speed: {_speed} kph, Pace: {_pace} min per km");
    }
}