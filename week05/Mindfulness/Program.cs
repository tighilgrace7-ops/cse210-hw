//EXCEEDING REQUIREMENTS
//
// 1. Added a Gratitude Activity.
// 2. Added activity completion statistics.
// 3. Reflection questions are not repeated until all have been used.

using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string choice="";
        while(choice!= "5")
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("---------------");
            Console.WriteLine($"Activities Completed: {Activity.GetCompletedActivities()}");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Gratitude Activity");
            Console.WriteLine("5. Quit");

            Console.Write("\nSelect a choice from the menu:");
            choice = Console.ReadLine();

            switch (choice)
            {
               case "1":
                 new BreathingActivity().Run();
                 break; 

               case "2":
                 new ReflectionActivity().Run();
                 break;
                  
               case "3":
                 new ListingActivity().Run();
                 break;

               case "4":
                 new GratitudeActivity().Run();
                 break;

               case "5":
                 Console.WriteLine("Goodbye!");
                 break;

               default:
                Console.WriteLine("Invalid choice.");
                Thread.Sleep(1000);
                break;


            }
        }
    }
}