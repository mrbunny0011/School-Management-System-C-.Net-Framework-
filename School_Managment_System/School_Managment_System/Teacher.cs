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
    public partial class Teacher : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.con);
        public Teacher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string email = txtemail.Text;
            string depart = txtspecilization.Text;

            string query = "INSERT INTO Teachers (Name,Email,SubjectSpecialization) VALUES ('" + name + "','" + email + "','" + depart + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show($"Teacher {name} is Add");
            LoadData();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {

            string query = "SELECT * FROM Teachers";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            con.Close();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
