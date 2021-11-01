using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DP_Assignment_2
{
    
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-L2N1SKT;Initial Catalog=StudentForm;Persist Security Info=True;User ID=sri;Password=123456;Pooling=False");
        public Form1()
        {
            InitializeComponent();
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Clear();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Username!");
            }
            if (this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Password!");
            }
            if (this.textBox1.Text.Length == 0 || this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Username and Password!");
            }
            String un = textBox1.Text.ToString();
            String pw = textBox1.Text.ToString();
            con.Open();
            String sqlqry = "select Username,Passwords from StudentRegistrationForm1 where Username='" + un + "' and Passwords='" + pw + "'";
            SqlDataAdapter sqlsda = new SqlDataAdapter(sqlqry, con);
            DataTable sqldt = new DataTable();
            sqlsda.Fill(sqldt);

            if (sqldt.Rows.Count == 1) { 
            
                MessageBox.Show("Welcome User!"+un);
            }
            else 
            { 
                MessageBox.Show("Invalid User!"+un);
            }
            con.Close();
            button2_Click(sender,e);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentRegistration reg = new StudentRegistration();
            reg.Show();
        }
    }
}
