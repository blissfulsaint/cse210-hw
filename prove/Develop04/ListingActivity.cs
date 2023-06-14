public class ListingActivity : MindfulnessActivity
{
    List<string> prompts = new List<string>();
    List<string> responses = new List<string>();
    public ListingActivity()
    {
        _activityType = "Listing Activity";
        _startMsg = "Welcome to the Listing Activity!";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        prompts.Add("Who are people that you appreciate?");
        prompts.Add("What are personal strengths of yours?");
        prompts.Add("Who are people that you have helped this week?");
        prompts.Add("When have you felt the Holy Ghost this month?");
        prompts.Add("Who are some of your personal heroes?");
    }

    public void Display()
    {
        DisplayStart();

        Console.Clear();
        Console.Write("Get ready...");
        Pause(4);
        Console.WriteLine("\n\n");

        PlayActivity();

        DisplayEnd();
    }

    public void PlayActivity()
    {
        Console.Clear();
        Random rand = new Random();

        int promptListLength = prompts.Count();

        int promptIndex = rand.Next(0, promptListLength);

        Console.WriteLine("List as many responses you can to the following prompt:\n");
        Console.WriteLine($" --- {prompts[promptIndex]} --- \n");
        Console.Write("You may begin in: ");
        Countdown(5);

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        DateTime currentTime;

        do 
        {
            Console.Write(" > ");
            string response = Console.ReadLine();
            responses.Add(response);

            currentTime = DateTime.Now;
        } while (currentTime < futureTime);

        Console.WriteLine($"You listed {responses.Count()} items!\n");
    }
}