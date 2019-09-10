using System.Windows;
using System.Windows.Controls;

namespace Database
{
    /// <summary>
    /// Interaction logic for ShowMarks.xaml
    /// </summary>
    public partial class ShowGrades : Window
    {
        private Student student;

        public ShowGrades(Student student)
        {
            InitializeComponent();

            this.student = student ?? new Student();

            foreach (var s in student.GetGrades())
            {
                dgM.Items.Add(s);
            }
        }

        private void DgM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Close();
        }
    }
}