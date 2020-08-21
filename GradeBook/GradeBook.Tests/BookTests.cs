using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        // "[Fact]" represents a unit test method. Results in a pass or fail
        [Fact]
        public void Test1()
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
    }
}
