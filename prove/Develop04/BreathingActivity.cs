public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    private void DoBreathingCycle()
    {
        int duration = GetDuration();

        Log("Breathe in...");
        ShowCountdown(3);
        Log("Now breathe out...");
        ShowCountdown(3);
        Console.WriteLine();
        Console.WriteLine();

        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            Log("Breathe in...");
            ShowCountdown(4);
            Log("Now breathe out...");
            ShowCountdown(6);
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public void Run()
    {
            Start();
            DoBreathingCycle();
            End();
    }

    }
