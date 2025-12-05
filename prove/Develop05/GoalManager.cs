class GoalManager
{
        private List<Goal> _goals = new List<Goal>();
        private int _totalScore = 0;

        public GoalManager()
        {
        }


        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public List<Goal> GetGoals()
        {
            return _goals;
        }


        public void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatusString()}");
            }
            Console.WriteLine($"Level: {GetLevel()} - {GetLevelName()}");
        }

        public int GetTotalScore()
        {
            return _totalScore;
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine(" 1. Simple Goal");
            Console.WriteLine(" 2. Eternal Goal");
            Console.WriteLine(" 3. Checklist Goal");
            Console.Write("What type of goal would you like to create? ");

            int choice = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal?");
            int points = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1:
                    AddGoal(new SimpleGoal(name, description, points));
                    break;
                case 2:
                    AddGoal(new EternalGoal(name, description, points));
                    break;
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine() ?? "0");

                    AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid choice. No goal created.");
                    break;
            }
        }

        public void RecordEventFor(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal index.");
                return;
            }

            Goal goal = _goals[index];
            int gained = goal.RecordEvent();
            _totalScore += gained;

            Console.WriteLine($"Congratulations! You have earned {gained} points!");
            Console.WriteLine($"You now have {_totalScore} points.");
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {

                writer.WriteLine(_totalScore);


                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetSaveString());
                }
            }

        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);

            _goals.Clear();

            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }


            _totalScore = int.Parse(lines[0]);


            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                Goal goal = CreateGoalFromData(line);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

        }

        public int GetLevel()
        {
            int score = _totalScore;

            return score / 10 +1;
        }

        public string GetLevelName()
        {
            int level = GetLevel();

            if (level <= 10)
            {
                return "Beginner";
            }
            else if (level <= 20 && level > 10)
            {
                return "Intermediate";
            }
            else if (level <= 30 && level > 20)
            {
                return "Advanced";
            }
            else
            {
                return "Expert";
            }
        }

        private Goal CreateGoalFromData(string data)
        {
            string[] typeAndData = data.Split(':');
            
            if (typeAndData.Length < 2)
            {
                Console.WriteLine($"Unknown goal type or bad data: {data}");
                return null;
            }

            string type = typeAndData[0].Trim();
            string[] parts = typeAndData[1].Split(',');

            // Trim whitespace from all parts
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim();
            }

            if (type == "SimpleGoal" && parts.Length >= 4)
            {
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                bool isComplete = bool.Parse(parts[3]);

                return new SimpleGoal(name, description, points, isComplete);
            }
            else if (type == "EternalGoal" && parts.Length >= 3)
            {
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);

                return new EternalGoal(name, description, points);
            }
            else if (type == "ChecklistGoal" && parts.Length >= 6)
            {
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                int targetCount = int.Parse(parts[3]);
                int bonusPoints = int.Parse(parts[4]);
                int currentCount = int.Parse(parts[5]);

                return new ChecklistGoal(name, description, points, targetCount, bonusPoints, currentCount);
            }
            else
            {
                Console.WriteLine($"Unknown goal type or bad data: {data}");
                return null;
            }
        }
    }