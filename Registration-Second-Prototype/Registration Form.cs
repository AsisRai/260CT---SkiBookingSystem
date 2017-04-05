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

namespace Registration
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCBookingSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                
                if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty || textBox4.Text == String.Empty || textBox5.Text == String.Empty)
                {
                    MessageBox.Show("Error, All Customer details must be filled", "Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string email = textBox3.Text;
                if (email.IndexOf('@') == -1 || email.IndexOf(".") == -1)
                {
                    MessageBox.Show("Error, Please Enter a Valid Email Address", "Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




                else
               {
                    try
                    {
                        Connection.Open();
                         SqlCommand cmd = new SqlCommand(@"INSERT INTO CustomerTable ([firstname], [lastname], [email], [phonenumber], [address], [premember]) VALUES (@firstname, @lastname, @email, @phonenumber, @address, @premember);", Connection);
                        cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                        cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                        cmd.Parameters.AddWithValue("@email", textBox3.Text);
                        cmd.Parameters.AddWithValue("@phonenumber", textBox4.Text);
                        cmd.Parameters.AddWithValue("@address", textBox5.Text);
                        cmd.Parameters.AddWithValue("@premember", checkBox1.Checked);
                        

                        int i = cmd.ExecuteNonQuery();
                        Connection.Close();

                        if (i == 1)
                        {
                            MessageBox.Show("Customer has been registered");
                            getPrimaryKey();

                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                        }
                    else
                        {
                            MessageBox.Show("Customer couldn't be added, Please Try again");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unexpected Error has occured:" + ex.Message);

                    }
                }
            }
        }

        private void getPrimaryKey()
        {
            using (SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCBookingSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT MAX(Id)+1 FROM CustomerTable;", Connection);
                    Connection.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected Error has occured: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)  CheckNumber(string strPhoneNumber)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }



       

       
    }
}

//Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\Asis\Desktop\SBCBookingSystem - Group AJR\Registration\Registration\Registration\bin\Debug\SBCBookingSystem.mdf";Integrated Security = True; Connect Timeout = 30