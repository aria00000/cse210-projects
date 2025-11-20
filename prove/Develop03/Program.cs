using System;

//Creative Extension Added:
// Implemented a Hint feature: user can type 'h' to reveal one


class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
        );

        while (true)
        {

            Console.Clear();
            Console.WriteLine(scripture.GetRenderedText());
            Console.WriteLine("Press enter to hide words, type 'h' for a hint, or 'quit' to exit:");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                break;
            }
            else if (input == "h")
            {
                scripture.ShowOneWord();
            }
            else
            {
                scripture.HideWords();
            }

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetRenderedText());
                Console.WriteLine("All words are hidden. Exiting program.");
                break;
            }




        }
    }
}