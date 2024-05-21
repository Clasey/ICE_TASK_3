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
            Student.ID = int.Parse(txtID.Text);
            Student.Name = txtName.Text;
            Student.Course = txtCourse.Text;
            Student.EnrollmentDate = dpEnrollmentDate.SelectedDate.Value;
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
