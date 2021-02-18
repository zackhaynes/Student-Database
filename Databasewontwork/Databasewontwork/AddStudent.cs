using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databasewontwork
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        //Main Form show
        private void bMain_Click(object sender, EventArgs e)
        {

            firstname_textbox.Text = "";
            lastname_textbox.Text = "";
            textBox_course1.Text = "";
            textBox_course2.Text = "";
            textBox_course3.Text = "";
            textBox_course4.Text = "";
            textBox_course5.Text = "";
            textBox_course6.Text = "";
            textBox_course7.Text = "";
            textBox_course8.Text = "";
            textBox_course9.Text = "";
            textBox_course10.Text = "";


            this.Hide();
            Utilities.student_Performance.Show();
        }

        // Exit application
        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // add new student to database 
        private void bAdd_Student_Click(object sender, EventArgs e)
        {
            // connects to the database
            StudentsDataSet.StudentsRow newstudent = studentsDataSet.Students.NewStudentsRow();


            // error check for empty spaces
            if(String.IsNullOrWhiteSpace(firstname_textbox.Text) || String.IsNullOrWhiteSpace(lastname_textbox.Text))
            {
                MessageBox.Show("Please enter a name");
                return;
            }

            //error check for empty spaces
            if (String.IsNullOrWhiteSpace(textBox_course1.Text) || String.IsNullOrWhiteSpace(textBox_course2.Text) || String.IsNullOrWhiteSpace(textBox_course3.Text)
                || String.IsNullOrWhiteSpace(textBox_course4.Text) || String.IsNullOrWhiteSpace(textBox_course5.Text) || String.IsNullOrWhiteSpace(textBox_course6.Text)
                || String.IsNullOrWhiteSpace(textBox_course7.Text) || String.IsNullOrWhiteSpace(textBox_course8.Text) || String.IsNullOrWhiteSpace(textBox_course9.Text)
                ||  String.IsNullOrWhiteSpace(textBox_course10.Text))
            {
                MessageBox.Show("Please make sure all courses have been filled");
                return;
            }

            // error check for numbers more than 100
            else if (Int32.Parse(textBox_course1.Text) > 100 || Int32.Parse(textBox_course2.Text) > 100 || Int32.Parse(textBox_course3.Text) > 100 ||
                Int32.Parse(textBox_course4.Text) > 100 || Int32.Parse(textBox_course5.Text) > 100 || Int32.Parse(textBox_course6.Text) > 100 ||
                Int32.Parse(textBox_course7.Text) > 100 || Int32.Parse(textBox_course8.Text) > 100 || Int32.Parse(textBox_course9.Text) > 100 || Int32.Parse(textBox_course10.Text) > 100)
            {
                MessageBox.Show("Course marks cannot exceed 100");
            }

            // no errors adds all textbox info into 'newstudent'
            else
            {
                newstudent.ID = studentsDataSet.Students.Rows.Count + 1;
                newstudent.Firstname = firstname_textbox.Text;
                newstudent.Lastname = lastname_textbox.Text;
                newstudent.Course1 = Int32.Parse(textBox_course1.Text);
                newstudent.Course2 = Int32.Parse(textBox_course2.Text);
                newstudent.Course3 = Int32.Parse(textBox_course3.Text);
                newstudent.Course4 = Int32.Parse(textBox_course4.Text);
                newstudent.Course5 = Int32.Parse(textBox_course5.Text);
                newstudent.Course6 = Int32.Parse(textBox_course6.Text);
                newstudent.Course7 = Int32.Parse(textBox_course7.Text);
                newstudent.Course8 = Int32.Parse(textBox_course8.Text);
                newstudent.Course9 = Int32.Parse(textBox_course9.Text);
                newstudent.Course10 = Int32.Parse(textBox_course10.Text);

                // adds 'newstudent' to the database
                studentsDataSet.Students.Rows.Add(newstudent);
                studentsTableAdapter.Update(studentsDataSet.Students);
               
                
                MessageBox.Show("Your new student ID is " + newstudent.ID);


                // clears the textboxes
                firstname_textbox.Text = "";
                lastname_textbox.Text = "";
                textBox_course1.Text = "";
                textBox_course2.Text = "";
                textBox_course3.Text = "";
                textBox_course4.Text = "";
                textBox_course5.Text = "";
                textBox_course6.Text = "";
                textBox_course7.Text = "";
                textBox_course8.Text = "";
                textBox_course9.Text = "";
                textBox_course10.Text = "";
            }
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentsDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.studentsDataSet.Students);

        }
        // numbers only event keypress for no errors
        private void textBox_course1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
