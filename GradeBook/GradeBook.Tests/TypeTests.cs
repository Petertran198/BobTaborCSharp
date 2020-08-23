using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

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
            Assert.Same(book, book2);

        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
