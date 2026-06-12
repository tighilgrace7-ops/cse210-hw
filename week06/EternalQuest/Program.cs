using System;

/*
 * EXCEEDS REQUIREMENTS
 *
 * Added a gamification system with Levels and Achievement Titles.
 * Users gain a new level for every 1000 points earned.
 *
 * Achievement Titles:
 * - Beginner Explorer
 * - Eternal Adventurer
 * - Quest Champion
 * - Master of Eternal Quest
 *
 * These features provide additional motivation and
 * reward users for long-term progress beyond the
 * core Eternal Quest requirements.
 */

 class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {manager.GetScore()}");
            Console.WriteLine($"Level: {manager.GetLevel()}");
            Console.WriteLine($"Title:{manager.GetTitle()}");

            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Choose an option:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                  manager.CreateGoal();
                  break;

                  case "2":
                  manager.ListGoalDetails();
                  break;

                  case "3":
                  manager.SaveGoals();
                  break;

                  case "4":
                  manager.LoadGoals();
                  break;

                  case "5":
                  manager.RecordEvent();
                  break;

                  case "6":
                    return;
            }
        }

    }
}