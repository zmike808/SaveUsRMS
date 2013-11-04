using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSRD
{
	public partial class EmployeeLoginWindow : Form
	{
		private string currentUser;
		private string loginInfo;
		/// <summary>
		/// used for setting/transfering the currentUser to form1.cs
		/// </summary>
		/// <returns>the current</returns>
		public string getCurrentUser()
		{
			return this.currentUser;
		}

		public EmployeeLoginWindow()
		{
			loginInfo = "loginInfo.dat";
			
			if (File.Exists(loginInfo))
			{
				List<string> lines = File.ReadAllLines(loginInfo).ToList<string>();
				if (!(lines.Count == 2 && verifyUser(lines[0].ToLower(), lines[1], true))) //short-circuit evaluation so good
				{

					MessageBox.Show("Error loading pre-exisiting login info...");
				}
			}
			else
			{
				this.currentUser = "";
				InitializeComponent();
				password.UseSystemPasswordChar = true;
			}
			
				
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.username.Text != null && this.password.Text != null && verifyUser(this.username.Text.ToLower(),this.password.Text,false)) //short-circuit evaluation ftw
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private bool verifyUser(string uname, string pass, bool isHash)
		{
			if (uname == null || pass == null)
			{
				return false;
			}

			dbEntities db = new dbEntities();
			var employees = from user in db.EmployeeLogins where user.username == uname select user;
			try
			{
				foreach (var employee in employees)
				{
					//employee.username should always equal uname since thats how we selected the rows...but just double checking?
					if (isHash && employee.username == uname && pass == employee.password) 
					{
						currentUser = employee.username;
						return true;
					}
					//employee.username should always equal uname since thats how we selected the rows...but just double checking?
					else if (employee.username == uname && SimpleHash.VerifyHash(pass, "SHA256", employee.password))
					{
						currentUser = employee.username;
						if (rememberme.Checked)
						{
							if (File.Exists(loginInfo))
							{
								File.Delete(loginInfo);
							}

							string[] lines = { uname, employee.password };
							File.WriteAllLines(loginInfo, lines);
						}
						MessageBox.Show("user verified!");
						return true;
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Employee Login Failure! Something went wrong!");
			}

			return createUser(uname, pass);

		}
		/// <summary>
		/// create a new user if attempted user info doesnt exist
		/// will be more formal/proper later
		/// </summary>
		/// <param name="uname"></param>
		/// <param name="pass"></param>
		/// <returns></returns>
		private bool createUser(string uname, string pass)
		{
			dbEntities db = new dbEntities();
			EmployeeLogin newEmployee = new EmployeeLogin();
			newEmployee.username = uname;
			newEmployee.password = SimpleHash.ComputeHash(pass, "SHA256", null);
			db.EmployeeLogins.AddObject(newEmployee);

			try
			{
				if (db.SaveChanges() > 0)
				{
					currentUser = uname;

					//just save the login info to a local file by default
					if (File.Exists(loginInfo))
					{
						File.Delete(loginInfo);
					}

					string[] lines = { uname, newEmployee.password };
					File.WriteAllLines(loginInfo, lines);
					return true;
				}

			}
			catch (Exception e)
			{
				MessageBox.Show("Employee Login Failure! Something went wrong!");
			}
			MessageBox.Show("Could not create a new employee! Something went wrong!");

			return false;
		}
	}
}
