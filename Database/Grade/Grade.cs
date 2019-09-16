using System;
using System.Windows.Data;

namespace Database
{
    public sealed class Grade
    {
        public double gradeValue { get;}
        public Grade(double grade)
        {
            gradeValue = grade;
        }
    }
}