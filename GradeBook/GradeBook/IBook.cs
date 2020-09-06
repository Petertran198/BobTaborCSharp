using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    // Method and properties every class must have who inherit from the interface 
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;

    }
}
