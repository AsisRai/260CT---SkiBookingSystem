using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_AJR___SBC_Booking_System
{
    public partial class MainUIform : Form
    {
        public MainUIform()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Registration.Registration main = new Registration.Registration();
            main.Show();
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Booking.Bookingform main = new Booking.Bookingform();
            main.Show();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Group_AJR___SBC_Booking_System.Form1 login = new Group_AJR___SBC_Booking_System.Form1();
            login.Show();
        }

        
    }
}
