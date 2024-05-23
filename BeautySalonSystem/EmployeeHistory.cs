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
	public partial class EmployeeHistory : Form
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

		public EmployeeHistory()
		{
			InitializeComponent();
			DisplayCustomers();
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}

		MySqlConnection Con = new MySqlConnection("server = localhost; user = root; password = ''; database = varsalonlocal; SSL mode = none");

		private void DisplayCustomers() // Show Remote Datagridview
		{
			Con.Open();
			string Query = "Select * from customer";
			MySqlDataAdapter sda = new MySqlDataAdapter(Query, Con);
			MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
			var ds = new DataSet();
			sda.Fill(ds);
			HistoryDGV.DataSource = ds.Tables[0];
			Con.Close();
		}

		public void populateGrid()
		{
			Con.Open();
			string query = "select * from customer";
			MySqlDataAdapter da = new MySqlDataAdapter(query, Con);
			MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
			var ds = new DataSet();
			da.Fill(ds);
			HistoryDGV.DataSource = ds.Tables[0];
			Con.Close();
		}

		public void TextboxFilter()
		{
			Con.Open();
			string query = "select * from customer where CustomerName = '" + Searchtxt.Text + "'";
			MySqlDataAdapter da = new MySqlDataAdapter(query, Con);
			MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
			var ds = new DataSet();
			da.Fill(ds);
			HistoryDGV.DataSource = ds.Tables[0];
			Con.Close();
		}

		private void EmployeeHistory_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Credentials myForm = new Credentials();
			this.Hide();
			myForm.ShowDialog();
			this.Close();
		}

		private void Searchbtn_Click(object sender, EventArgs e)
		{
			TextboxFilter();
		}

		private void Resetbtn_Click(object sender, EventArgs e)
		{
			populateGrid();
		}

		private void Customersbtn_Click(object sender, EventArgs e)
		{
			EmployeeCustomers CustoForm = new EmployeeCustomers();
			this.Hide();
			CustoForm.ShowDialog();
			this.Close();
		}

		private void Productsbtn_Click(object sender, EventArgs e)
		{
			EmployeeProducts ProductsForm = new EmployeeProducts();
			this.Hide();
			ProductsForm.ShowDialog();
			this.Close();
		}

		private void Billing_Click(object sender, EventArgs e)
		{
			EmployeeBilling BillingForm = new EmployeeBilling();
			this.Hide();
			BillingForm.ShowDialog();
			this.Close();
		}
	}
}
