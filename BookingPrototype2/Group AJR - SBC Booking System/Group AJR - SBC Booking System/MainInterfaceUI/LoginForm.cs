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


namespace Group_AJR___SBC_Booking_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textUsername.KeyPress += new KeyPressEventHandler(CheckEnter);
            textPassword.KeyPress += new KeyPressEventHandler(CheckEnter);
        }


        private void loginbutton_Click(object sender, EventArgs e)
        {
            using (SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                if (textUsername.Text == String.Empty)
                {
                    MessageBox.Show("Please enter user name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textUsername.Focus();
                }

                else if (textPassword.Text == String.Empty)
                {
                    MessageBox.Show("Please enter password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textPassword.Focus();
                }

                else
                {
                    try
                    {
                        Connection.Open();
                        SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM Staff WHERE username=@uname and password=@pass", Connection);
                        cmd.Parameters.AddWithValue("@uname", textUsername.Text);
                        cmd.Parameters.AddWithValue("@pass", textPassword.Text);
                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MainUIform main = new MainUIform();
                            main.Show();
                            this.Hide();
                            Connection.Close();
                        }
                        else
                        {   
                            MessageBox.Show("Incorrect login, please try again");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Unexpected error:" + ex.Message);
                    }
                }
            }
        }
        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginbutton_Click(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:" + ex.Message);
            }
        }
    }
}

