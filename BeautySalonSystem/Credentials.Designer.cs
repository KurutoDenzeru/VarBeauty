namespace BeautySalonSystem
{
	partial class Credentials
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Loginbtn = new System.Windows.Forms.Button();
			this.Usernametxt = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Passwordtxt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.Customerlink = new System.Windows.Forms.LinkLabel();
			this.Adminlink = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// Loginbtn
			// 
			this.Loginbtn.BackColor = System.Drawing.Color.Thistle;
			this.Loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Loginbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Loginbtn.Location = new System.Drawing.Point(493, 295);
			this.Loginbtn.Name = "Loginbtn";
			this.Loginbtn.Size = new System.Drawing.Size(277, 31);
			this.Loginbtn.TabIndex = 0;
			this.Loginbtn.Text = "Login";
			this.Loginbtn.UseVisualStyleBackColor = false;
			this.Loginbtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// Usernametxt
			// 
			this.Usernametxt.Location = new System.Drawing.Point(493, 176);
			this.Usernametxt.Name = "Usernametxt";
			this.Usernametxt.Size = new System.Drawing.Size(277, 25);
			this.Usernametxt.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Plum;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(417, 475);
			this.panel1.TabIndex = 3;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::BeautySalonSystem.Properties.Resources.New_Logo;
			this.pictureBox1.Location = new System.Drawing.Point(47, 45);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(307, 297);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::BeautySalonSystem.Properties.Resources.Close;
			this.pictureBox2.Location = new System.Drawing.Point(807, 12);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(31, 30);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 12;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(11, 352);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(401, 69);
			this.label2.TabIndex = 4;
			this.label2.Text = "Beauty Salon\r\nAppointment System";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(493, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(277, 57);
			this.label1.TabIndex = 5;
			this.label1.Text = "Sign In";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Passwordtxt
			// 
			this.Passwordtxt.Location = new System.Drawing.Point(493, 247);
			this.Passwordtxt.Name = "Passwordtxt";
			this.Passwordtxt.PasswordChar = '*';
			this.Passwordtxt.Size = new System.Drawing.Size(277, 25);
			this.Passwordtxt.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(493, 142);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(277, 31);
			this.label3.TabIndex = 8;
			this.label3.Text = "Username:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(493, 213);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(277, 31);
			this.label4.TabIndex = 9;
			this.label4.Text = "Password:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Customerlink
			// 
			this.Customerlink.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Customerlink.LinkColor = System.Drawing.Color.Black;
			this.Customerlink.Location = new System.Drawing.Point(493, 353);
			this.Customerlink.Name = "Customerlink";
			this.Customerlink.Size = new System.Drawing.Size(277, 21);
			this.Customerlink.TabIndex = 10;
			this.Customerlink.TabStop = true;
			this.Customerlink.Text = "Customer";
			this.Customerlink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Customerlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Adminlink
			// 
			this.Adminlink.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Adminlink.LinkColor = System.Drawing.Color.Black;
			this.Adminlink.Location = new System.Drawing.Point(493, 386);
			this.Adminlink.Name = "Adminlink";
			this.Adminlink.Size = new System.Drawing.Size(277, 21);
			this.Adminlink.TabIndex = 11;
			this.Adminlink.TabStop = true;
			this.Adminlink.Text = "Admin";
			this.Adminlink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Adminlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 442);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(409, 24);
			this.label5.TabIndex = 14;
			this.label5.Text = "© 2021 Var Beauty, Beauty Salon Appointment System. All Rights Reserved.";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Credentials
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.OldLace;
			this.ClientSize = new System.Drawing.Size(850, 475);
			this.Controls.Add(this.Adminlink);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.Customerlink);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Passwordtxt);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Usernametxt);
			this.Controls.Add(this.Loginbtn);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Credentials";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Loginbtn;
		private System.Windows.Forms.TextBox Usernametxt;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Passwordtxt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel Customerlink;
		private System.Windows.Forms.LinkLabel Adminlink;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label5;
	}
}

