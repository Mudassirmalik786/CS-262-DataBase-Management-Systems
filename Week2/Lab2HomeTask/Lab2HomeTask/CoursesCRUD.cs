using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2HomeTask
{
    public partial class CoursesCRUD : Form
    {
        public CoursesCRUD()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1C2MGM4;Initial Catalog=Lab2_Home;Integrated Security=True");

        private void CoursesCRUD_Load(object sender, EventArgs e)
        {
            GetCourseRecord();
        }
        private void GetCourseRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from Course", con);
            DataTable dt = new DataTable();

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            CourseRecordDataGridView.DataSource = dt;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Course VALUES (@Course_ID, @Course_Name, @Student_Name, @Teacher_Name, @Semester)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Course_ID", txtCourseID.Text);
                cmd.Parameters.AddWithValue("@Course_Name", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@Student_Name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@Teacher_Name", txtTeacherName.Text);
                cmd.Parameters.AddWithValue("@Semester", txtSemester.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New Course Data successfully saved in the database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCourseRecord();
                ResetFields();
            }
        }
        private bool isValid()
        {
            if (txtCourseID.Text == String.Empty)
            {
                MessageBox.Show("Course ID is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCourseName.Text == String.Empty)
            {
                MessageBox.Show("Course Name is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtStudentName.Text == String.Empty)
            {
                MessageBox.Show("Student Name is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTeacherName.Text == String.Empty)
            {
                MessageBox.Show("Teacher Name is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSemester.Text == String.Empty)
            {
                MessageBox.Show("Semester is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void ResetFields()
        {
            txtCourseID.Clear();
            txtCourseName.Clear();
            txtStudentName.Clear();
            txtTeacherName.Clear();
            txtSemester.Clear();

            txtCourseID.Focus();
        }

        private void CourseRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCourseID.Text = CourseRecordDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            txtCourseName.Text = CourseRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtStudentName.Text = CourseRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtTeacherName.Text = CourseRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtSemester.Text = CourseRecordDataGridView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void buttonResetFields_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (txtCourseID.Text != String.Empty)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Course SET Course_ID = @Course_ID, Course_Name = @Course_Name, Student_Name = @Student_Name, Teacher_Name = @Teacher_Name, Semester = @Semester WHERE Course_ID = @Course_ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Course_ID", txtCourseID.Text);
                cmd.Parameters.AddWithValue("@Course_Name", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@Student_Name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@Teacher_Name", txtTeacherName.Text);
                cmd.Parameters.AddWithValue("@Semester", txtSemester.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Course Data successfully updated in the database", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCourseRecord();
                ResetFields();
            }
            else
            {
                MessageBox.Show("Please Select Course Data to update", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (txtCourseID.Text != String.Empty)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Course WHERE Course_ID = @Course_ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Course_ID", txtCourseID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Course Data has been deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCourseRecord();
                ResetFields();
            }
            else
            {
                MessageBox.Show("Please Select Course Data to delete", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
