using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Erik's Grade Book");
            Console.WriteLine("Enter a grade or 'q' to quit:");
            var input = Console.ReadLine();
            while (input != "q")
            {
                book.AddGrade(double.Parse(input));
                input = Console.ReadLine();
            }

            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            // book.AddGrade(55.2);
            var stats = book.GetStatistics();

            Console.WriteLine($"High Grade: {stats.High}");
            Console.WriteLine($"Low Grade: {stats.Low}");
            Console.WriteLine($"Average Grade: {stats.Average}");
            Console.WriteLine($"Letter Grade: {stats.Letter}");
        }
    }
}