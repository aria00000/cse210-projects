using System;
using System.Collections.Generic;
using System.IO;


//for the creative part
//Add the serch function that searches entries by keyword
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        int option = 0;

        while (option != 6)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Quit");
            Console.WriteLine("What would you like to do?");
            string choice = Console.ReadLine();
            option = int.Parse(choice);

            if (option == 1)
            {
                string prompt = Entry.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();

                Entry newEntry = new Entry(prompt, response, dateText);
                journal.AddEntry(newEntry);




            }
            else if (option == 2)
            {
                journal.DisplayEntries();
            }
            else if (option == 3)
            {
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine();
                journal.LoadJournal(filename);
            }
            else if (option == 4)
            {
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            //for the creative part
            else if (option == 5)
            {
                Console.WriteLine("Enter a keyword to search:");
                string keyword = Console.ReadLine();
                journal.SearchEntries(keyword);
            }



        }
    }
}