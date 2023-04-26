using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the random number guessing game! The \nprogram will generate a random number between 1 and 100, and it \nis up to guess what it is! Every time you guess, you will be \ngiven a hint as to whether the number is higher or lower than your guess.");
        Console.WriteLine("");
        Console.WriteLine("Let's get started!");

        string playAgain;

        do 
        {
            Random randomGenerator = new Random();
            int magicNum = randomGenerator.Next(1,100);
            int guessNum;

            int guessAmt = 0;

            do 
            {
                Console.Write("What is your guess? ");
                guessNum = int.Parse(Console.ReadLine());

                guessAmt++;

                if (guessNum != magicNum) 
                {
                    if (guessNum > magicNum) 
                    {
                        Console.WriteLine("Lower");
                    }
                    else if (guessNum < magicNum) 
                    {
                        Console.WriteLine("Higher");
                    }
                }
                else 
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You made {guessAmt} guesses");
                    Console.WriteLine("");
                }
            } while (guessNum != magicNum);

            do 
            {
                Console.Write("Would you like to play again? ");
                playAgain = Console.ReadLine();

                Console.WriteLine("");

                if (playAgain != "yes" && playAgain != "no")
                {
                    Console.WriteLine("Please enter 'yes' or 'no'");
                }
            } while (playAgain != "yes" && playAgain != "no");
        } while (playAgain == "yes");
    }
}