using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userInput;
        List<int> numbers = new List<int>();

        do 
        {
            Console.Write("Enter a number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        } while (userInput != 0);

        int numTotal = 0;
        float average = 0;
        int largestNum = 0;
        int smallestPos = 0;

        foreach (int num in numbers)
        {
            numTotal += num;
            
            if (num > largestNum)
            {
                largestNum = num;
            }

            if (num > 0)
            {
                if (smallestPos == 0 || num < smallestPos)
                {
                    smallestPos = num;
                }
            }
        }

        average = (float)numTotal / numbers.Count;
        numbers.Sort();

        Console.WriteLine($"The sum is: {numTotal}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestPos}");
        Console.WriteLine("The sorted list is: ");
        
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}