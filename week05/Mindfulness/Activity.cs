using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    private static int _completedActivies = 0;
    public Activity(string  name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session?");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the activity.");
        ShowSpinner(3);

        _completedActivies++;

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    protected void ShowSpinner(int seconds)
    {
        List<string>spinner = new List<string>
        {
            "|","/","-","\\"
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int index = 0;

        while(DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            index++;

            if(index >= spinner.Count)
            {
                index = 0;
            }
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public static int GetCompletedActivities()
    {
        return _completedActivies;
    }
}