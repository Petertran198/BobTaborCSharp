using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void ParametersArePassedByValue()
        {
            var book1 = new Book("book 1");
            // Passed the value of book1(which contains a memory location) to GetBookSetName method  
            // GetBookSetName then is reasigning that value with a new instance of Book 
            // Therefore it isn't changing anything to the memory location of book1 and book1.Name is still book 1 outside the context of GetBookSetName
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);

        }

        [Fact]
        public void BookClassReturnsDifferentObjects()
        {
            var book = GetBook("book");
            var book2 = GetBook("book");
            Assert.NotSame(book, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObjects()
        {
            var book = GetBook("Book 1");
            var book2 = book;
            // The two varaiables holds the same value, and the value is a reference to one memory location
            Assert.Same(book, book2);
            // change the name of one of the variable
            ChangeName(book, "changed name");
            // proved that changing the name of one variable will change the other as well because they both point to the same memory location
            Assert.Equal("changed name", book2.Name);

        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
         void ChangeName(Book book, string name)
        {
            book.Name = name;
        }
    }
}
