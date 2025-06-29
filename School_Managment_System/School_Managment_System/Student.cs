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
    public partial class Student : Form
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.con);
        public Student()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            LoadData();
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

            string query = "SELECT * FROM Student";
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
            string roll = txtrollno.Text;
            string email = txtemail.Text;
            string gender = txtgender.Text;
            string phone = txtphone.Text;
            string address = txtaddress.Text;
            int class_id = Convert.ToInt32(cobclass.SelectedValue);
            string query = "INSERT INTO Student (Name,Roll_Number,Email,Gender,Phone,Address,ClassID) VALUES ('" + name + "','" + roll + "','" + email + "','"+gender+"','"+phone+"','"+address+"','"+class_id+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show($"Student {name} is Add");
            LoadData();
        }
    }
}
