using GradeBook.Enums;
using System;

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
            var grades = new double[Students.Count];
            int count = 0;
            foreach (Student student in Students)
            {
                grades[count] = student.AverageGrade; 
                count++;
            }

            Array.Sort(grades);
            char[] gradesList = { 'A', 'B', 'C', 'D' };

            for (var i = 1; i < 5; i++)
            {
                // compute respective index.
                var index = (int) Math.Ceiling(Students.Count * 0.2);
                if (averageGrade > grades[index])
                {
                    return gradesList[i - 1];
                }
            }

            return 'F';
        }
    }
}
