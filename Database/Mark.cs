using System;

namespace Database
{
    [Serializable]
    public sealed class Mark
    {
        public double Grades { get; set; }

        public Mark(double mark = 0)
        {
            this.Grades = mark;
        }
    }
}