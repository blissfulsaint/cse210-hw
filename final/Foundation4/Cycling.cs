public class Cycling : Activity
{
    public Cycling()
    {
        _activityType = "Cycling";
    }

    public Cycling(string date, int length, double speed)
    {
        _activityType = "Cycling";
        _date = date;
        _length = length;
        _speed = speed;
    }

    protected override void CalculateMissingInfo()
    {
        double lengthHours = (double)_length / 60;

        _distance = Math.Round(_speed * lengthHours, 1);
        _pace = Math.Round((double)_length / _distance, 1);
    }
}