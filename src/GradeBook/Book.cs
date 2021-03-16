using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        // Access modifiers (Public, Private)
        // "this" = implicit variable
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }
            result /= grades.Count;
            Console.WriteLine($"High Grade: {highGrade:N1}\nLow Grade: {lowGrade:N1}\nAverage Grade: {result:N1}");
        }

        private List<double> grades;
        private string name;
    }
}