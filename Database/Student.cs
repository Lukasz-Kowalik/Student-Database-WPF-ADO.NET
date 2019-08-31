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
        private List<Mark> Marks { get; }

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
            Marks = new List<Mark>();
        }

        public void AddMark(Mark m)
        {
            Marks.Add(m);
        }

        public List<Mark> getMarks()
        {
            return Marks;
        }
    }
}