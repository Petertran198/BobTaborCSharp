using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GradeBook
{
    class Program
    {
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("hello");
        }

        static void Main(string[] args)
        {

            Book book = new Book(name: "First Math book", category: "Math");
            // Added OnGradeAdded method into the book.GradeAdded delegate 
            //Since this is an event delegate you can += or -= 
            // but you cant do something like book.GradeAdded = null 
            // like a pure delegate 
            book.GradeAdded += OnGradeAdded;
            book.InputGrade();

            Statistics stats = book.GetStatistics();
            Console.WriteLine($"For the book {book.Name} in {book.Category} Category");
            Console.WriteLine($"The average grade is {stats.Average} which is a {stats.LetterGrade}");
            Console.WriteLine($"The highest grade is {stats.HighestGrade}");
            Console.WriteLine($"The lowest grade is {stats.LowestGrade}");

        }
    }
}
