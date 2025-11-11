using System;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date:{entry._date} - Prompt: {entry._prompt}");
            Console.WriteLine(entry._response);
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"Date:{entry._date} - Prompt: {entry._prompt}");
                outputFile.WriteLine(entry._response);
                outputFile.WriteLine();
            }
        }
    }

    public void LoadJournal(string filename)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
    
    //for the creative part
    public void SearchEntries(string keyword)
    {
        foreach (Entry entry in _entries)
        {
            if (entry._response.Contains(keyword) || entry._prompt.Contains(keyword))
            {
                Console.WriteLine($"Date:{entry._date} - Prompt: {entry._prompt}");
                Console.WriteLine(entry._response);
                Console.WriteLine();
            }
        }
    }


}