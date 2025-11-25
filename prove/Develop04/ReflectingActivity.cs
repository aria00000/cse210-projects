public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        return prompt;
    }
    private void ShowPrompt()
    {
        Log("Consider the following prompt:");
        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Log($"--- {prompt} ---");
        Console.WriteLine();
        Log("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Log("Now ponder on each of the following questions as they relate to this experience.");
        Log("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        string question = _questions[rand.Next(_questions.Count)];
        return question;
    }

    private void ShowReflectionQuestions()
    {
        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            string question = GetRandomQuestion();
            Log(question);
            ShowSpinner(10);
        }
        
    }


    public void Run()
    {
        Start();
        ShowPrompt();
        ShowReflectionQuestions();
        End();
    }
}