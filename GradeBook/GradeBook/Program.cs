using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {

            Book book = new Book(name: "First Math book", category: "Math");
            book.InputGrade();

            Statistics stats = book.GetStatistics();
            Console.WriteLine($"For the book {book.Name} in {book.Category} Category");
            Console.WriteLine($"The average grade is {stats.Average} which is a {stats.LetterGrade}");
            Console.WriteLine($"The highest grade is {stats.HighestGrade}");
            Console.WriteLine($"The lowest grade is {stats.LowestGrade}");

        }
    }
}
