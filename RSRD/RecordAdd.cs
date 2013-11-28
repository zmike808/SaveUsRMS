using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSRD
{
    public partial class RecordAdd : Form
    {
        List<Record> blanks;
        Form1 caller;
        Animal currentAnimal;
		List<Record> displayedRecords;
        #region constructors
        /// <summary>
        /// basic constructor, loads no forms 
        /// </summary>
        /// <param name="f"></param>
        public RecordAdd(Form1 f)
        {
            InitializeComponent();
			displayedRecords = new List<Record>();
            blanks = f.blankRecords;
            caller = f;
			currentAnimal = f.SelectedAnimal;
            foreach (Record r in f.blankRecords)
            {
                toolStripComboBox1.Items.Add(r.formName);
            }

            #region RecordSizing

            //sets it relatively sized to A4 iso standard, should be customizable later
            Graphics g = this.CreateGraphics();
            int width = (int)Math.Round(210 / 25.4 * g.DpiX);
            int height = (int)Math.Round(297 / 25.4 * g.DpiY);

            this.tabControl1.Size = new Size(width, height);

            adjustRecordPlacement();

            //needs to be re-anchored to allow autoscrolling
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            #endregion
        }

        public RecordAdd(Form1 f, Animal a)
        {
            InitializeComponent();
            displayedRecords = new List<Record>();
            blanks = f.blankRecords;
            caller = f;
            currentAnimal = f.SelectedAnimal;
            foreach (Record r in f.blankRecords)
            {
                toolStripComboBox1.Items.Add(r.formName);
            }
            currentAnimal = a;
            this.Text = "Add record to ID: " + currentAnimal.ID + ", Name: " + currentAnimal.Name;

            #region RecordSizing

            //sets it relatively sized to A4 iso standard, should be customizable later
            Graphics g = this.CreateGraphics();
            int width = (int)Math.Round(210 / 25.4 * g.DpiX);
            int height = (int)Math.Round(297 / 25.4 * g.DpiY);

            this.tabControl1.Size = new Size(width, height);

            adjustRecordPlacement();

            //needs to be re-anchored to allow autoscrolling
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            #endregion
        }


        /// <summary>
        /// used to start the form with a few  record tabs already open
        /// usefull for creating a new animal or an event that needs more than one form to be recorded
        /// increases ease for user
        /// </summary>
        /// <param name="defaults"></param>
        public RecordAdd(Form1 f, Record[] defaults) 
        {
            InitializeComponent();
            caller = f;
            foreach (Record r in defaults) 
            {
                newRecordTab(r);
            }

        }


        public RecordAdd(Form1 f, Record[] defaults, Animal a)
        {
            InitializeComponent();
            caller = f;
            foreach (Record r in defaults)
            {
                newRecordTab(r);
            }
            currentAnimal = a;
            this.Text = "Add record to ID: " + currentAnimal.ID + ", Name: " + currentAnimal.Name;

        }

        #endregion

        /// <summary>
        /// allows for multiple records to be filled in at the same time by creating a new tab
        /// </summary>
        /// <param name="r"></param>
        public void newRecordTab(Record r)
        {
			TabPage t = new TabPage(r.formName);
            t.AutoScroll = true;
            t.BackColor = Color.White;

            int count = 0;
            foreach (FieldBox f in r.values) 
            {
                RecordTextBox textbox = new RecordTextBox(r, count);
                textbox.Top = f.y_pos;
                textbox.Left = f.x_pos;
                textbox.TextChanged+= new EventHandler(TextBox_Changed);
                t.Controls.Add(textbox);
                count++;
            }
            foreach (KeyValuePair<string, Point> k in r.labels)
            {
                Label l = new Label();
                l.Text = k.Key;
                l.Location = k.Value;
                t.Controls.Add(l);
            }
			t.Tag = tabControl1.TabPages.Count;
            tabControl1.TabPages.Add(t);
			displayedRecords.Add(r);
            tabControl1.TabPages[0].Show();
        }

        /// <summary>
        /// makes sure each textbox is filled with valid data
        /// if not, changes textbox color to red
        /// </summary>
        /// <returns></returns>
        public bool checkDataValidity()
        {
            bool b = true;
            foreach (Control c in tabControl1.SelectedTab.Controls) 
            {
                if (c is RecordTextBox) 
                {
                    RecordTextBox rf = c as RecordTextBox;
                    if (rf.Text == "") 
                    {
                        rf.BackColor = Color.Red;
                        b = false; 
                    }
                    else if (!rf.attachedFieldBox.isDataValid(rf.Text))
                    {
                        rf.BackColor = Color.Red;
                        b = false;
                    }
                    else
					{
						rf.BackColor = Color.White;
					} 
                }
            }
            return b;
        }

        /// <summary>
        /// makes sure that record is always centered horizontally, or scrollable
        /// </summary>
        private void adjustRecordPlacement()
        {
            if (MainRecordPanel.Width > tabControl1.Width + 10)
            {
                tabControl1.Location = new Point(((MainRecordPanel.Width - tabControl1.Width) / 2), tabControl1.Location.Y);
            }
            else
            {
                tabControl1.Location = new Point(1, tabControl1.Location.Y);
            }
            //needs to be re-anchored to allow autoscrolling
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
        }

        #region GUI Events

        /// <summary>
        /// takes the selected tab and checks if the information in it is valid, and then saves it to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkDataValidity())
            {
             //   MessageBox.Show("VALID DATA");
				//so messy really the way we're handling this...I DONT EVEN...JUST INHERET TAB AND MAKE A RECORDTAB CLASS PROPERLY
				Record currentRecord = displayedRecords[(int)tabControl1.SelectedTab.Tag];
				MySQLHandler dbh = new MySQLHandler();
				List<dynamic> colvals = new List<dynamic>();
				colvals.Add(dbh.getIteration(currentRecord.formName,currentAnimal.ID));
				colvals.Add(currentAnimal.ID);
				colvals.Add(DateTime.Now);
				foreach (Control c in tabControl1.SelectedTab.Controls)
				{
					if (c is RecordTextBox)
					{
                        RecordTextBox temp = (RecordTextBox)c;
						var fb = temp.attachedFieldBox;
						colvals.Add(fb.value);
					}
				}
                dbh.insertAnimalToRecord(currentRecord.formName, colvals.Count, colvals);

            }
            else 
            {
                MessageBox.Show("INVALID DATA");
            }
        }

        private void TextBox_Changed(object sender, System.EventArgs e)
        {
            RecordTextBox t = sender as RecordTextBox;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Record r = blanks[toolStripComboBox1.SelectedIndex];
            r.timeStamp = DateTime.Now;
            newRecordTab(r);
        }

        private void RecordAdd_Resize(object sender, EventArgs e)
        {
            adjustRecordPlacement();
        }

        #endregion

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                ContextMenu c = new ContextMenu();
                MenuItem close = new MenuItem();
                close.Text = "&Close Tab";
                close.Click +=new EventHandler(close_Click);
                c.MenuItems.Add(close);
                tabControl1.ContextMenu = c;
                tabControl1.ContextMenu.Show(tabControl1, e.Location);
            }			
        }

        void close_Click(object sender, EventArgs e) 
        {
            MenuItem p = (MenuItem)sender;
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        } 
        


    }
}
