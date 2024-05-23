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
	public partial class CustomerAppointment : Form
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

		public CustomerAppointment()
		{
			InitializeComponent();
			GetEmployeeID();
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}

		MySqlConnection Con = new MySqlConnection("server = localhost; user = root; password = ''; database = varsalonlocal; SSL mode = none");

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

		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{

		}

		private void CustomerAppointment_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Credentials myForm = new Credentials();
			this.Hide();
			myForm.ShowDialog();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e) // Submit an Inquiry
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
					MessageBox.Show("Your Inquiry has been Submitted!");
					Con.Close();					
					Clear();
				}
				catch (Exception Ex)
				{
					MessageBox.Show(Ex.Message);
				}
			}
		}

		private void CustomerTreatmentcbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Massage Therapies
			if (CustomerTreatmentcbx.SelectedIndex == 0) // 0 Deep Tissue Sports Massage
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Deep Tissue Sports Massage.jpg");
				CustomerPaymenttxt.Text = "450";
				TreatmentTitlelb.Text = "Treatment: Deep Tissue Sports Massage";
				TreatmentDescriptionlb.Text = "Treatment Description: A therapeutic massage that focuses " +
				"on the techniques of stretching, pressure point, re-balancing, muscle release and joint release.";				
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 1) // 1 Hotstone Massage
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Hotstone Massage.jpg");
				CustomerPaymenttxt.Text = "500";
				TreatmentTitlelb.Text = "Treatment: Hotstone Massage";
				TreatmentDescriptionlb.Text = "Treatment Description: An energy belancing treatment using hot stones to facilitate " +
				"circulation and ultimate relaxation for the mind, body and soul.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 2) // 2 Prenatal Massage
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\Resources\Prenatal Massage.jpg");
				CustomerPaymenttxt.Text = "400";
				TreatmentTitlelb.Text = "Treatment: Prenatal Massage";
				TreatmentDescriptionlb.Text = "Treatment Description: Specialty designed for the mother-to-be, this nurturing massage " +
				"is the perfect way to reduce stress and relieve discomfort during your pregnancy.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 3) // 3 Reflexology Massage
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Reflexology Massage.jpg");
				CustomerPaymenttxt.Text = "350";
				TreatmentTitlelb.Text = "Treatment: Reflexology Massage";
				TreatmentDescriptionlb.Text = "Treatment Description: Gentle pressure and massage of the first improving circulation, " +
				"reducing fatigue and improving physical balance. Add this massage to any session.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 4) // 4 Swedish Massage
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Swedish Massage.jpg");
				CustomerPaymenttxt.Text = "400";
				TreatmentTitlelb.Text = "Treatment: Swedish Massage";
				TreatmentDescriptionlb.Text = "Treatment Description: Traditional European technique which releases muscular tension " +
				"and improves circulation.";
			}

			// Nails, Hands & Foot Care Services
			else if (CustomerTreatmentcbx.SelectedIndex == 5) // 5 Manicure
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Manicure.jpg");
				CustomerPaymenttxt.Text = "200";
				TreatmentTitlelb.Text = "Treatment: Manicure";
				TreatmentDescriptionlb.Text = "Treatment Description: A manicure refers to the curation and care of a client's hands " +
				"and a pedicure refers to the curation and care of a client's feet. This includes skincare, nail care, and artificial " +
				"nail enhancements that can be customized to a variety of preferences";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 6) // 6 Pedicure
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Pedicure.jpg");
				CustomerPaymenttxt.Text = "220";
				TreatmentTitlelb.Text = "Treatment: Pedicure";
				TreatmentDescriptionlb.Text = "A pedicure is a comprehensive treatment of your feet and is suitable " +
				"for both men and women. It involves cutting, trimming and shaping your toenails, tending to your " +
				"cuticles, exfoliating, hydrating and massaging your feet, and, if desired, painting your toenails";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 7) // 7 Hand Spa Manicure
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Hand Spa Manicure.jpg");
				CustomerPaymenttxt.Text = "450";
				TreatmentTitlelb.Text = "Treatment: Hand Spa Manicure";
				TreatmentDescriptionlb.Text = "The number one focus of a basic manicure is your nails. A spa manicure is typically a " +
				"longer service focused on stress relief and relaxation. Spa manicures may include benefits such as a neck massage, " +
				"cucumber water, warm tea and a comfortable robe for you to wear during your experience.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 8) // 8 Change Polish
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Change Polish.jpg");
				CustomerPaymenttxt.Text = "130";
				TreatmentTitlelb.Text = "Treatment: Change Polish";
				TreatmentDescriptionlb.Text = "Polish change is a mini manicure and pedicure offered by almost all spas and nail salons; " +
				"it has to do with the removal of the old polish and the application of a new one. Nail polishes are applied to decorate " +
				"and protect the nail plates.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 9) // 9 Foot Spa Pedicure
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Foot Spa Pedicure.jpg");
				CustomerPaymenttxt.Text = "530";
				TreatmentTitlelb.Text = "Treatment: Foot Spa Pedicure";
				TreatmentDescriptionlb.Text = "A Spa Pedicure is an amazing experience which cleans and removes the dead skin cells " +
				"from the feet and toenails. It helps prevent nail diseases. The pedicure is also accompanied by a foot massage that " +
				"rejuvenates the skin as well as relaxing the muscles.";
			}

			// Waxing Services
			else if (CustomerTreatmentcbx.SelectedIndex == 10) // 10 Brazillian Wax
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Brazillian Wax.jpg");
				CustomerPaymenttxt.Text = "450";
				TreatmentTitlelb.Text = "Treatment: Brazillian Wax";
				TreatmentDescriptionlb.Text = "Brazilian is the most painful. This is because when you opt for Brazilian wax, " +
				"you are asking for your entire pubic region to be cleaned bare. Ideal for someone who wants to go completely clean " +
				"down there, this form of waxing could prove to be slightly embarrassing considering that you will be asked to spread " +
				"your legs or bend down so the technician can do a better job.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 11) // 11 Bikini Wax
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Bikini Wax.jpg");
				CustomerPaymenttxt.Text = "250";
				TreatmentTitlelb.Text = "Treatment: Brazillian Wax";
				TreatmentDescriptionlb.Text = "The most common form of waxing, a bikini wax is ideal for beginners. " +
				"It is also perfect for someone who wants to wear hot shorts or a bikini (summer vacay feels, ya know?)." +
				"This form of waxing consists of waxing the bikini area and includes the sides of your legs/thighs, your panty " +
				"line and below the naval.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 12) // 12 Underarm Wax
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Underarm Wax.jpg");
				CustomerPaymenttxt.Text = "150";
				TreatmentTitlelb.Text = "Treatment: Underarm Wax";
				TreatmentDescriptionlb.Text = "Waxing your armpits may be more painful than shaving, but it keeps your armpits hairless " +
				"for 4-6 weeks. You can reduce the pain and prevent ingrown hairs from occurring by preparing your armpits and using " +
				"the right kind of wax.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 13) // 13 Full Leg Wax
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Full Leg Wax.jpg");
				CustomerPaymenttxt.Text = "500";
				TreatmentTitlelb.Text = "Treatment: Full Leg Wax";
				TreatmentDescriptionlb.Text = "A full leg wax commonly comprises hair removal from the top of thighs to the base of the " +
				"ankles (front and back). A half leg wax typically eliminates hair from either just above the knees to the ankles, " +
				"or from the thighs to above the knees (front and back).";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 14) // 14 Full Arm Wax
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Full Arm Wax.jpg");
				CustomerPaymenttxt.Text = "500";
				TreatmentTitlelb.Text = "Treatment: Full Arm Wax";
				TreatmentDescriptionlb.Text = "A full arm wax will include everything from your shoulder downwards, including hands " +
				"and fingers if required. Underarm wax. For those who hate shaving, the underarm wax gets rid of all the hair in your " +
				"armpits.";
			}

			// Hair Treatments
			else if (CustomerTreatmentcbx.SelectedIndex == 15) // 15 Keratin
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Keratin.jpg");
				CustomerPaymenttxt.Text = "3000";
				TreatmentTitlelb.Text = "Treatment: Keratin";
				TreatmentDescriptionlb.Text = "Keratin Complex has been a popular hair smoothing service for over ten years and can " +
				"deliver smooth results for many weeks. Also known as the popular Brazilian Blowout, relaxers and keratin treatments " +
				"can transform hair from curly to straight.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 16) // 16 Scalp
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Scalp.jpg");
				CustomerPaymenttxt.Text = "3000";
				TreatmentTitlelb.Text = "Treatment: Scalp";
				TreatmentDescriptionlb.Text = "If a dry and itchy scalp is one of your hair woes, an in salon scalp treatment can be a " +
				"beneficial service that not only feels wonderful, it can substantially correct the scalp oil production and improve hair " +
				"growth. A scalp facial is a growing Japanese trend that is becoming widely popular due to the results of improved scalp " +
				"skin.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 17) // 17 Rebond
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Rebond.jpg");
				CustomerPaymenttxt.Text = "2500";
				TreatmentTitlelb.Text = "Treatment: Rebond";
				TreatmentDescriptionlb.Text = "Hair rebonding is a chemical process that changes your hair's natural texture and creates " +
				"a smooth, straight style. It's also called chemical straightening. Hair rebonding is typically performed by a licensed" +
				"cosmetologist at your local hair salon. This changes the way that your hair looks.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 18) // 18 Brazillian
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Brazillian.jpg");
				CustomerPaymenttxt.Text = "1500";
				TreatmentTitlelb.Text = "Treatment: Brazillian";
				TreatmentDescriptionlb.Text = "Brazilian Blowout is a specific brand of keratin treatment, a semi-permanent way to smooth " +
				"frizz, soften hair texture, and make hair more manageable and easy to style. As such, it won't take the kink and curl " +
				"out of hair. But it may have a slight straightening effect on wavy or otherwise lightly textured strands.";
			}
			else if (CustomerTreatmentcbx.SelectedIndex == 19) // 19 Detox
			{
				TreatmentPic.Image = Image.FromFile(@"C:\Users\Luxus\source\repos\BeautySalonSystem\BeautySalonSystem\BeautySalonSystem\Resources\Detox.jpg");
				CustomerPaymenttxt.Text = "1000";
				TreatmentTitlelb.Text = "Treatment: Detox";
				TreatmentDescriptionlb.Text = "Detox hair treatments get rid of the buildup on the hair shaft that results from too " +
				"much product usage or chemicals such as chlorine. By clarifying the hair shaft, a detox treatment improves the health " +
				"of the hair and scalp and can stimulate hair growth.";
			}
		}

        private void Inquirybtn_Click(object sender, EventArgs e)
        {

        }
    }
}
