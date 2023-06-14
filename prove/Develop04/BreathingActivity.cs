public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        _activityType = "Breathing Activity";
        _startMsg = "Welcome to the Breathing Activity!";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Display()
    {
        DisplayStart();

        double duration = Convert.ToDouble(_duration);
        int cycles = Convert.ToInt16(Math.Ceiling(duration / 10));

        Console.Clear();
        Console.Write("Get ready...");
        Pause(4);
        Console.WriteLine("\n\n");

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in...");
            Countdown(5);
            Console.WriteLine("");
            Console.Write("Breathe out...");
            Countdown(5);
            Console.WriteLine("\n");
        }

        DisplayEnd();
    }
}