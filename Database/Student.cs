using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Database
{
    [Serializable]
    public class Student
    {
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Faculty { get; set; }
        public int StudentNo { get; set; }
        private ObservableCollection<Grade> Grades { get; }
   
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
            Grades = new ObservableCollection<Grade>();
        }

        public void AddGrad(Grade m)
        {
            Grades.Add(m);
        }

        public ObservableCollection<Grade> GetGrades()
        {
            return Grades;
        }
    }
}