using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "";
        string[] options = {"1", "2", "3", "4", "5", "6"};

        while (response != "6")
        {
            response = "";
            while (options.Contains(response) == false)
            {
                Console.Clear();
                Console.WriteLine("Menu Options: \n1. Create New Goal \n2. List Goals \n3. Save Goals \n4. Load Goals \n5. Record Event \n6. Quit \nSelect a choice from the menu: ");
                response = Console.ReadLine() ?? String.Empty;
            }
            switch (response)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}