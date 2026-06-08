using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Security.AccessControl;
public class ReflectionActivity: Activity
{
    private List<string>_prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this experience different?",
        "What is your favourite thing about this experience?",
        "What did you learn about yourself?",
        "How can you keep this experiennce in mind in the future?"
    };

    private List<string> _unusedQuestions;

    public ReflectionActivity()
       :base("ReflectionActivity", "This activity helps you reflect on strengths and resilience.")
    {
        _unusedQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt.");
        Console.WriteLine();

        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine();
        Console.WriteLine("Press Enter when ready.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while(DateTime.Now < endTime)
        {
            if(_unusedQuestions.Count == 0)
            {
                _unusedQuestions = new List<string>(_questions);
            }

            int index = random.Next(_unusedQuestions.Count);

            Console.WriteLine();
            Console.Write($"> {_unusedQuestions[index]}");

            _unusedQuestions.RemoveAt(index);

            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}