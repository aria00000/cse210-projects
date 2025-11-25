public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string>_items = new List<string>();

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
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
        string prompt = GetRandomPrompt();
        Log("List as many responses as you can to the following prompt:");
        Log($"--- {prompt} ---");
        Log("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
    }

    private void CollectItems()
    {
        _items.Clear();
        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            _items.Add(item);
        }
        foreach (string item in _items)
        {
            Log($"Item listed: {item}");
        }

        int count = GetItemCount();
        Log($"You listed {count} items!");
    }

    private int GetItemCount()
    {
        return _items.Count;
    }


    public void Run()
    {
        Start();
        ShowPrompt();
        CollectItems();
        End();
    }

}