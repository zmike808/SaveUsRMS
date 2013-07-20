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
        public RecordAdd(Form1 f)
        {
            InitializeComponent();
            blanks = f.blankRecords;
            caller = f;
            foreach (Record r in f.blankRecords)
            {
                toolStripComboBox1.Items.Add(r.formName);
            }
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

            foreach (Record r in defaults) 
            {
                newRecordTab(r);
            }

        }




        /// <summary>
        /// allows for multiple records to be filled in at the same time by creating a new tab
        /// </summary>
        /// <param name="r"></param>
        public void newRecordTab(Record r)
        {
            TabPage t = new TabPage(r.formName + " " + r.timeStamp.ToShortDateString());
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
            tabControl1.TabPages.Add(t);
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
                    else{rf.BackColor = Color.White;} 
                }
            }
            return b;
        }

        /// <summary>
        /// takes the selected tab and checks if the information in it is valid, and then saves it to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkDataValidity())
            {
                MessageBox.Show("VALID DATA");
                RecordTab save = tabControl1.SelectedTab as RecordTab;
              /*find the iteration of this record for the animal, put it after the + sign
               *save.rec.saveData(caller.SelectedAnimal.ID + );
               */
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




    }
}
