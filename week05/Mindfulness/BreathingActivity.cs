using System;

public class BreathingActivity: Activity
{
    public BreathingActivity()
      :base ("BreathingActivity", "This activity will help you relax by guiding your Breathing.")
    {
    }
    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while(DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(4);

            Console.Write("Breathe out...");
            ShowCountDown(4);
        }
        DisplayEndingMessage();


    }
}