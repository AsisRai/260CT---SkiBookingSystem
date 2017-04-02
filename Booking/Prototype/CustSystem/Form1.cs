﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustSystem
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=260projectDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Customer where ID ='" + txtID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtID.Text = dt.Rows[0][0].ToString();
            txtFirstName.Text = dt.Rows[0][1].ToString();
            txtLastName.Text = dt.Rows[0][2].ToString();
            txtInstructor.Text = dt.Rows[0][3].ToString();
            txtAddress.Text = dt.Rows[0][4].ToString();
            txtPostCode.Text = dt.Rows[0][5].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "INSERT INTO Customer VALUES(@DateOfBooking,@GroupSize,@Reference,@Cost)", sqlConn);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string sqlText = "SELECT ID, FirstName, LastName, Instructor, FROM customer";

            SqlConnection sqlConn = new SqlConnection(@"Data Source=.;Initial Catalog=260projectDB;Integrated Security=True");

            SqlCommand command = new SqlCommand(sqlText, sqlConn);

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=260projectDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("INSERT INTO Customer VALUES='" + txtDateOfBooking + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            txtDateOfBooking.Text = dt.Rows[0][6].ToString();
            txtGroupSize.Text = dt.Rows[0][7].ToString();
            txtRef.Text = dt.Rows[0][8].ToString();
            txtCost.Text = dt.Rows[0][9].ToString();
            
            sqlConn.Open();
            da.InsertCommand.ExecuteNonQuery();
            sqlConn.Close();
            MessageBox.Show("Client Successfully added");
            this.Close();

    }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=260projectDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Customer where ID ='" + txtID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtID.Text = dt.Rows[0][0].ToString();
            txtFirstName.Text = dt.Rows[0][1].ToString();
            txtLastName.Text = dt.Rows[0][2].ToString();
            txtInstructor.Text = dt.Rows[0][3].ToString();
            txtAddress.Text = dt.Rows[0][4].ToString();
            txtPostCode.Text = dt.Rows[0][5].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
