using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        // grades is a private field and the convention is to make it lowercase 
        List<double> grades;
        public string Name;



        public Book(string name)
        {
            // You have to instantiate it to create the list of grades or it will give a null exception because of the grades field has not been instantiated 
            grades = new List<double>() ;
            Name = name;

        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        // Return a instance of Statistics object that contains highest, lowest, and average grades
        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            result.Average = 0.0;
            result.HighestGrade = double.MinValue;
            result.LowestGrade = double.MaxValue;

            foreach (double grade in grades)
            {
                // finds the highest number of the two and assign it to result.High 
                result.HighestGrade = Math.Max(grade, result.HighestGrade);
                result.LowestGrade = Math.Min(grade, result.LowestGrade);
                result.Average += grade;
            }

            result.Average /= grades.Count;
            return result; 
  

        }
    }
}
