using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class StudentCompare : IComparable<StudentCompare>
    {
        Student student;
        double grade;

        public StudentCompare(double myGrade, Student myStudent)
        {
            student = myStudent;
            grade = myGrade;
        }

        public int CompareTo(StudentCompare obj)
        {
            StudentCompare student = obj as StudentCompare;
            if (this.grade == student.grade)
            {
                return 0;
            }
            else if (this.grade < student.grade)
            {
                return -1;
            }
            return 1;
        }
    }
}

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            // Make an array of all grades.
            var grades = new (double, Student)[Students.Count];
            int count = 0;
            foreach (Student student in Students)
            {
                grades[count] = (student.AverageGrade, student); 
                count++;
            }

            Array.Sort(grades);
            char[] gradesList = { 'A', 'B', 'C', 'D' };

            for (var i = 1; i < 5; i++)
            {
                // compute respective index.
                var index = (int) Math.Ceiling(Students.Count * 0.2);
                if (averageGrade > grades[index].Item1)
                {
                    return gradesList[index - 1];
                }

            }

            return 'F';
        }
    }
}
