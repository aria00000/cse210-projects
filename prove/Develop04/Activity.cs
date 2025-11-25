public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void Start()
    {
        Log($"Welcome to {_name}");
        Console.WriteLine();
        Log(_description);
        Console.WriteLine();
        Log("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        int duration = int.Parse(input);
        Log($"User input duration: {input}");
        SetDuration(duration);
        Console.Clear();
        Log("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine();
    }



    public void End()
    {
        Console.WriteLine();
        Log("Well done!");
        ShowSpinner(5);
        Console.WriteLine();
        Log($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(5);
        Console.Clear();
    }

     public void ShowSpinner(int seconds)
    {
        string[] spin = { "/", "-", "\\", "|" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
        Console.Write(spin[i % 4]);
        Thread.Sleep(200);
        Console.Write("\b \b");
        i++;
        }
    }
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }

   //Creative part: activity to a file
    public void Log(string message)
    {
    Console.WriteLine(message);                  
    File.AppendAllText("log.txt", message + "\n"); 
    }
}




