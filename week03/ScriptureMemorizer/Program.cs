// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // CREATIVITY & EXCEEDS CORE REQUIREMENTS
        // 1. Creating a library of 5 different scriptures
        // 2. Randomly selecting one scripture each time the program runs
        // 3. Only hiding words that are not yet hidden (stretch goal)
        // 4. Added welcome and motivational messages


        Console.WriteLine("=== Scripture Memorizer ===");
        Console.WriteLine("Helping you hide God's Word in your heart!\n");
        Console.WriteLine("Press Enter to begin...");

        // Library of Scriptures
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only son, that whoever believes in him shall not perish but have everlasting life."),

            new Scripture(new Reference("Psalm", 23, 1),
                "The Lord is my shepherd, I lack nothing."),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),

            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ who strengths me."),

            new Scripture(new Reference("Mathew", 6, 33),
                "But seek first his kingdom and his righteousness, and all these things will be given to you as well.")
        };

        // Randomly choose one scripture
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden! Excellent work memorizing");
                break;
            }
        }

        Console.WriteLine("\nThank you for using Scripture Memorizer!");
    }
}