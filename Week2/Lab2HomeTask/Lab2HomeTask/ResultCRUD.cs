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
    public partial class ResultCRUD : Form
    {
        public ResultCRUD()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1C2MGM4;Initial Catalog=Lab2_Home;Integrated Security=True");

        private void StudentRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ResultCRUD_Load(object sender, EventArgs e)
        {
            GetResultRecord();
        }

        private void GetResultRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from Result", con);
            DataTable dt = new DataTable();

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            ResultRecordDataGridView.DataSource = dt;
        }

        

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Result VALUES (@Student_ID, @Student_Name, @Course_Name, @Marks, @Grade, @Section, @Session, @Semester)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Student_ID", txtStudentID.Text);
                cmd.Parameters.AddWithValue("@Student_Name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@Course_Name", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@Marks", txtMarks.Text);
                cmd.Parameters.AddWithValue("@Grade", txtGrade.Text);
                cmd.Parameters.AddWithValue("@Section", txtSection.Text);
                cmd.Parameters.AddWithValue("@Semester", txtSemester.Text);
                cmd.Parameters.AddWithValue("@Session", txtSession.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New Student's Data successfully saved in the database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetResultRecord();
                ResetFields();
            }
        }

        private bool isValid()
        {
            if (txtStudentID.Text == String.Empty)
            {
                MessageBox.Show("Student ID is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtStudentName.Text == String.Empty)
            {
                MessageBox.Show("Student Name is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCourseName.Text == String.Empty)
            {
                MessageBox.Show("Course Name is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMarks.Text == String.Empty)
            {
                MessageBox.Show("Marks is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtGrade.Text == String.Empty)
            {
                MessageBox.Show("Grade is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSection.Text == String.Empty)
            {
                MessageBox.Show("Section is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSession.Text == String.Empty)
            {
                MessageBox.Show("Session is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtStudentID.Clear();
            txtStudentName.Clear();
            txtCourseName.Clear();
            txtMarks.Clear();
            txtGrade.Clear();
            txtSection.Clear();
            txtSession.Clear();
            txtSemester.Clear();

            txtStudentID.Focus();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text != String.Empty)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Result SET Student_ID = @Student_ID, Student_Name = @Student_Name, Course_Name = @Course_Name, Marks = @Marks, Grade = @Grade, Session = @Session, Section = @Section, Semester = @Semester WHERE Student_ID = @Student_ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Student_ID", txtStudentID.Text);
                cmd.Parameters.AddWithValue("@Student_Name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@Course_Name", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@Marks", txtMarks.Text);
                cmd.Parameters.AddWithValue("@Grade", txtGrade.Text);
                cmd.Parameters.AddWithValue("@Section", txtSection.Text);
                cmd.Parameters.AddWithValue("@Semester", txtSemester.Text);
                cmd.Parameters.AddWithValue("@Session", txtSession.Text);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Result of Student updated successfully in the database", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetResultRecord();
                ResetFields();
            }
            else
            {
                MessageBox.Show("Please Select Result Data to update", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text != String.Empty)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Result WHERE Student_ID = @Student_ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Student_ID", txtStudentID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student's Result Data has been deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetResultRecord();
                ResetFields();
            }
            else
            {
                MessageBox.Show("Please Select Result Data to delete", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonResetFields_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResultRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudentID.Text = ResultRecordDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            txtStudentName.Text = ResultRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtCourseName.Text = ResultRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtMarks.Text = ResultRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtGrade.Text = ResultRecordDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            txtSection.Text = ResultRecordDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            txtSemester.Text = ResultRecordDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            txtSession.Text = ResultRecordDataGridView.SelectedRows[0].Cells[7].Value.ToString();
        }
    }
}
