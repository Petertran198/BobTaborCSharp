using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    class Book
    {
        // grades is a private field and the convention is to make it lowercase 
        List<double> grades;
        string name;
        double results = 0.0;
        double highestGrade = double.MinValue;
        double lowestGrade = double.MaxValue;


        public Book(string name)
        {
            // You have to instantiate it to create the list of grades or it will give a null exception because of the grades field has not been instantiated 
            grades = new List<double>() ;
            this.name = name;

        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        // Show the highest,average,& lowest grades
        public void ShowStatistics()
        {

            foreach (double number in grades)
            {
                // finds the highest number of the two and assign it to highGrade 
                highestGrade = Math.Max(number, highestGrade);
                lowestGrade = Math.Min(number, lowestGrade);
                results += number;
            }
            // numeric formatting :N1 will give the result with one decimal place
            Console.WriteLine($"The lowest grade is {lowestGrade:N1}");
            Console.WriteLine($"The highest grade is {highestGrade:N1}");
            Console.WriteLine($"The average grade is {(results / grades.Count):N1}");
        }
    }
}
