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
    public partial class Fees : Form
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.con);
        public Fees()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Fees_Load(object sender, EventArgs e)
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


        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();  
            form1.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime paid_date = dateTimePicker2.Value.Date;
            string status = cobstatus.Text;
            int student_id = Convert.ToInt32(cobstudent.SelectedValue);
            int class_id = Convert.ToInt32(cobclass.SelectedValue);
            string amount = txtamount.Text;

            string query = "INSERT INTO Fees (StudentID,Amount,PaymentDate,Status,ClassID) VALUES ('" + student_id + "','" + amount + "','" + paid_date + "','"+ status + "','" + class_id + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show($"Fee {student_id} is Add");
            LoadData();
        }
    }
}
