using System;

namespace Database
{
    [Serializable]
    public sealed class Grade
    {
        public double Grades { get; set; }

        public Grade(double grade = 0)
        {
            this.Grades = grade;
        }
    }
}