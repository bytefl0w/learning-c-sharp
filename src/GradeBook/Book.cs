using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    // interface contains no implementation details, only describing the available members on a specific type
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var openFile = File.AppendText($"{Name}.txt"))
            {
                openFile.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    // The relationship below would be "Book IS a NamedObject"
    public class InMemoryBook : Book// internal modifier (given by default) = this class can only be used in this project
    {
        // Access modifiers (Public, Private)
        // "this" = implicit variable
        // ": base()", accessing the constructor in the base class
        public InMemoryBook(string name) : base(name)
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

        public override void AddGrade(double grade)
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

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (int i = 0; i < grades.Count; i++)
            {
                result.Add(grades[i]);
            }

            return result;
        }

        private List<double> grades;

        // public string Name
        // {
        //     get;
        //     set; // No class outside of this one has the ability to set this var
        // }

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