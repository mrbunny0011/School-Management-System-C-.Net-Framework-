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
    public partial class checkFee : Form
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.con);
        public checkFee()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();   
            form.Show();
            this.Hide();
        }

        private void checkFee_Load(object sender, EventArgs e)
        {
            
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

            string query = "SELECT * FROM Fees";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            con.Close();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void Sub_category(int class_id)
        {
            string query = "SELECT Student_ID, Name FROM Student WHERE ClassID = '" + class_id + "'";
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

            int student_id = Convert.ToInt32(cobstudent.SelectedValue);
            string Query = "Select * from Fees Where StudentID = '" + student_id + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource= dt;
        }
    }
}
