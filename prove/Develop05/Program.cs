using System;

// EXTRA CREDIT: I added a leveling system.
// The user has a Level and a Rank Title that change based on the total score.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("You have  " + manager.GetTotalScore() + " points.");
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine(" 1. Create New Goal");
                Console.WriteLine(" 2. List Goals");
                Console.WriteLine(" 3. Save Goals");
                Console.WriteLine(" 4. Load Goals");
                Console.WriteLine(" 5. Record Event");
                Console.WriteLine(" 5. Quit");
                Console.Write("Select a choice from the menu: ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        manager.CreateGoal();
                        break;
                    case "2":
                        manager.DisplayGoals();
                        break;
                    case "3":
                        Console.Write("What is the filename to save to? ");
                        string saveFile = Console.ReadLine();
                        manager.Save(saveFile);
                        
                        break;
                    case "4":
                        Console.Write("What is the filename to load from? ");
                        string loadFile = Console.ReadLine();
                        manager.Load(loadFile);
                        break;
                    case "5":
                        manager.DisplayGoals();
                        Console.Write("Which goal did you accomplish? (number): ");
                        int index = int.Parse(Console.ReadLine() ?? "0") - 1;
                        manager.RecordEventFor(index);

                        break;
                    case "6":
                        running = false;
                        break;
                    case "7":
                        
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
