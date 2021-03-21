using System;
using System.Collections.Generic;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book // internal modifier (given by default) = this class can only be used in this project
    {
        // Access modifiers (Public, Private)
        // "this" = implicit variable
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
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

                default:
                    AddGrade(0);
                    break;

            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            //foreach (var grade in grades)
            //var i = 0;
            //while (i < grades.Count)
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] == 42.1)
                {
                    continue;
                }

                result.High = Math.Max(grades[i], result.High);
                result.Low = Math.Min(grades[i], result.Low);
                result.Average += grades[i];
                //i += 1;
            } //while (i < grades.Count);
            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        private List<double> grades;

        public string Name
        {
            get;
            set; // No class outside of this one has the ability to set this var
        }

        // readonly string category = "Science"; // Can only be set in constructor or when inited
        public const string CATEGORY = "Science"; // Can only be set when inited
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         if (String.IsNullOrEmpty(value))
        //         {
        //             name = value; // value is the incoming value
        //         }
        //     }
        // }

        // private string name;
    }
}