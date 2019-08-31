using System.Text.RegularExpressions;
using System.Windows;

namespace Database
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student student;

        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if (student != null)
            {
                tbFirstName.Text = student.FirstName;
                tbSurName.Text = student.SurName;
                tbStudentNo.Text = student.StudentNo.ToString();
                tbFaculty.Text = student.Faculty;
            }
            this.student = student ?? new Student();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbFirstName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbSurName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbFaculty.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbStudentNo.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Incorrect data!");
                return;
            }
            student.FirstName = tbFirstName.Text;
            student.SurName = tbSurName.Text;
            student.StudentNo = int.Parse(tbStudentNo.Text);
            student.Faculty = tbFaculty.Text;
            this.DialogResult = true;
        }

    }
}