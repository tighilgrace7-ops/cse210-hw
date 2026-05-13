using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage: ");

        int grade = int.Parse(Console.ReadLine());

        string letter = "";
        string sign ="";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = grade % 10;

        if (lastDigit>= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign ="-";
        }

        if (letter =="A" && sign == "+")
        {
            sign = "";
        }

        if (letter == "F")
        {
            sign = "";
        }
        Console.WriteLine($"Your grade is {letter}{sign}");
    }
}