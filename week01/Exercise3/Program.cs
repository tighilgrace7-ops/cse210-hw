using System;
using System.ComponentModel;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        // Computer generates random number (REQUIRED)
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        
        int guess = -1;

        // Loop untill correct guess
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine() ?? "0");

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
            
        }
    }
}