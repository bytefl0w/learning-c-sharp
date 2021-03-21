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
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally // Get for making sure you need, ex: close a network socket, close a file, or properlly clean things up
                {
                    Console.WriteLine("***");
                }
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