using System;

namespace UnderstandingScope
{
    class Program
    {
        private static string test = "hello";
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
            HelperMethod();
        }
        static void HelperMethod()=>Console.WriteLine($"Value of K {test}");

    }
}
