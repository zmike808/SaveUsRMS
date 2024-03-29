﻿using System;
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
        #region local Variables

        Record selected;
        stringBox  i = new stringBox(100, 100, 20, 10, "test");
        intBox j = new intBox(100, 200, 20, 10, 22);
        List<FieldBox> list = new List<FieldBox>();
        public Form1 f_;


        #endregion

        #region constructors

        public RecordViewer()
        {
            InitializeComponent();
            //sets it relatively sized to A4 iso standard, should be customizable later
            Graphics g = this.CreateGraphics();
            int width = (int)Math.Round(210 / 25.4 * g.DpiX);
            int height = (int)Math.Round(297 / 25.4 * g.DpiY);
            

            this.tabControl1.Size = new Size(width, height);

            //needs to be re-anchored to allow autoscrolling
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
        }

        //method to take Animal ID and populate the record list box with it's records
        //check the animal for it's record types, and then check the valid tables for the animals records
        public RecordViewer(int animalID) 
        {
            InitializeComponent();
            //sets it relatively sized to A4 iso standard, should be customizable later
            Graphics g = this.CreateGraphics();
            int width = (int)Math.Round(210 / 25.4 * g.DpiX);
            int height = (int)Math.Round(297 / 25.4 * g.DpiY);

            this.tabControl1.Size = new Size(width, height);

            //needs to be re-anchored to allow autoscrolling
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
        }

        #endregion

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
                textbox.TextChanged += new EventHandler(TextBox_Changed);
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

        public void initializeRecordTypesList()
        {
            foreach (Record blank in f_.blankRecords)
            {
                checkedListBox1.Items.Add(blank.formName);
            }
        }

        #region GUI Events

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
        /// takes new information from text boxes and changes values within the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Changed(object sender, System.EventArgs e)
        {
            TextBox t = (TextBox)sender;

        }

        #endregion

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu c = new ContextMenu();
                MenuItem close = new MenuItem();
                close.Text = "&Close Tab";
                close.Click += new EventHandler(close_Click);
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
