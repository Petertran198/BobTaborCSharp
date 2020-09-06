using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GradeBook
{
    class Program
    {
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"-------- Added grade -------");
        }

        static void Main(string[] args)
        {

            InMemoryBook book = new InMemoryBook(name: "First Math book", category: "Math");
            // Added OnGradeAdded method into the book.GradeAdded delegate 
            //Since this is an event delegate you can += or -= 
            // but you cant do something like book.GradeAdded = null 
            // like a pure delegate 
            book.GradeAdded += OnGradeAdded;
            EnterGrade(book);

            Statistics stats = book.GetStatistics();
            Console.WriteLine($"For the book {book.Name} in {book.Category} Category");
            Console.WriteLine($"The average grade is {stats.Average} which is a {stats.LetterGrade}");
            Console.WriteLine($"The highest grade is {stats.HighestGrade}");
            Console.WriteLine($"The lowest grade is {stats.LowestGrade}");

        }
        
        // Takes in any type of book that has the IBook interface and allow you to enter grades
        public static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a Grade, press 'q' you are done");
                string gradeString = Console.ReadLine();
                if (gradeString == "q")
                {
                    Console.WriteLine("Grade has been inputed");
                    break;
                }
                try
                {
                    var grade = double.Parse(gradeString);
                    book.AddGrade(grade);
                }// One try block can have multiple catch for different exception
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
