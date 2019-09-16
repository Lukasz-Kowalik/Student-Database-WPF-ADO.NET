using System.Text.RegularExpressions;
using System.Windows;

namespace Database
{
    /// <summary>
    /// Interaction logic for MarkWindow.xaml
    /// </summary>
    public partial class GradeWindow : Window
    {
        private Student _student;

        public GradeWindow(Student s)
        {
            InitializeComponent();
            _student = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (
                (Regex.IsMatch(GradeDisplay.Text, @"^[2-5],[0,5]")||Regex.IsMatch(GradeDisplay.Text, @"^[2-5]"))&& 
                !(Regex.IsMatch(GradeDisplay.Text, @"5,5")||Regex.IsMatch(GradeDisplay.Text, @"\d\d"))
               )
            {
                _student.AddGrad(new Grade(double.Parse(GradeDisplay.Text)));
                this.Close();
            }
            else
            {
                MessageBox.Show("Mark is bettwen 2-6 and after \",\" can have only 0 or 5");
            }
        }
    }
}