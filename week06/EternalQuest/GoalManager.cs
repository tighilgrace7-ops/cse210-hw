using System;
using System.Collections.Generic;
using System.IO;


public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
{
    return (_score / 1000) + 1;
}

public string GetTitle()
{
    if (_score >= 5000)
        return "Master of Eternal Quest";

    if (_score >= 3000)
        return "Quest Champion";

    if (_score >= 1000)
        return "Eternal Adventurer";

    return "Beginner Explorer";
}

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void CreateGoal()
    {
        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Select a choice: ");
        string choice = Console.ReadLine();

        Console.Write("Goal Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                 _goals.Add(new SimpleGoal(name, description, points));
                 break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":

                Console.Write("Target Completions: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));

                break;
        }
        Console.WriteLine("Goal Created!");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        int earnedpoints = _goals[choice - 1].RecordEvent();

        _score += earnedpoints;

        Console.WriteLine($"Congratulations! You earned {earnedpoints} points!");

        Console.WriteLine($"Your total score is now {_score}.");
    }

    public void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
                    
                }
            }
            Console.WriteLine("Goals saved.");
        } 
        public void LoadGoals()
        {
            Console.Write("Filename: ");
            string filename = Console.ReadLine();

            string[] lines = File.ReadAllLines(filename);

            _goals.Clear();

            _score = int.Parse(lines[0]);

            for (int i =1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');

                string goalType = parts[0];
                string[] data = parts[1].Split(',');

                if (goalType == "SimpleGoal")
                {
                    
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                }

                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    
                }

                else if (goalType == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
                }

            }
            
            Console.WriteLine("Goals loaded.");
        }
        
    }
