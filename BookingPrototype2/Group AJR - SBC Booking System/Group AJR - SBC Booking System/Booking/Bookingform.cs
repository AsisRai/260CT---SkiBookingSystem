using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Group_AJR___SBC_Booking_System.Booking
{
    public partial class Bookingform : Form
    {
        int memtype;
        bool isreg = false; //set to false will change if user is in the system.
        SqlConnection con; //connection
        //string connectionString;

        public Bookingform()
        {
            InitializeComponent();
            //connectionString = connectionString = ConfigurationManager.ConnectionStrings["@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDBFilename =| DataDirectory |\SBCDatabaseV2.mdf; Integrated Security = True; Connect Timeout = 30""].ConnectionString;
        }

        private void checkId_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand checkid = new SqlCommand();
            checkid.CommandText = "select * from [CustomerTable]";
            checkid.Connection = con;

            SqlDataReader rd = checkid.ExecuteReader();

            while (rd.Read())
            {
                memcheck.Text = "............................";
                if (rd[0].ToString() == idBox.Text) //the zero here is calling to the id col
                { //here we are saying that if rd var is == to the value user input is a match then isreg before true.
                    isreg = true;
                    //we then print it out to the label.
                }
                if (isreg == true)
                {
                    if (rd[6].ToString() == "0")
                    {
                        memcheck.Text = "Member: £20";
                        memtype = 2;

                    }
                    else if (rd[6].ToString() == "1")
                    {
                        memcheck.Text = "Premium Member: £15";
                        memtype = 1;

                    }
                    else
                    {
                        memcheck.Text = "Non-Member: £25";
                        memtype = 3;

                    }
                }
                //code to ask for the correct price from the user so no mistakes are made
            }
            if (isreg == true)
            {
                cusidBox.Text = idBox.Text;
                idLabel.Text = "Customer is registerd";
            }
            else
            {
                idLabel.Text = "Customer is not registered";
            }


            isreg = false;
            con.Close();

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter checkup = new SqlDataAdapter("SELECT * FROM [CustomerTable] WHERE CustomerId ='" + idBox.Text + "'", con); //this will get all the data
            DataTable sd = new DataTable();

            checkup.Fill(sd);
            dataGridView2.DataSource = sd;
        }

        private void checkEmail_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand checkEmail = new SqlCommand();
            checkEmail.CommandText = "select * from [CustomerTable]";
            checkEmail.Connection = con;

            SqlDataReader rd = checkEmail.ExecuteReader();

            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"; //check for invalid inputs
            RegexStringValidator myRegexValidator = new RegexStringValidator(pattern);

            try
            {
                myRegexValidator.Validate(emailBox.Text); //checking what has been typed and if it matches the pattern. 

            }
            catch (Exception)
            {
                MessageBox.Show("Email is invalid");

            }

            while (rd.Read())
            {
                if (rd[3].ToString() == emailBox.Text) //the 3 here is calling to the Email column
                { //here we are saying that if rd var is == to the value user input is a match then isreg before true.
                    isreg = true;
                    //now we print it out to the label.
                }
                if (isreg == true)
                {
                    if (rd[6].ToString() == "0")
                    {
                        memcheck.Text = "Member: £20";
                        memtype = 2;
                    }
                    else if (rd[6].ToString() == "1")
                    {
                        memcheck.Text = "Premium Member: £15";
                        memtype = 1;

                    }
                    else
                    {
                        memcheck.Text = "Non-Member: £25";
                        memtype = 3;

                    }
                }
                //code to ask for the correct price from the user so there are no mistakes made from the user

            }
            if (isreg == true)
            {
                emailLabel.Text = "Customer is registerd";
            }
            else
            {
                emailLabel.Text = "Customer is not registered";
            }

            //isreg = false;
            con.Close();
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter checkup = new SqlDataAdapter("SELECT * FROM [CustomerTable] WHERE email ='" + emailBox.Text + "'", con); //this will get all the data where email matches
            DataTable sd = new DataTable();

            checkup.Fill(sd);
            dataGridView2.DataSource = sd;
            con.Close();


        }


        private void Bookingform_Load(object sender, EventArgs e)
        {
            

        }

        private void search_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sdf = new SqlDataAdapter("SELECT * FROM [Session] WHERE date ='" + dateTimePicker1.Value.ToLongDateString() + "' AND limit < 30", con);
            DataTable sd = new DataTable(); //datagridviewer will be filled with data of sessions available on the day which has less than 30 people booked onit.

            sdf.Fill(sd);
            dataGridView1.DataSource = sd;
            con.Close();

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter staffcheck = new SqlDataAdapter("SELECT * FROM [staffschedule] WHERE date ='" + dateTimePicker1.Value.ToLongDateString() + "' AND booked =  0", con); //this will get all the data where email matches
            DataTable staffdata = new DataTable(); //datagridviewer will be filled with with staff members who are not booked on the day the customer wants one.

            staffcheck.Fill(staffdata);
            dataGridView3.DataSource = staffdata;
            con.Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //factory booking = new factory(int.Parse(cusidBox.Text.ToString()), int.Parse(sessionBox.Text.ToString()), int.Parse(staffschBox.Text.ToString()), Convert.ToDateTime(dateTimePicker1.Text), memtype);
           // booking.factoryset();

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30"); //create a new sql connection

            if (cusidBox.Text == String.Empty ||
                    sessionBox.Text == String.Empty || dateTimePicker1.Text == String.Empty) //this code here will check if the all the values have been entered
            {
                MessageBox.Show("Error, missing values", "Please Complete Form", MessageBoxButtons.OK, MessageBoxIcon.Error); //show the error if they are not.
            }
            
            else
            {
                try
                {
                  

                    
                    con.Open(); // open sql connection 
                    SqlCommand limit_increment = new SqlCommand("UPDATE Session set limit = limit + 1 WHERE id ='" + this.sessionBox.Text + "';", con);
                    int incremnt_check = limit_increment.ExecuteNonQuery();
                    if (incremnt_check != 1)
                    {
                        MessageBox.Show("Failed to increment Session limit"); //simple error checks

                    }
                    con.Close();  //this will incrment the limit com in session tables everytime user enters 
                             
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Bookingtable (staffschedule, customerID, cost, sessionID) VALUES (@staffschedule, @customerID, @cost, @sessionID)", con);
                    cmd2.Parameters.AddWithValue("@staffschedule", staffschBox.Text);
                    cmd2.Parameters.AddWithValue("@customerID", cusidBox.Text);
                    cmd2.Parameters.AddWithValue("@cost", typepayment.Text);
                    cmd2.Parameters.AddWithValue("@sessionID", sessionBox.Text);
                    int b = cmd2.ExecuteNonQuery();
                    
                    if (b == 1)
                    {
                        MessageBox.Show("Booking has been made: "); //simple error checks

                    }
                    else
                    {
                        MessageBox.Show("Booking couldn't be made, Please try again");
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error:" + ex.Message);
                }
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainUIform main = new MainUIform();
            main.Show();
        }

        int a, b, c;

        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            a = e.RowIndex; //needs to know the row that has been clicked
            DataGridViewRow row = dataGridView2.Rows[a];
            cusidBox.Text = row.Cells[0].Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AvLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            b = e.RowIndex; //needs to know the row that has been clicked
            DataGridViewRow row = dataGridView1.Rows[b];
            sessionBox.Text = row.Cells[0].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            c = e.RowIndex; //needs to know the row that has been clicked
            DataGridViewRow row = dataGridView3.Rows[c];
            staffschBox.Text = row.Cells[0].Value.ToString();
        }

    }
}













