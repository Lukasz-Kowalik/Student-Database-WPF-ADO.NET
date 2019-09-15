using System.Windows;
using System.Windows.Controls;

namespace Database
{
    /// <summary>
    /// Interaction logic for ShowMarks.xaml
    /// </summary>
    public partial class ShowGrades : Window
    {
      //  private Student student;

        public ShowGrades(Student student)
        {
            InitializeComponent();
            dgM.ItemsSource = student.GetGrades();
            dgM.Items.Refresh();
        }
    }
}