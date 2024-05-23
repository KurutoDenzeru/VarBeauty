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
	public partial class EmployeeProducts : Form
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

		public EmployeeProducts()
		{
			InitializeComponent();
			DisplayProducts();
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}


		MySqlConnection Con = new MySqlConnection("server = localhost; user = root; password = ''; database = varsalonlocal; SSL mode = none");

		private void DisplayProducts()
		{
			Con.Open();
			string Query = "Select * from Products";
			MySqlDataAdapter sda = new MySqlDataAdapter(Query, Con);
			MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
			var ds = new DataSet();
			sda.Fill(ds);
			ProductsDGV.DataSource = ds.Tables[0];
			Con.Close();
		}

		private void Clear() // Clear Function for each Triggered Function
		{
			ProductItemtxt.Text = "";
			ProductTypecbx.Text = "";
			ProductStocktxt.Text = "";
		}

		private void EmployeeProducts_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Inquirybtn_Click(object sender, EventArgs e)
		{
			EmployeeCustomers myForm = new EmployeeCustomers();
			this.Hide();
			myForm.ShowDialog();
			this.Close();
		}

		private void Addbtn_Click(object sender, EventArgs e) // Add or Save Records
		{
			if (ProductItemtxt.Text == "" || ProductTypecbx.SelectedIndex == -1 || ProductStocktxt.Text == "")
			{
				MessageBox.Show("Missing Information");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("INSERT INTO Products (ProductItem, ProductType, ProductStock) " +
						"values(@ProdItem, @ProdType, @ProdStock)", Con);
					cmd.Parameters.AddWithValue("@ProdItem", ProductItemtxt.Text);
					cmd.Parameters.AddWithValue("@ProdType", ProductTypecbx.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@ProdStock", ProductStocktxt.Text);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Product Added!");
					Con.Close();
					DisplayProducts();
					Clear();
				}
				catch (Exception Ex)
				{
					MessageBox.Show(Ex.Message);
				}
			}
		}

		private void Updatebnt_Click(object sender, EventArgs e) // Update Records
		{
			if (ProductItemtxt.Text == "" || ProductTypecbx.SelectedIndex == -1 || ProductStocktxt.Text == "")
			{
				MessageBox.Show("Missing Information");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("UPDATE Products set ProductItem=@ProdItem, " +
						"ProductType=@ProdType, ProductStock=@ProdStock where ProductID=@ProdID", Con);
					cmd.Parameters.AddWithValue("@ProdID", ID);
					cmd.Parameters.AddWithValue("@ProdItem", ProductItemtxt.Text);
					cmd.Parameters.AddWithValue("@ProdType", ProductTypecbx.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@ProdStock", ProductStocktxt.Text);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Product Updated!");
					Con.Close();
					DisplayProducts();
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
				MessageBox.Show("Select a Product");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("DELETE FROM Products where ProductID=@ProdID", Con);
					cmd.Parameters.AddWithValue("@ProdID", ID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Product Deleted!");
					Con.Close();
					DisplayProducts();
					Clear();
				}
				catch (Exception Ex)
				{
					MessageBox.Show(Ex.Message);
				}
			}
		}

		private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			ID = Convert.ToInt32(ProductsDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
			ProductItemtxt.Text = ProductsDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
			ProductTypecbx.Text = ProductsDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
			ProductStocktxt.Text = ProductsDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
		}

		private void Histobtn_Click(object sender, EventArgs e)
		{
			EmployeeHistory HistoForm = new EmployeeHistory();
			this.Hide();
			HistoForm.ShowDialog();
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			EmployeeBilling BillingForm = new EmployeeBilling();
			this.Hide();
			BillingForm.ShowDialog();
			this.Close();
		}
	}
}
