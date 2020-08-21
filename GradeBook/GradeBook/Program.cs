using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {

            Book book = new Book("First book");
            book.AddGrade(10.2);
            book.AddGrade(80.2);
            book.AddGrade(90.1);
            
            book.ShowStatistics();
          


        }
    }
}
