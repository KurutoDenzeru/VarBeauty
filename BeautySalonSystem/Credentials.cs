using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace BeautySalonSystem
{
	public partial class Credentials : Form
	{
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
		(
		int nLeftRect,     // x-coordinate of upper-left corner
		int nTopRect,      // y-coordinate of upper-left corner
		int nRightRect,    // x-coordinate of lower-right corner
		int nBottomRect,   // y-coordinate of lower-right corner
		int nWidthEllipse, // width of ellipse
		int nHeightEllipse // height of ellipse
		);

		public Credentials()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}

		

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string sql_con = "Server=localhost; user=root; password=''; database=varsalonlocal; SSL mode=none; ";
			MySqlConnection Con = new MySqlConnection(sql_con);
			MySqlCommand cmd;
			MySqlDataReader dr;
			string user = Usernametxt.Text;
			string pass = Passwordtxt.Text;
			cmd = new MySqlCommand();

			if (Usernametxt.Text == "" || Passwordtxt.Text == "")
			{
				MessageBox.Show("Missing Information"); // Admin Authentication Credentials Login
			}
			else
			{
				Con.Open();
				cmd.Connection = Con;
				cmd.CommandText = "SELECT * FROM owner WHERE OwnerUsername='" + Usernametxt.Text + "' AND OwnerPassword='" + Passwordtxt.Text + "'";
				dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					AdminEmployees myForm = new AdminEmployees();
					this.Hide();
					myForm.ShowDialog();
					this.Close();
				}
				else
				{
					MessageBox.Show("Wrong Password or Username");
				}
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Does not require any Authentication
			CustomerAppointment custForm = new CustomerAppointment();
			this.Hide();
			custForm.ShowDialog();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MySqlConnection Con = new MySqlConnection("Server=localhost; user=root; password =''; database=varsalonlocal; SSL mode=none");
			MySqlCommand cmd;
			MySqlDataReader dr;
			string user = Usernametxt.Text;
			string pass = Passwordtxt.Text;
			cmd = new MySqlCommand();

			if (Usernametxt.Text == "" || Passwordtxt.Text == "")
			{
				MessageBox.Show("Missing Information"); // Employee Authentication Credentials Login
			}
			else
			{
				Con.Open();
				cmd.Connection = Con;
				cmd.CommandText = "SELECT * FROM Employee where EmployeeName='" + Usernametxt.Text + "' AND EmployeePassword='" + Passwordtxt.Text + "'";
				dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					EmployeeCustomers myForm = new EmployeeCustomers();
					this.Hide();
					myForm.ShowDialog();
					this.Close();
				}
				else
				{
					MessageBox.Show("Wrong Password or Username");
				}
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{			
			this.Close();			
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{			
		}
	}
}
