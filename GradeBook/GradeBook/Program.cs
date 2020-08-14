using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {



            // List type is similar to array but it is dynamic, meaning that you dont have to specify a size 
            List<double> grades = new List<double>(){60.2, 81.3, 92.2};  
    
            double results = 0.0;
            foreach (double number in grades)
            {   
                results += number; 
            }
            // numeric formatting :N1 will give the result with one decimal place
            Console.WriteLine($"The average grade is {(results/grades.Count):N1}");


        }
    }
}
