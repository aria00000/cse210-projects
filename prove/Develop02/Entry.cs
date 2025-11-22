using System;
public class Entry
{
    public string _response;
    public string _prompt;
    public string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

    public string Serialize()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry Deserialize(string line)
    {
        string[] parts = line.Split("|");
        return new Entry(parts[1], parts[2], parts[0]);
    }



    public static string GetRandomPrompt()
    {
        List<string> _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    
    

}