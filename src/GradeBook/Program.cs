using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Erik's Grade Book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            // book.AddGrade(55.2);
            var stats = book.GetStatistics();

            Console.WriteLine($"Book name: {book.Name}");
            Console.WriteLine($"High Grade: {stats.High}");
            Console.WriteLine($"Low Grade: {stats.Low}");
            Console.WriteLine($"Average Grade: {stats.Average}");
            Console.WriteLine($"Letter Grade: {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
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
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}