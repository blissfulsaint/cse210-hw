public class Swimming : Activity
{
    int _laps;

    public Swimming()
    {
        _activityType = "Swimming";
    }

    public Swimming(string date, int length, int laps)
    {
        _activityType = "Swimming";
        _date = date;
        _length = length;
        _laps = laps;
    }

    protected override void CalculateMissingInfo()
    {
        double lengthHours = (double)_length / 60;

        _distance = ((double)_laps * 50) / 1000;
        _speed = Math.Round(_distance / lengthHours, 1);
        _pace = Math.Round((double)_length / _distance, 1);
    }
}