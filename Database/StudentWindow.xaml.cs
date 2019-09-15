using System.Text.RegularExpressions;
using System.Windows;

namespace Database
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student Student { get; }

        public StudentWindow()
        {
            InitializeComponent();
            this.Student = new Student();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbFirstName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbSurName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbFaculty.Text, @"^\p{Lu}{1,12}$") ||
                !Regex.IsMatch(tbStudentNo.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Incorrect data!");
                return;
            }
            Student.FirstName = tbFirstName.Text;
            Student.SurName = tbSurName.Text;
            Student.StudentNo = int.Parse(tbStudentNo.Text);
            Student.Faculty = tbFaculty.Text;
            this.DialogResult = true;
        }

    }
}