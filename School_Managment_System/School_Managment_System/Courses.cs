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

namespace School_Managment_System
{
    public partial class Courses : Form
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.con);
        public Courses()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Courses_Load(object sender, EventArgs e)
        {
            LoadData();

            string query = "SELECT Teacher_ID, Name FROM Teachers";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cobteacher.DataSource = dt;
            cobteacher.DisplayMember = "Name"; // Show in dropdown
            cobteacher.ValueMember = "Teacher_ID";
//Class
            string query2 = "SELECT ClassID, ClassName FROM Classes";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            cobclass.DataSource = dt2;
            cobclass.DisplayMember = "ClassName"; // Show in dropdown
            cobclass.ValueMember = "ClassID";
        }
        public void LoadData()
        {

            string query = "SELECT * FROM Course";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            con.Close();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            int teacher_id = Convert.ToInt32(cobteacher.SelectedValue);
            int class_id = Convert.ToInt32(cobclass.SelectedValue);
            string query = "INSERT INTO Course (Course_Name,Teacher_ID,ClassID) VALUES ('" + name + "','" + teacher_id + "','"+class_id+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show($"Course {name} is Add");
            LoadData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
