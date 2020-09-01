using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    // convention to build a delegate to define an event u send a sender(person is sending this event) of type object
    // Second is some form of event argument and we call it args 
    // Also notice that this is not inside of Book class but inside of namespace GradeBook
    public delegate void GradeAddedDelegate( object sender, EventArgs args);


    public class Book
    {
        // grades is a private field and the convention is to make it lowercase 
        List<double> grades;
        public string Name { get; set; }
        // Readonly field can only be declared once, either initilization or in the constructor
        public readonly string Category;
        // Defining a field of type GradeAddedDelegate in Book class
        // By adding the keyword event this adds restriction to the delegate. You can not assign it to method but you can add method to it
        // In another work .GradeAdded can only appear on the left hand side of += or -= 

        public event GradeAddedDelegate GradeAdded;
        public Book(string name, string category="N/A")
        {
            // You have to instantiate it to create the list of grades or it will give a null exception because of the grades field has not been instantiate
            grades = new List<double>();
            Name = name;
            Category = category;

        }
        public void InputGrade()
        {
            while (true)
            {
                Console.WriteLine("Enter a Grade, press 'q' you are done");
                string gradeString = Console.ReadLine();
                if (gradeString == "q")
                {
                    Console.WriteLine("Grade has been inputed");
                    break;
                }
                try
                {
                    var grade = double.Parse(gradeString);
                    AddGrade(grade);
                }// One try block can have multiple catch for different exception
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void AddGrade(double grade) /*----------Overloaded method---------- */
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                // We check if GradeAdded is populated if it isnt than that means no one is listening or added a method reference into the delegate
                if(GradeAdded != null)
                {
                    // if someone did added a method reference than we invoke the delegate 
                    GradeAdded(this, new EventArgs());
                }
            }
            else//If this is not run then it will throw an argument exception
            {
                Console.WriteLine($"Grade of {grade} was not added must be within 1-100");
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }


        public void AddGrade(char letter)/*----------- Overloaded method ----------*/
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }
        // Return a instance of Statistics object that contains highest, lowest, and average grades
        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            result.Average = 0.0;
            result.HighestGrade = double.MinValue;
            result.LowestGrade = double.MaxValue;
            foreach (var grade in grades)
            {
                // finds the highest number of the two and assign it to result.High 
                result.HighestGrade = Math.Max(grade, result.HighestGrade);
                result.LowestGrade = Math.Min(grade, result.LowestGrade);
                result.Average += grade;
            }


            result.Average /= grades.Count;
            switch (result.Average)
            {
                case var grade when (grade >= 90.0 && grade <= 100):
                    result.LetterGrade = 'A';
                    break;
                case var grade when (grade >= 80.0 && grade < 90.0):
                    result.LetterGrade = 'B';
                    break; 
                case var grade when (grade >= 70 && grade < 80):
                    result.LetterGrade = 'C';
                      break;
                case var grade when (grade >= 60.0 && grade < 70):
                    result.LetterGrade = 'D';
                    break;
                default:
                    result.LetterGrade = 'F';
                    break;
            }
            return result; 


        }


    }
}
