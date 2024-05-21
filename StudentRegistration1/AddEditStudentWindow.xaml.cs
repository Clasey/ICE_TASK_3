using System;
using System.Windows;

namespace StudentRegistrationSystem
{
    public partial class AddEditStudentWindow : Window
    {
        public Student Student { get; private set; }

        public AddEditStudentWindow(Student student = null)
        {
            InitializeComponent();
            if (student != null)
            {
                Student = student;
                txtID.Text = student.ID.ToString();
                txtName.Text = student.Name;
                txtCourse.Text = student.Course;
                dpEnrollmentDate.SelectedDate = student.EnrollmentDate;
            }
            else
            {
                Student = new Student();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                Student.ID = int.Parse(txtID.Text);
                Student.Name = txtName.Text;
                Student.Course = txtCourse.Text;
                Student.EnrollmentDate = dpEnrollmentDate.SelectedDate.Value;
                DialogResult = true;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Please enter a valid numeric ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                MessageBox.Show("Please enter a course.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!dpEnrollmentDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select an enrollment date.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
