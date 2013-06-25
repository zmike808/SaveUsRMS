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
    public partial class RecordViewer : Form
    {

        Record selected;
        stringBox  i = new stringBox("alabama", 100, 100, 20, 10, "test");
        intBox j = new intBox("tennesee", 100, 200, 20, 10, 22);
        List<FieldBox> list = new List<FieldBox>();

        public RecordViewer()
        {
            InitializeComponent();
        }

        //method to take Animal ID and populate the record list box with it's records
        //check the animal for it's record types, and then check the valid tables for the animals records
        public RecordViewer(int animalID) 
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.Add(i);
            list.Add(j);
            selected = new Record("georgia", list);
            selected.timeStamp = new DateTime(2013, 2, 15);
            showRecord(selected);
        }

        private void showRecord(Record r) 
        {
            
            //creates a tab and adds all of the record information to it
            TabPage t = new TabPage(r.formName + " " + r.timeStamp.ToShortDateString());

            foreach (FieldBox f in r.values) 
            {
                TextBox textbox = new TextBox();
                textbox.Top = f.y_pos;
                textbox.Left = f.x_pos;
                textbox.TextChanged+= new EventHandler(TextBox_Changed);
                textbox.Text = Convert.ToString(f.value);
                Label l = new Label();
                l.Text = f.label;
                l.Top = f.y_pos;
                l.Left = f.x_pos - 50;

                t.Controls.Add(textbox);
                t.Controls.Add(l);
            }
            tabControl1.TabPages.Add(t);
            tabControl1.TabPages[0].Show();
            
        }

        /// <summary>
        /// takes new information from text boxes and changes values within the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Changed(object sender, System.EventArgs e)
        {
            TextBox t = (TextBox)sender;
            
        }

    }
}
