public class ReflectionActivity : MindfulnessActivity
{
    List<string> prompts = new List<string>();
    List<string> questions = new List<string>();
    int cycleTime = 10;
    public ReflectionActivity()
    {
        _activityType = "Reflection Activity";
        _startMsg = "Welcome to the Reflection Activity!";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        prompts.Add("Think of a time when you stood up for someone else. ");
        prompts.Add("Think of a time when you did something really difficult. ");
        prompts.Add("Think of a time when you helped someone in need. ");
        prompts.Add("Think of a time when you did something truly selfless. ");

        questions.Add("Why was this experience meaningful to you? ");
        questions.Add("Have you ever done anything like this before? ");
        questions.Add("How did you get started? ");
        questions.Add("How did you feel when it was complete? ");
        questions.Add("What made this time different than other times when you were not as successful? ");
        questions.Add("What could you learn from this experience that applies to other situations? ");
        questions.Add("How can you keep this experience in mind in the future? ");
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

    private void PlayActivity()
    {
        int promptListLength = prompts.Count();
        int questionListLength = questions.Count();
        Random rand = new Random();

        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {prompts[rand.Next(0, promptListLength)]} --- \n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("you may begin in: ");
        Countdown(5);

        Console.Clear();

        List<int> usedQuestions = new List<int>();
        int duration = 0;

        do 
        {
            int questionIndex = rand.Next(0, questionListLength);

            if (!usedQuestions.Contains(questionIndex))
            {
                string question = questions[questionIndex];
                Console.Write($"> {question}");
                Pause(cycleTime);
                Console.Write("\n");
                duration += cycleTime;
                usedQuestions.Add(questionIndex);
            }
        } while (duration < _duration && usedQuestions.Count() < questionListLength);
    }
}