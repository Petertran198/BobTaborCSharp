using CollectionsNObjects;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsNObjects
{   

    class Program
    {
        static void Main(string[] args)
        {
            /*          
                        Console.WriteLine("Hello World!");
                        Car myCar = new Car();
                        Console.WriteLine($"I have a {myCar.Color} {myCar.Make}");
            */
           
            Car car1 = new Car();
            car1.Color = "Red";
            car1.Make = "Honda";
            // Another way to make an instance all in one line  
            Car car2 = new Car() { Color = "red", Make = "Acura" };


            Book book1 = new Book();
            book1.Author = "Peter Tran";
            book1.ISBN = "123";
            book1.Title = "The Book Named P";


            // Making array with items already included 
            string[] names = { "bob", "mich", "peter" };


            // ArrayLists are dynamically sized,
            // cool features sorting, removing items 
            // Old stylr but the thing with this is that it doesn't restrict data type aka 
            // strongly typed therefore I can add a type of Car and type of Book 
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(car1);
            myArrayList.Add(book1);

            // Generic list 
            // This list is strongly typed aka a collection of the same data type. 
            //When I add a book it throws an exception because book1 is of type Book 
            // It will only allow insertion of Car type 
            List<Car> myCarList = new List<Car>();
            myCarList.Add(car1);
            //myCarList.Add(book1);    ----Error 

            // Collecition Initalizer Example 
            // Making a list and populating it all at once
            List<Car> anotherCarList = new List<Car>()
            {
                new Car {Make = "Pontiac", Color = "Orange"},
                new Car {Make = "Jeep", Color = "blue"},
                new Car {Make = "Mercedes", Color = "Red"}
            };


            // Dictionary aka ruby hashes
            // aka key value
            // You insert in what the data type the key is and what data type the value is 
            Dictionary<string, Book> myBookDictionary = new Dictionary<string, Book>();
            myBookDictionary.Add(book1.ISBN, book1);
            Console.WriteLine(myBookDictionary["123"].Title);

            // Working with Enums examples 
            // I created an Enum because the TodoList status can only be one of a couple of values 
            // This will work perfectly with switches because switches works best when there is a fixed amount of    values a variable can be 
            // Notice how the Status keys are using Enums as the value 
            List<Todo> todoList = new List<Todo>()
            {
                new Todo { Description = "Eating", EstimatedHours = 1, Status = Status.Done},
                new Todo { Description = "Reading", EstimatedHours = 2, Status = Status.InProgress},
                new Todo { Description = "Sleeping", EstimatedHours = 3, Status = Status.NotStarted},
                new Todo { Description = "Swimming", EstimatedHours = 3, Status= Status.OnHold}
            };

            TodosAssessment(todoList);

        }

        private static void TodosAssessment(List<Todo> todos)
        {
            Console.WriteLine("------- Assessment of Todo List --------");
            foreach (Todo todo in todos)
            {
                switch (todo.Status)
                {
                    case Status.Done:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Great Job {todo.Description.ToLower()} has been completed");
                            break;
                    case Status.InProgress:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"You are almost done with {todo.Description.ToLower()}");
                        break;
                    case Status.OnHold:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"hurry it up.. with {todo.Description.ToLower()}");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"Why havent you started on {todo.Description.ToLower()}");
                            break;
                }
            }
        }
    }

}
