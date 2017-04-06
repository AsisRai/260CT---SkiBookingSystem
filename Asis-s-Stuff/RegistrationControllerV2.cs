using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Group_AJR___SBC_Booking_System
{
    class Controller
    {
        private TextBox textBox1, textBox2, textBox3, textBox4, textBox5;
        private CheckBox checkBox1;

        public Controller(TextBox textBox1, textBox2, textBox3, textBox4, textBox5, CheckBox checkBox1)
        {
            firstname = textBox1;
            lastname = textBox2;
            email = textBox3;
            Phonenumber = textBox4;
            address = textBox5;
            premember = checkBox1;
           
        }

        public Controller()
        {

        }

        public bool Update()
        {
            Bookingtable type = Factory.getType(b.Checked);
            bool getType = type.type(b.Checked);

            Registration reg = new Registration(int.Parse(firstname.Text.ToString()), int.Parse(lastname.Text.ToString()), int.Parse(email.Text.ToString()), int.Parse(Phonenumber.Text.ToString()), int.Parse(address.Text.ToString()), int.Parse(premember.Text.ToString()), getType);
            bool i = reg.Update();
            return i;
        }

        public bool getRegistration()
        {
            Registration Registration = new Registration();
            bool i = Registration.getRegistration(int.Parse(CustomerID.Text.ToString()));

            if (i)
            {
                firstname.Text = Registration.firstname.ToString();
                lastname.Text = Registration.lastname.ToString();
                email.Text = Registration.email.ToString();
                Phonenumber.Text = Registration.Phonenumber.ToString();
                address.Text = Registration.address.ToString();
                premember = Registration.ToString;
            }
            return i;
        }

        public bool Save()
        {
            Bookingtable type = Factory.getType(b.Checked);
            bool getType = type.type(b.Checked);

            Registration reg = new Registration(int.Parse(firstname.Text.ToString()), int.Parse(lastname.Text.ToString()), int.Parse(email.Text.ToString()), int.Parse(Phonenumber.Text.ToString()), int.Parse(address.Text.ToString()), int.Parse(premember.Text.ToString()), getType);
            bool i = reg.Update();
            return i;
        }

        public bool manualTest()
        {
            Console.WriteLine("----------------BEGINING TEST----------------");
            using (SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE CustomerTable SET firstname=Asis, lastname=Rai, email=asis@gmai.com, Phonenumber=07588259523, address=7 Arliss Way premember=('1'), WHERE Id = 1", Connection);
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        Console.WriteLine("--------UPDATE PASS--------");
                        cmd = new SqlCommand("SELECT Count(*) FROM CustomerTable WHERE Id=18 AND firstname=Asis, lastname=Rai, email=asis@gmai.com, Phonenumber=07588259523, address=7 Arliss Way premember=('1')", Connection);
                        i = (int)cmd.ExecuteScalar();

                        if (i > 0)
                        {
                            Console.WriteLine("--------VERIFY PASS--------");
                            Console.WriteLine("----------------ALL PASS----------------");
                            Connection.Close();
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("--------VERIFY FAIL--------");
                            Connection.Close();
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------UPDATE FAIL--------");
                        Connection.Close();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Connection.Close();
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine("--------UNKNOWN FAIL--------");
                    return false;
                }
            }
        }
    }
}
