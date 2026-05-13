using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;

        //Display this once
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Loop for numbers
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");

            userNumber = int.Parse(Console.ReadLine()); 

            // Do not add 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Find the sum
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Find the average
        float average = (float)sum / numbers.Count;

        Console. WriteLine($"The average is: {average}");

        // Find the largest number
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}