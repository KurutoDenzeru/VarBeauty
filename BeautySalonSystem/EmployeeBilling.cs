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
	public partial class EmployeeBilling : Form
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

		int ID = 0; // Parsing Records

		public EmployeeBilling()
		{
			InitializeComponent();
			DisplayCustomers();
			GetCustomerID();
			GetEmployeeID();
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}

		MySqlConnection Con = new MySqlConnection("server = localhost; user = root; password = ''; database = varsalonlocal; SSL mode = none");

		private void DisplayCustomers()
		{
			Con.Open();
			string Query = "Select * from Customer";
			MySqlDataAdapter sda = new MySqlDataAdapter(Query, Con);
			MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
			var ds = new DataSet();
			sda.Fill(ds);
			CustomerDGV.DataSource = ds.Tables[0];
			Con.Close();
		}

		private void GetCustomerID() // CustomerID Foreign Key
		{
			Con.Open();
			MySqlCommand cmd = new MySqlCommand("Select CustomerID from Customer", Con);
			MySqlDataReader Rdr;
			Rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Columns.Add("CustomerID", typeof(int));
			dt.Load(Rdr);
			CustomerIDcbx.ValueMember = "CustomerID";
			CustomerIDcbx.DataSource = dt;
			Con.Close();
		}

		private void GetEmployeeID() // EmployeeID Foreign Key
		{
			Con.Open();
			MySqlCommand cmd = new MySqlCommand("Select EmployeeID from Employee", Con);
			MySqlDataReader Rdr;
			Rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Columns.Add("EmployeeID", typeof(int));
			dt.Load(Rdr);
			EmployeeIDcbx.ValueMember = "EmployeeID";
			EmployeeIDcbx.DataSource = dt;
			Con.Close();
		}

		private void Reset()
		{
			CustomerIDcbx.SelectedIndex = -1;
			CustomerNametxt.Text = "";
			CustomerDate.Text = "";
			CustomerTreatmentcbx.SelectedIndex = -1;
			CustomerPaymenttxt.Text = "";
			EmployeeIDcbx.SelectedIndex = 0;
		}

		public void PrintFunction()
		{
			printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 765, 180);
			if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
				printDocument1.Print();
			}
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void EmployeeBilling_Load(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			ID = Convert.ToInt32(CustomerDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
			CustomerIDcbx.Text = CustomerDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
			CustomerNametxt.Text = CustomerDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
			CustomerDate.Text = CustomerDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
			CustomerTreatmentcbx.Text = CustomerDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
			CustomerPaymenttxt.Text = CustomerDGV.Rows[e.RowIndex].Cells[6].Value.ToString();
			EmployeeIDcbx.Text = CustomerDGV.Rows[e.RowIndex].Cells[7].Value.ToString();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Credentials myForm = new Credentials();
			this.Hide();
			myForm.ShowDialog();
			this.Close();
		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void CustomerTreatmentcbx_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void Productsbtn_Click(object sender, EventArgs e)
		{
			EmployeeProducts ProductsForm = new EmployeeProducts();
			this.Hide();
			ProductsForm.ShowDialog();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			EmployeeHistory HistoForm = new EmployeeHistory();
			this.Hide();
			HistoForm.ShowDialog();
			this.Close();
		}

		private void Inquirybtn_Click(object sender, EventArgs e)
		{
			Credentials myForm = new Credentials();
			this.Hide();
			myForm.ShowDialog();
			this.Close();
		}

		int n = 0, GrandTotal = 0, qty = 1;

		private void Printbut_Click(object sender, EventArgs e)
		{
			PrintFunction();
		}

		private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{

		}

		private void printPreviewDialog1_Load(object sender, EventArgs e)
		{

		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			string BillingID, CustomerID, CustomerName, CustomerDateTaken, Treatment, TreatmentPrice, EmployeeID;
			e.Graphics.DrawString("VarBeauty", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Red, new Point(315, 10));
			e.Graphics.DrawString("BillingID｜CustomerID｜CustomerName｜CustomerDateTaken｜CustomerTreatment｜Price｜EmployeeID", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, new Point(25, 40));

			foreach (DataGridViewRow row in BillingDGV.Rows)
			{
				BillingID = "" + row.Cells["BillingID"].Value;
				CustomerID = "" + row.Cells["CustomerID"].Value;
				CustomerName = "" + row.Cells["CustomerName"].Value;
				CustomerDateTaken = "" + row.Cells["DateTaken"].Value;
				Treatment = "" + row.Cells["Treatment"].Value;
				TreatmentPrice = "" + row.Cells["Price"].Value;
				EmployeeID = "" + row.Cells["EmployeeID"].Value;

				e.Graphics.DrawString("" + BillingID, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Blue, new Point(26, 71));
				e.Graphics.DrawString("" + CustomerID, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Blue, new Point(113, 71));
				e.Graphics.DrawString("" + CustomerName, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Blue, new Point(193, 71));
				e.Graphics.DrawString("" + CustomerDateTaken, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Blue, new Point(313, 71));
				e.Graphics.DrawString("" + Treatment, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Blue, new Point(463, 71));
				e.Graphics.DrawString("" + TreatmentPrice, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Blue, new Point(610, 71));
				e.Graphics.DrawString("" + EmployeeID, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Blue, new Point(665, 71));
			}

			e.Graphics.DrawString("Total: " + GrandTotal, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Blue, new Point(580, 102));
			e.Graphics.DrawString("***BEAUTY SALON***", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Crimson, new Point(275, 125));
			e.Graphics.DrawString("***APPOINTMENT SYSTEM***", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Crimson, new Point(244, 146));
			BillingDGV.Rows.Clear();
			BillingDGV.Refresh();
			GrandTotal = 0;
			n = 0;
			qty = 0;

		}

		private void Printbtn_Click(object sender, EventArgs e) // Print Button
		{
		}

		private void button3_Click(object sender, EventArgs e) // Add to Billing Records
		{
			if (CustomerIDcbx.SelectedIndex == -1 || CustomerNametxt.Text == "" || CustomerDate.Text == "" || 
				CustomerTreatmentcbx.SelectedIndex == -1 || CustomerPaymenttxt.Text == "" || EmployeeIDcbx.SelectedIndex == -1)
			{
				MessageBox.Show("Missing Information");
			}
			else
			{
				int total = Convert.ToInt32(CustomerPaymenttxt.Text) * Convert.ToInt32(qty);
				DataGridViewRow index = (DataGridViewRow)BillingDGV.Rows[0].Clone();
				index.CreateCells(BillingDGV);
				index.Cells[0].Value = n + 1;
				index.Cells[1].Value = int.Parse(CustomerIDcbx.SelectedValue.ToString());
				index.Cells[2].Value = CustomerNametxt.Text;
				index.Cells[3].Value = CustomerDate.Value.Date;
				index.Cells[4].Value = CustomerTreatmentcbx.SelectedItem.ToString();
				index.Cells[5].Value = CustomerPaymenttxt.Text;
				index.Cells[6].Value = int.Parse(EmployeeIDcbx.SelectedValue.ToString());
				GrandTotal = GrandTotal + total;
				BillingDGV.Rows.Add(index);
				qty++;
				n++;
				Reset();
			}
		}
	}
}
