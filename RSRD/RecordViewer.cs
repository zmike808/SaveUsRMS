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
        stringBox  i = new stringBox(100, 100, 20, 10, "test");
        intBox j = new intBox(100, 200, 20, 10, 22);
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
            List<KeyValuePair<string, Point>> l = new List<KeyValuePair<string, Point>>();
            l.Add(new KeyValuePair<string, Point>("tenessee", new Point(50, 50)));
            list.Add(i);
            list.Add(j);
            selected = new Record("georgia", list, l);
            selected.timeStamp = new DateTime(2013, 2, 15);
            showRecord(selected);
        }


        /// <summary>
        /// creates a tab and adds all of the record information to it
        /// </summary>
        /// <param name="r"></param>
        private void showRecord(Record r) 
        {
            
            
            TabPage t = new TabPage(r.formName + " " + r.timeStamp.ToShortDateString());
            t.BackColor = Color.White;

            foreach (FieldBox f in r.values) 
            {

                TextBox textbox = new TextBox();
                textbox.Top = f.y_pos;
                textbox.Left = f.x_pos;
                textbox.TextChanged+= new EventHandler(TextBox_Changed);
                textbox.Text = Convert.ToString(f.value);
                t.Controls.Add(textbox);
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
