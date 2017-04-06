using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Group_AJR___SBC_Booking_System
{
    class Controller
    {
        private TextBox sessionID, staffID;
        private ComboBox Slope, StartTime, EndTime;
        private DateTimePicker date;

        public Controller(TextBox sesID, TextBox staID, ComboBox s, DateTimePicker d, ComboBox start, ComboBox end, CheckBox t)
        {
            sessionID = sID;
            staffID = staffID;
            Slope = so;
            date = date;
            StartTime = start;
            EndTime = end;
            b = t;
        }

        public Controller()
        {

        }

        public bool Update()
        {
            BookingType type = Factory.getType(b.Checked);
            bool getType = type.type(b.Checked);

            Session ses = new Session(int.Parse(sessionID.Text.ToString()), int.Parse(staffID.Text.ToString()), int.Parse(Slope.Text.ToString()), Convert.ToDateTime(date.Text), Convert.ToDateTime(StartTime.Text), Convert.ToDateTime(EndTime.Text), getType);
            bool i = ses.Update();
            return i;
        }

        public bool getSession()
        {
            Session session = new Session();
            bool i = session.getSession(int.Parse(sessionID.Text.ToString()));

            if (i)
            {
                staffID.Text = session.StaffID.ToString();
                session.Checked = session;
            }
            return i;
        }

        public bool Save()
        {
            BookingType type = Factory.getType(b.Checked);
            bool getType = type.type(b.Checked);

            Session ses = new Session(int.Parse(sessionID.Text.ToString()), int.Parse(staffID.Text.ToString()), int.Parse(Slope.Text.ToString()), Convert.ToDateTime(date.Text), Convert.ToDateTime(StartTime.Text), Convert.ToDateTime(EndTime.Text), getType);
            bool i = ses.Update();
            return i;
        }

        public bool manualTest()
        {
            Console.WriteLine("-------TEST BEGINS------");
            using (SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30"))
            
               
        }
    }
}
