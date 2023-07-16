public class Running : Activity
{
    public Running()
    {
        _activityType = "Running";
    }

    public Running(string date, int length, double distance)
    {
        _activityType = "Running";
        _date = date;
        _length = length;
        _distance = distance;
    }

    protected override void CalculateMissingInfo()
    {
        double lengthHours = (double)_length / 60;

        _speed = Math.Round(_distance / lengthHours, 1);
        _pace = Math.Round((double)_length / _distance, 1);
    } 
}