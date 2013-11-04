namespace RSRD
{
	partial class EmployeeLoginWindow
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
			this.button1 = new System.Windows.Forms.Button();
			this.rememberme = new System.Windows.Forms.CheckBox();
			this.username = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 113);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Login";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// rememberme
			// 
			this.rememberme.AutoSize = true;
			this.rememberme.Location = new System.Drawing.Point(12, 90);
			this.rememberme.Name = "rememberme";
			this.rememberme.Size = new System.Drawing.Size(95, 17);
			this.rememberme.TabIndex = 1;
			this.rememberme.Text = "Remember Me";
			this.rememberme.UseVisualStyleBackColor = true;
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(12, 25);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(100, 20);
			this.username.TabIndex = 2;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(12, 64);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(100, 20);
			this.password.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Password";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Username";
			// 
			// EmployeeLoginWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(145, 152);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.password);
			this.Controls.Add(this.username);
			this.Controls.Add(this.rememberme);
			this.Controls.Add(this.button1);
			this.Name = "EmployeeLoginWindow";
			this.Text = "EmployeeLogin";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox rememberme;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}