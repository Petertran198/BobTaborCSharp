using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        // "[Fact]" represents a unit test method. Results in a pass or fail
        [Fact]
        public void BookCalculatesGrade()
        {
            //Arrange (Put together data for test)
            Book book = new Book("book1");
            book.AddGrade(100);
            book.AddGrade(32.1);


            //Act (Put together method to do the calculation or produces the result) 
            var result = book.GetStatistics();
            //Assert (Check the result) 

            Assert.Equal(100, result.HighestGrade);
            Assert.Equal(32.1, result.LowestGrade);


        }
        [Fact]
        public void BookCalculateLetterGrade()
        {
            var book = new Book("book 1");
            book.AddGrade(90);
            book.AddGrade(90);
            book.AddGrade(90);
            Statistics stats = book.GetStatistics();
            Assert.Equal('A', stats.LetterGrade);
        }
    }
}
