using System.Text.RegularExpressions;
using System.Windows;

namespace Database
{
    /// <summary>
    /// Interaction logic for MarkWindow.xaml
    /// </summary>
    public partial class MarkWindow : Window
    {
        private Student student;

        public MarkWindow(Student s)
        {
            InitializeComponent();
            student = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (
                (Regex.IsMatch(MarkDisplay.Text, @"^[2-5],[0,5]") || Regex.IsMatch(MarkDisplay.Text, @"^[2-6]"))
                && !Regex.IsMatch(MarkDisplay.Text, @"^6,")
                )
            {
                student.AddMark(new Mark(double.Parse(MarkDisplay.Text)));
                this.Close();
            }
            else
            {
                MessageBox.Show("Mark is bettwen 2-6 and after \",\" can have only 0 or 5");
            }
        }
    }
}