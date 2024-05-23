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
	public partial class EmployeeCustomers : Form
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

		int ID = 0; // Updating & Deleting Records	

		public EmployeeCustomers()
		{
			InitializeComponent();
			DisplayCustomers();
			GetEmployeeID();
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}

		MySqlConnection Con = new MySqlConnection("server = localhost; user = root; password = ''; database = varsalonlocal; SSL mode = none");

		private void DisplayCustomers() // Show Remote Datagridview
		{
			Con.Open();
			string Query = "Select * from Customer";
			MySqlDataAdapter sda = new MySqlDataAdapter(Query, Con);
			MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
			var ds = new DataSet();
			sda.Fill(ds);
			CustomersDGV.DataSource = ds.Tables[0];
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

		private void Clear() // Clear Function for each Triggered Function
		{
			CustomerNametxt.Text = "";
			CustomerAddresstxt.Text = "";
			CustomerContacttxt.Text = "";
			CustomerDate.Text = "";
			CustomerTreatmentcbx.Text = "";
			CustomerPaymenttxt.Text = "";
			EmployeeIDcbx.Text = "";
		}

		private void CustomerContacttxt_TextChanged(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Credentials myForm = new Credentials();
			this.Hide();
			myForm.ShowDialog();
			this.Close();
		}

		private void EmployeeCustomers_Load(object sender, EventArgs e)
		{

		}

		private void CustomerTreatmentcbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Massage Therapies
			if (CustomerTreatmentcbx.SelectedIndex == 0) // 0 Deep Tissue Sports Massage
			{				
				CustomerPaymenttxt.Text = "450";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 1) // 1 Hotstone Massage
			{				
				CustomerPaymenttxt.Text = "500";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 2) // 2 Prenatal Massage
			{
				CustomerPaymenttxt.Text = "400";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 3) // 3 Reflexology Massage
			{
				CustomerPaymenttxt.Text = "350";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 4) // 4 Swedish Massage
			{
				CustomerPaymenttxt.Text = "400";
			}

			// Nails, Hands & Foot Care Services
			else if (CustomerTreatmentcbx.SelectedIndex == 5) // 5 Manicure
			{
				CustomerPaymenttxt.Text = "200";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 6) // 6 Pedicure
			{				
				CustomerPaymenttxt.Text = "220";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 7) // 7 Hand Spa Manicure
			{
				CustomerPaymenttxt.Text = "450";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 8) // 8 Change Polish
			{
				CustomerPaymenttxt.Text = "130";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 9) // 9 Foot Spa Pedicure
			{
				CustomerPaymenttxt.Text = "530";
			}

			// Waxing Services
			else if (CustomerTreatmentcbx.SelectedIndex == 10) // 10 Brazillian Wax
			{
				CustomerPaymenttxt.Text = "450";				
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 11) // 11 Bikini Wax
			{
				CustomerPaymenttxt.Text = "250";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 12) // 12 Underarm Wax
			{
				CustomerPaymenttxt.Text = "150";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 13) // 13 Full Leg Wax
			{
				CustomerPaymenttxt.Text = "500";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 14) // 14 Full Arm Wax
			{
				CustomerPaymenttxt.Text = "500";
			}

			// Hair Treatments
			else if (CustomerTreatmentcbx.SelectedIndex == 15) // 15 Keratin
			{
				CustomerPaymenttxt.Text = "3000";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 16) // 16 Scalp
			{
				CustomerPaymenttxt.Text = "3000";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 17) // 17 Rebond
			{				
				CustomerPaymenttxt.Text = "2500";			
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 18) // 18 Brazillian
			{
				CustomerPaymenttxt.Text = "1500";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 19) // 19 Detox
			{
				CustomerPaymenttxt.Text = "1000";
			}
		}

		private void Historybtn_Click(object sender, EventArgs e)
		{
			EmployeeHistory HistoForm = new EmployeeHistory();
			this.Hide();
			HistoForm.ShowDialog();
			this.Close();
		}

		private void Productsbtn_Click(object sender, EventArgs e)
		{
			EmployeeProducts ProductsForm = new EmployeeProducts();
			this.Hide();
			ProductsForm.ShowDialog();
			this.Close();
		}

		private void Billingbtn_Click(object sender, EventArgs e)
		{
			EmployeeBilling BillingForm = new EmployeeBilling();
			this.Hide();
			BillingForm.ShowDialog();
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void Addbtn_Click(object sender, EventArgs e) // Add or Save Records
		{
			if (CustomerNametxt.Text == "" || CustomerAddresstxt.Text == "" || CustomerContacttxt.Text == "" ||
				CustomerDate.Text == "" || CustomerTreatmentcbx.SelectedIndex == -1 || CustomerPaymenttxt.Text == "" ||
				EmployeeIDcbx.SelectedIndex == -1)
			{
				MessageBox.Show("Missing Information");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("insert into Customer (CustomerName, CustomerAddress, CustomerContactNumber, CustomerDateTaken, CustomerTreatment, TreatmentPrice, EmployeeID) " +
						"values(@CustName, @CustAdd, @CustContact, @CustDate, @CustTreatment, @CustPrice, @EmpID)", Con);
					cmd.Parameters.AddWithValue("@CustName", CustomerNametxt.Text);
					cmd.Parameters.AddWithValue("@CustAdd", CustomerAddresstxt.Text);
					cmd.Parameters.AddWithValue("@CustContact", CustomerContacttxt.Text);
					cmd.Parameters.AddWithValue("@CustDate", CustomerDate.Value.Date);
					cmd.Parameters.AddWithValue("@CustTreatment", CustomerTreatmentcbx.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@CustPrice", CustomerPaymenttxt.Text);
					cmd.Parameters.AddWithValue("@EmpID", int.Parse(EmployeeIDcbx.SelectedValue.ToString()));
					cmd.ExecuteNonQuery();
					MessageBox.Show("Customer Added!");
					Con.Close();
					DisplayCustomers();
					Clear();
				}
				catch (Exception Ex)
				{
					MessageBox.Show(Ex.Message);
				}
			}
		}

		private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			ID = Convert.ToInt32(CustomersDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
			CustomerNametxt.Text = CustomersDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
			CustomerAddresstxt.Text = CustomersDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
			CustomerContacttxt.Text = CustomersDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
			CustomerDate.Text = CustomersDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
			CustomerTreatmentcbx.Text = CustomersDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
			CustomerPaymenttxt.Text = CustomersDGV.Rows[e.RowIndex].Cells[6].Value.ToString();
			EmployeeIDcbx.Text = CustomersDGV.Rows[e.RowIndex].Cells[7].Value.ToString();
		}

		private void Updatebtn_Click(object sender, EventArgs e) // Update Records
		{
			if (CustomerNametxt.Text == "" || CustomerAddresstxt.Text == "" || CustomerContacttxt.Text == "" ||
				CustomerDate.Text == "" || CustomerTreatmentcbx.SelectedIndex == -1 || CustomerPaymenttxt.Text == "" ||
				EmployeeIDcbx.SelectedIndex == -1)
			{
				MessageBox.Show("Missing Information");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("Update Customer set CustomerName=@CustNames, " +
						"CustomerAddress=@CustAdds, " +
						"CustomerContactNumber=@CustContact, " +
						"CustomerDateTaken=@CustDate, " +
						"CustomerTreatment=@CustTreatment, " +
						"TreatmentPrice=@CustPrice, " +
						"EmployeeID=@EmpIDFK " +
						"where CustomerID=@CustID", Con);
					cmd.Parameters.AddWithValue("@CustID", ID);
					cmd.Parameters.AddWithValue("@CustNames", CustomerNametxt.Text);
					cmd.Parameters.AddWithValue("@CustAdds", CustomerAddresstxt.Text);
					cmd.Parameters.AddWithValue("@CustContact", CustomerContacttxt.Text);
					cmd.Parameters.AddWithValue("@CustDate", CustomerDate.Value.Date);									
					cmd.Parameters.AddWithValue("@CustTreatment", CustomerTreatmentcbx.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@CustPrice", CustomerPaymenttxt.Text);
					cmd.Parameters.AddWithValue("@EmpIDFK", int.Parse(EmployeeIDcbx.SelectedValue.ToString()));
					cmd.ExecuteNonQuery();
					MessageBox.Show("Employee Updated!");
					Con.Close();
					DisplayCustomers();
					Clear();
				}
				catch (Exception Ex)
				{
					MessageBox.Show(Ex.Message);
				}
			}
		}

		private void Deletebtn_Click(object sender, EventArgs e) // Delete Records
		{
			if (ID == 0)
			{
				MessageBox.Show("Select a Customer");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("Delete FROM Customer where CustomerID=@CustID", Con);
					cmd.Parameters.AddWithValue("@CustID", ID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Customer Deleted!");
					Con.Close();
					DisplayCustomers();
					Clear();
				}
				catch (Exception Ex)
				{
					MessageBox.Show(Ex.Message);
				}
			}
		}

		private void CustomerDate_ValueChanged(object sender, EventArgs e)
		{

		}

		private void CustomersBtn_Click(object sender, EventArgs e)
		{

		}
	}
}
