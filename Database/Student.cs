using System;
using System.Collections.Generic;

namespace Database
{
    [Serializable]
    public class Student
    {
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Faculty { get; set; }
        public int StudentNo { get; set; }
        private List<Grade> Grades { get; }

        public Student()
        {
        }

        public Student(string surName, string firstName,
            int studentNo, string faculty)
        {
            SurName = surName;
            FirstName = firstName;
            Faculty = faculty;
            StudentNo = studentNo;
            Grades = new List<Grade>();
        }

        public void AddGrad(Grade m)
        {
            Grades.Add(m);
        }

        public List<Grade> GetGrades()
        {
            return Grades;
        }
    }
}