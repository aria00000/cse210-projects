using System;

public class Resume
{
    public string name;
    public List<Job> jobs = new List<Job>();

    public void DisplayResume()
    {
        Console.WriteLine($"Name:{name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in jobs)
        {
            job.DisplayJobDetails();
        }
    }

}