using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using Xunit;

namespace GradeBook.Tests
{   
    // Creating a delegate type that will return a string 
    // This is basically a type that points to methods with a particular parameter list and return type
    // In this case something that returns a string and has a string parameter
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethods()
        {
            // Creating an delegate of type WriteLogDelegate 
            WriteLogDelegate log;
            // Pointing the delegate to the method RetunMessage 
            // This works because a delegate and the method both have the same params and return value
            log = ReturnMessage;
            string result = log("From ReturnMessage");
            // Check that log delegate is actually pointing to ReturnMessage Method
            Assert.Equal("From ReturnMessage FIRST Method", result);
            // ----------------------------------------------------------------------------------------------------
            // Creating an delegate of type WriteLogDelegate 
            WriteLogDelegate log2;
            // Pointing the delegate to the method RetunMessage2 
            // This works because a delegate and the method both have the same params and return value
            log2 = ReturnMessage2;
            string secondResult = log2("From ReturnMessage2");
            // Check that log delegate is actually pointing to ReturnMessage2 Method
            Assert.Equal("From ReturnMessage2 SECOND Method", secondResult);
        }
        string ReturnMessage(string message)
        {
            return ($"{message} FIRST Method"); 
        }

        string ReturnMessage2(string message)
        {
            return ($"{message} SECOND Method");
        }
    



        [Fact]
        public void ParametersArePassedByValue()
        {
            var book1 = new InMemoryBook("book 1");
            // Passed the value of book1(which contains a memory location) to GetBookSetName method  
            // GetBookSetName then is reasigning that value with a new instance of InMemoryBook 
            // Therefore it isn't changing anything to the memory location of book1 and book1.Name is still book 1 outside the context of GetBookSetName
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);

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
            var book = GetBook("InMemoryBook 1");
            var book2 = book;
            // The two varaiables holds the same value, and the value is a reference to one memory location
            Assert.Same(book, book2);
            // change the name of one of the variable
            ChangeName(book, "changed name");
            // proved that changing the name of one variable will change the other as well because they both point to the same memory location
            Assert.Equal("changed name", book2.Name);

        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
         void ChangeName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        
    }
}
