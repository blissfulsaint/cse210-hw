public class MindfulnessActivity
{
    protected string _activityType;
    protected string _startMsg;
    protected string _description;
    protected int _duration;

    protected void DisplayStart()
    {
        Console.Clear();

        Console.WriteLine(_startMsg);
        Console.WriteLine("");
        Console.WriteLine(_description);
        Console.WriteLine("");
        
        string durationStr;

        do 
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            durationStr = Console.ReadLine();
        } while (!int.TryParse(durationStr, out int number));

        _duration = int.Parse(durationStr);
    }

    protected void DisplayEnd()
    {
        Console.WriteLine("Well done!\n");
        Pause(4);
        Console.WriteLine($"You participated in the {_activityType} for {_duration} seconds.\n");
        Pause(4);
    }

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write($"{seconds - i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}