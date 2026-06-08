using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    public GratitudeActivity()
       :base("Gratitude Activity", "Focus on things you are grateful for in your life.")
    {
    }

public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("Enter things you are grateful for.");
        Console.WriteLine();

        int count = 0;

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while(DateTime.Now < endTime)
        {
            Console.Write("Grateful for:");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine();
        Console.WriteLine($"You recorded {count} gratitude items.");

        DisplayEndingMessage();
    }
}