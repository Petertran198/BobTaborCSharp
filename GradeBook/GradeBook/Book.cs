using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    // Every book will inherit from this abstract class.
    // All book will require a method called AddGrade that requires a double and returns nothing 
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
            Name = name;
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
        
    }

}
