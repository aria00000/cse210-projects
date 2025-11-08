using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("  Enter a list of numbers, type 0 when finished.");
        int sum = 0;
        int average = 0;
        int numberInput = -1;
        List<int> numbers = new List<int>();

        while (numberInput != 0)
        {
            Console.WriteLine("Enter a number: ");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);

            numberInput = number;
            numbers.Add(number);
        }
        foreach (int number in numbers)
        {
            sum += number;
        }
        average = sum / (numbers.Count - 1);

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}