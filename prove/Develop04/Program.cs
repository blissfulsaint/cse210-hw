using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathing = new BreathingActivity();

        ReflectionActivity reflection = new ReflectionActivity();

        ListingActivity listing = new ListingActivity();


        Console.Clear();

        string response = "";
        string[] options = {"1", "2", "3", "4"};

        while (response != "4")
        {
            response = "";
            while (options.Contains(response) == false)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do? \n1. Breathing Activity \n2. Reflection Activity \n3. Listing Activity \n4. Quit");
                response = Console.ReadLine() ?? String.Empty;
            }
            switch (response)
            {
                case "1":
                    breathing.Display();
                    break;
                case "2":
                    reflection.Display();
                    break;
                case "3":
                    listing.Display();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}