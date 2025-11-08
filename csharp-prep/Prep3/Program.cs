using System;

class Program
{
    static void Main(string[] args)
    {
        string guess = "false";
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        //Console.WriteLine($"Magic Number is: {magicNumber}");

        while (guess == "false")
        {

            Console.WriteLine("What is your guess?");
            string userGuessInput = Console.ReadLine();
            int userGuess = int.Parse(userGuessInput);

            if (userGuess < magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                guess = "true";
            }
        }


    }
}