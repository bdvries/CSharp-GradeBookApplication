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
            Array.Reverse(grades);

            char[] gradesList = { 'A', 'B', 'C', 'D' };

            for (var i = 0; i < 4; i++)
            {
                // compute respective index.
                var index = (int) Math.Ceiling(Students.Count * 0.2 * i);
                if (averageGrade >= grades[index])
                {
                    return gradesList[i];
                }
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            // Ensure proper computation of the grades.
            if ( Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }
    }
}
