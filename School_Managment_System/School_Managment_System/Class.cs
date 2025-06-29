using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace School_Managment_System
{
    public partial class Class : Form
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.con);
        public Class()
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
            int teacher_id = Convert.ToInt32(cobteacher.SelectedValue);
            string query = "INSERT INTO Classes (ClassName,ClassTeacherID) VALUES ('" + name + "','" + teacher_id + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show($"Class {name} is Add");
            LoadData();
        }

        private void Class_Load(object sender, EventArgs e)
        {
            LoadData();

            string query = "SELECT Teacher_ID, Name FROM Teachers";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cobteacher.DataSource = dt;
            cobteacher.DisplayMember = "Name"; // Show in dropdown
            cobteacher.ValueMember = "Teacher_ID";
        }
        public void LoadData()
        {

            string query = "SELECT * FROM Classes";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            con.Close();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
