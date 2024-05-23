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

namespace BeautySalonSystem
{
	public partial class AdminEmployees : Form
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

		public AdminEmployees()
		{
			InitializeComponent();
			DisplayEmployees();
			GetOwnerID();
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}

		MySqlConnection Con = new MySqlConnection("server = localhost; user = root; password = ''; database = varsalonlocal; SSL mode = none");

		private void DisplayEmployees() // Show Remote Datagridview
		{
			Con.Open();
			string Query = "Select * from Employee";
			MySqlDataAdapter sda = new MySqlDataAdapter(Query, Con);
			MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
			var ds = new DataSet();
			sda.Fill(ds);
			EmployeeDGV.DataSource = ds.Tables[0];
			Con.Close();
		}

		private void GetOwnerID() // OwnerID Foreign Key
		{
			Con.Open();
			MySqlCommand cmd = new MySqlCommand("Select OwnerID from Owner", Con);
			MySqlDataReader Rdr;
			Rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Columns.Add("OwnerID", typeof(int));
			dt.Load(Rdr);
			OwnerIDcbx.ValueMember = "OwnerID";
			OwnerIDcbx.DataSource = dt;
			Con.Close();
		}

		private void Clear() // Clear Function for each Triggered Function
		{
			EmployeeNametxt.Text = "";
			EmployeePositioncbx.Text = "";
			EmployeeContacttxt.Text = "";			
			EmployeeDOB.Text = "";
			EmployeePassword.Text = "";
			OwnerIDcbx.Text = "";
		}

		private void AdminEmployees_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Credentials myForm = new Credentials();
			this.Hide();
			myForm.ShowDialog();
			this.Close();
		}

		private void Savebtn_Click(object sender, EventArgs e) // Save or Add Records
		{
			if (EmployeeNametxt.Text == "" || EmployeePositioncbx.SelectedIndex == -1 || EmployeeContacttxt.Text == "" ||
				EmployeeDOB.Text == "" || EmployeePassword.Text == "" || OwnerIDcbx.SelectedIndex == -1)
			{
				MessageBox.Show("Missing Information");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("insert into Employee (EmployeeName, EmployeePosition, EmployeeContactNumber, EmployeeDateofBirth, EmployeePassword, OwnerID) " +
						"values(@EmpName, @EmpPosition, @EmpContact, @EmpDOB, @EmpPass, @OwnerID)", Con);
					cmd.Parameters.AddWithValue("@EmpName", EmployeeNametxt.Text);
					cmd.Parameters.AddWithValue("@EmpPosition", EmployeePositioncbx.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@EmpContact", EmployeeContacttxt.Text);
					cmd.Parameters.AddWithValue("@EmpDOB", EmployeeDOB.Value.Date);
					cmd.Parameters.AddWithValue("@EmpPass", EmployeePassword.Text);
					cmd.Parameters.AddWithValue("@OwnerID", int.Parse(OwnerIDcbx.SelectedValue.ToString()));
					cmd.ExecuteNonQuery();
					MessageBox.Show("Employee Added!");
					Con.Close();
					DisplayEmployees();
					Clear();
				}
				catch (Exception Ex)
				{
					MessageBox.Show(Ex.Message);
				}
			}
		}

		private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			ID = Convert.ToInt32(EmployeeDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
			EmployeeNametxt.Text = EmployeeDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
			EmployeePositioncbx.Text = EmployeeDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
			EmployeeContacttxt.Text = EmployeeDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
			EmployeeDOB.Text = EmployeeDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
			EmployeePassword.Text = EmployeeDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
			OwnerIDcbx.Text = EmployeeDGV.Rows[e.RowIndex].Cells[6].Value.ToString();
		}

		private void Updatebtn_Click(object sender, EventArgs e) // Update or Edit Records
		{
			if (EmployeeNametxt.Text == "" || EmployeePositioncbx.SelectedIndex == -1 || EmployeeContacttxt.Text == "" ||
				EmployeeDOB.Text == "" || EmployeePassword.Text == "" || OwnerIDcbx.SelectedIndex == -1)
			{
				MessageBox.Show("Missing Information");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("Update Employee set EmployeeName=@EName, " +
						"EmployeePosition=@EmpPosition, " +
						"EmployeeContactNumber=@EmpContact, " +
						"EmployeeDateofBirth=@EmpDOB, " +
						"EmployeePassword=@EmpPass, " +
						"OwnerID=@OwnerIDFK " +
						"where EmployeeID=@EmpID", Con);					
					cmd.Parameters.AddWithValue("@EmpID", ID);
					cmd.Parameters.AddWithValue("@EName", EmployeeNametxt.Text);
					cmd.Parameters.AddWithValue("@EmpPosition", EmployeePositioncbx.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@EmpContact", EmployeeContacttxt.Text);					
					cmd.Parameters.AddWithValue("@EmpDOB", EmployeeDOB.Value.Date);
					cmd.Parameters.AddWithValue("@EmpPass", EmployeePassword.Text);					
					cmd.Parameters.AddWithValue("@OwnerIDFK", int.Parse(OwnerIDcbx.SelectedValue.ToString()));					
					cmd.ExecuteNonQuery();
					MessageBox.Show("Employee Updated!");
					Con.Close();
					DisplayEmployees();
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
				MessageBox.Show("Select an Employee");
			}
			else
			{
				try
				{
					Con.Open();
					MySqlCommand cmd = new MySqlCommand("Delete FROM Employee where EmployeeID=@EmployeetID", Con);					
					cmd.Parameters.AddWithValue("@EmployeetID", ID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Employee Deleted!");
					Con.Close();
					DisplayEmployees();
					Clear();
				}
				catch (Exception Ex)
				{
					MessageBox.Show(Ex.Message);
				}
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}