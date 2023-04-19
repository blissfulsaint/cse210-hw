using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep2 World!");

        Console.Write("Enter your percentage grade: ");
        string gradeString = Console.ReadLine();
        int gradeInt = int.Parse(gradeString);

        Console.WriteLine("");

        string letterGrade;
        if (gradeInt >= 90) 
        {
            letterGrade = "A";
        }
        else if (gradeInt >= 80)
        {
            letterGrade = "B";
        }
        else if (gradeInt >= 70)
        {
            letterGrade = "C";
        }
        else if (gradeInt >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        if (gradeInt % 10 >= 7 && letterGrade != "A" && letterGrade != "F") 
        {
            letterGrade += "+";
        }
        else if (gradeInt % 10 < 3 && letterGrade != "F")
        {
            letterGrade += "-";
        }

        Console.WriteLine($"Your letter grade is {letterGrade}");

        if (gradeInt >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }
        else 
        {
            Console.WriteLine("Looks like you didn't pass. Study harder next time!");
        }
    }
}