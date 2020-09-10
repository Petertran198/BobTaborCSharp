using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double HighestGrade;
        public double LowestGrade;
        public char LetterGrade
        {
            get
            {
                switch (Average)
                {
                    case var grade when (grade >= 90.0 && grade <= 100):
                        return LetterGrade = 'A';
                    case var grade when (grade >= 80.0 && grade < 90.0):
                        return LetterGrade = 'B';
                    case var grade when (grade >= 70 && grade < 80):
                        return LetterGrade = 'C';
                    case var grade when (grade >= 60.0 && grade < 70):
                        return LetterGrade = 'D';
                    default:
                        return LetterGrade = 'F';
                        
                }
            }
            set { }
        }
        int Count = 0;
        double Sum = 0;
        public Statistics()
        {
            HighestGrade = double.MinValue;
            LowestGrade = double.MaxValue;
        }
        
        public void AddGrade(double grade)
        {
            if(grade >0 && grade < 100)
            {
                Sum += grade;
                Count += 1;
                HighestGrade = Math.Max(grade, HighestGrade);
                LowestGrade = Math.Min(grade, LowestGrade);
            }
            else
            {
                Console.WriteLine($"Could not add {grade}");
            }

        }
    }
}
