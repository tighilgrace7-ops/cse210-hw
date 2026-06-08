using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string>_prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
       :base("Listing Activity", "List as many positive things as you can.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine("List responses to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"---{_prompts[random.Next(_prompts.Count)]}---");

        Console.WriteLine();
        Console.Write("You may begin in:");
        ShowCountDown(5);

        int count = 0;

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while(DateTime.Now < endTime)
        {
            Console.Write(">");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");

        DisplayEndingMessage();
    }
}
