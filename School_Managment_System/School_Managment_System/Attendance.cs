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

using System.Data.SqlClient;
using System.Xml.Linq;

namespace School_Managment_System
{
    public partial class Attendance : Form
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.con);
        public Attendance()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        private void Attendance_Load(object sender, EventArgs e)
        {
            LoadData();
            string query2 = "SELECT ClassID, ClassName FROM Classes";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            cobclass.DataSource = dt2;
            cobclass.DisplayMember = "ClassName"; // Show in dropdown
            cobclass.ValueMember = "ClassID";

            cobclass.SelectedIndexChanged += cobclass_SelectedIndexChanged;
        }
        public void LoadData()
        {

            string query = "SELECT * FROM Attendance";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            con.Close();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void Sub_category(int class_id)
        {
            string query = "SELECT Student_ID, Name FROM Student WHERE ClassID = '"+class_id+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cobstudent.DataSource = dt;
            cobstudent.DisplayMember = "Name";
            cobstudent.ValueMember = "Student_ID";
        }
        private void cobclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobclass.SelectedValue != null)
            {
                int class_id;
                if (int.TryParse(cobclass.SelectedValue.ToString(), out class_id))
                {
                    Sub_category(class_id);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            string status = cobstatus.Text;
            int student_id = Convert.ToInt32(cobstudent.SelectedValue);
            int class_id = Convert.ToInt32(cobclass.SelectedValue);
            string query = "INSERT INTO Attendance (StudentID,Date,Status,ClassID) VALUES ('" + student_id + "','" + date + "','" + status + "','"+ class_id + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show($"Attandance {student_id} is Add");
            LoadData();

        }
    }
}
