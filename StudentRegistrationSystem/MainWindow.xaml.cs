using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentRegistrationSystem
{
    public partial class MainWindow : Window
    {
        private List<Student> students;

        public MainWindow()
        {
            InitializeComponent();
            students = new List<Student>();
            dgStudents.ItemsSource = students;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addStudentWindow = new AddEditStudentWindow();
            if (addStudentWindow.ShowDialog() == true)
            {
                students.Add(addStudentWindow.Student);
                dgStudents.Items.Refresh();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudents.SelectedItem is Student selectedStudent)
            {
                var editStudentWindow = new AddEditStudentWindow(selectedStudent);
                if (editStudentWindow.ShowDialog() == true)
                {
                    int index = students.IndexOf(selectedStudent);
                    students[index] = editStudentWindow.Student;
                    dgStudents.Items.Refresh();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudents.SelectedItem is Student selectedStudent)
            {
                students.Remove(selectedStudent);
                dgStudents.Items.Refresh();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = txtSearch.Text.ToLower();
            var filteredStudents = students.Where(s =>
                s.Name.ToLower().Contains(query) ||
                s.ID.ToString().Contains(query) ||
                s.Course.ToLower().Contains(query)).ToList();
            dgStudents.ItemsSource = filteredStudents;
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    dgStudents.ItemsSource = students.OrderBy(s => s.Name).ToList();
                    break;
                case 1:
                    dgStudents.ItemsSource = students.OrderBy(s => s.ID).ToList();
                    break;
                case 2:
                    dgStudents.ItemsSource = students.OrderBy(s => s.Course).ToList();
                    break;
            }
        }
    }
}
