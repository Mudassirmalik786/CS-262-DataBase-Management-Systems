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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1C2MGM4;Initial Catalog=Lab2_Home;Integrated Security=True");

        private void StudentForm_Load(object sender, EventArgs e)
        {
            GetStudentRecord();
        }
        private void GetStudentRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            DataTable dt = new DataTable();

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            StudentRecordDataGridView.DataSource = dt;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Student VALUES (@RegistrationNumber, @Name, @Department, @Session, @Address)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@RegistrationNumber", txtRNumber.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@Session", txtSession.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New Student's Data successfully saved in the database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentRecord();
                ResetFields();
            }
        }
        private bool isValid()
        {
            if (txtRNumber.Text == String.Empty)
            {
                MessageBox.Show("Registration Number is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Name is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSession.Text == String.Empty)
            {
                MessageBox.Show("Session is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDepartment.Text == String.Empty)
            {
                MessageBox.Show("Department is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (txtAddress.Text == String.Empty)
            {
                MessageBox.Show("Address is not provided", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ResetFields()
        {
            txtRNumber.Clear();
            txtName.Clear();
            txtDepartment.Clear();
            txtSession.Clear();
            txtAddress.Clear();

            txtRNumber.Focus();
        }

        private void buttonResetFields_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void StudentRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRNumber.Text = StudentRecordDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = StudentRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtDepartment.Text = StudentRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtSession.Text = StudentRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtAddress.Text = StudentRecordDataGridView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (txtRNumber.Text != String.Empty)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Student SET RegistrationNumber = @RegistrationNumber, Name = @Name, Department = @Department, Session = @Session, Address = @Address WHERE RegistrationNumber = @RegistrationNumber", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@RegistrationNumber", txtRNumber.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@Session", txtSession.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student Data has been updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentRecord();
                ResetFields();
            }
            else
            {
                MessageBox.Show("Please Select Student Data to update", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (txtRNumber.Text != String.Empty)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE RegistrationNumber = @RegistrationNumber", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@RegistrationNumber", txtRNumber.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student Data has been deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentRecord();
                ResetFields();
            }
            else
            {
                MessageBox.Show("Please Select Student Data to delete", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
