using System;
using System.Reflection.PortableExecutable;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        // Create 3 videos with 3-4 comments each
        Video video1 = new Video("C# Abstraction Explained", "TechProfessor", 720);
        video1.AddComment (new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "This helped me alot."));
        video1.AddComment(new Comment("Charlie", "Could you do more on inheritance?"));

        Video video2 = new Video("Building Classes in C#", "CodeMaster", 450);
        video2.AddComment(new Comment("Dave", "Super clear tutorial."));
        video2.AddComment(new Comment("Eve","Thanks for the examples!"));
        video2.AddComment(new Comment("Frank", "Loving the series."));
        video2.AddComment(new Comment("Grace", "When is the next video?"));

        Video video3 = new Video("OOP Principles", "DevAcademy", 600);
        video3.AddComment(new Comment("Hank","Abstraction is key."));
        video3.AddComment(new Comment("Ivy", "Well done."));
        video3.AddComment(new Comment("Jack", "More examples please."));

        //Put them in a list
        List<Video> videos = new List<Video> { video1, video2, video3};

        //Display everthing
        foreach (var video in videos)
        {
             video.Display();
        }
    }
}