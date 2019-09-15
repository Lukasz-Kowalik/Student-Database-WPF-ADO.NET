using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> list { get; set; }

        public MainWindow()
        {
            list = new List<Student>();
            InitializeComponent();
            DG.Columns.Add(new DataGridTextColumn() { Header = "Imie", Binding = new Binding("FirstName") });
            DG.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("SurName") });
            DG.Columns.Add(new DataGridTextColumn() { Header = "NrIneksu", Binding = new Binding("StudentNo") });
            DG.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });
            DG.AutoGenerateColumns = false;

            list = DataBase.SqlStudentSelect();
            DG.ItemsSource = list;
        }

        private void AddSt_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow addSt = new StudentWindow();
            if (addSt.ShowDialog() == true)
            {
                list.Add(addSt.student);
                MessageBox.Show("Dodano osobe");
            }
            DG.Items.Refresh();
        }

        private void RmSt_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem is Student)
            {
                list.Remove((Student)DG.SelectedItem);
            }
            DG.Items.Refresh();
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem is Student)
            {
                Student s = (Student)DG.SelectedItem;
                MarkWindow grade = new MarkWindow(s);
                grade.Show();
            }
        }

        private void ShowGrades_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem is Student)
            {
                Student s = (Student)DG.SelectedItem;
                ShowGrades grades = new ShowGrades(s);
                grades.Show();
            }
        }
    }
}