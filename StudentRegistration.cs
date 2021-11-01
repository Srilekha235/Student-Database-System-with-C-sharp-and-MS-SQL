using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DP_Assignment_2
{
    public partial class StudentRegistration : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-L2N1SKT;Initial Catalog=StudentForm;Persist Security Info=True;User ID=sri;Password=123456;Pooling=False");
        public StudentRegistration()
        {
            InitializeComponent();
            //show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Clear();
            this.textBox3.Text = "";
            this.textBox4.Clear();
            this.textBox5.Text = "";
            this.comboBox1.SelectedIndex = -1;
            this.textBox6.Clear();
            this.textBox8.Text = "";
            this.textBox7.Clear();
            this.textBox9.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 log = new Form1();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String FirstName = textBox2.Text;
                String LastName = textBox3.Text;
                String Addresss = textBox1.Text;
                String Email = textBox4.Text;
                long Mobile = Int64.Parse(textBox5.Text);
                String Course = comboBox1.SelectedItem.ToString();
                long Years = Int64.Parse(textBox8.Text);
                String Nationality = textBox6.Text;
                String Username = textBox7.Text;
                String Passwords = textBox9.Text;
                con.Open();
                String sqlqry = "insert into StudentRegistrationForm1(FirstName,LastName,Addresss,Email,Mobile,Course,Years,Nationality,Username,Passwords) values ('"+ FirstName + "', '" + LastName + "', '" + Addresss + "', '" + Email + "', " + Mobile + ", '" + Course + "', " + Years + ", '" + Nationality + "', '" + Username + "', '" + Passwords + "')";
                SqlCommand scmd = new SqlCommand(sqlqry,con);
                int j=scmd.ExecuteNonQuery();
                if(j>=1)
                    MessageBox.Show(j + " Registered Users. Welcome : "+ Username);
                else
                    MessageBox.Show(j + " Registration Failed for " + Username);
                con.Close();
                button2_Click(sender, e);
                show();

            }
            catch(System.Exception exp)
            {
                MessageBox.Show("Error Occured!"+exp.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String FirstName = textBox2.Text;
                String LastName = textBox3.Text;
                String Addresss = textBox1.Text;
                String Email = textBox4.Text;
                long Mobile = Int64.Parse(textBox5.Text);
                String Course = comboBox1.SelectedItem.ToString();
                long Years = Int64.Parse(textBox8.Text);
                String Nationality = textBox6.Text;
                String Username = textBox7.Text;
                String Passwords = textBox9.Text;
                con.Open();
                String sqlqry = "update StudentRegistrationForm1 set LastName='" + LastName + "', Addresss='" + Addresss + "', Email='" + Email + "', Mobile=" + Mobile + ", Course='" + Course + "', Years=" + Years + ", Nationality='" + Nationality + "', Username='" + Username + "', Passwords='" + Passwords + "' where FirstName='" + FirstName + "'";
                SqlCommand scmd = new SqlCommand(sqlqry, con);
                int j = scmd.ExecuteNonQuery();
                if (j >= 1)
                    MessageBox.Show(j + " Record Updated Successfully : " + Username);
                else
                    MessageBox.Show(j + " Updation Failed for " + Username);
                con.Close();
                button2_Click(sender, e);
                show();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error Occured!" + exp.ToString());
            }
        }


        void show()
        {
            SqlDataAdapter sqlsda = new SqlDataAdapter("select * from StudentRegistrationForm1", con);
            DataTable sqldt = new DataTable();
            sqlsda.Fill(sqldt);
            dataGridView1.Rows.Clear();
            foreach (DataRow sqldr in sqldt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = sqldr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = sqldr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = sqldr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = sqldr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = sqldr[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = sqldr[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = sqldr[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = sqldr[7].ToString();
                dataGridView1.Rows[n].Cells[8].Value = sqldr[8].ToString();
                dataGridView1.Rows[n].Cells[9].Value = sqldr[9].ToString();

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String FirstName = textBox2.Text;
                con.Open();
                String sqlqry = "delete from StudentRegistrationForm1 where FirstName='" + FirstName + "'";
                SqlCommand scmd = new SqlCommand(sqlqry, con);
                int j = scmd.ExecuteNonQuery();
                if (j >= 1)
                    MessageBox.Show(j + " Record Deleted Successfully : " + Username);
                else
                    MessageBox.Show(j + " Deletion Failed for " + Username);
                con.Close();
                button2_Click(sender, e);
                show();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error Occured!" + exp.ToString());
            }
        }
    }
}
