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
    public partial class FormMaker : Form
    {

        #region local variables

        //the control that is currently being moved
        private Control activeControl;
        //the point that the control was at previously
        private Point previousLocation;

        public List<TagManager> taglist;

        Form1 caller;
        bool templateLoaded = false;

        //need to do an overhaul to make fieldboxes directly used, and have thier respective tages accessible

        Record rec;

        #endregion


        #region constructors

        public FormMaker(Form1 f)
        {
            caller = f;
            InitializeComponent();

            //sets it relatively sized to A4 iso standard, should be customizable later
            Graphics g = this.CreateGraphics();
            int width = (int)Math.Round(210 / 25.4 * g.DpiX);
            int height = (int)Math.Round(297 / 25.4 * g.DpiY);

            this.pictureBox1.Size = new Size(width, height);
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));

            foreach (Record r in f.blankRecords) 
            {
             templateListBox.Items.Add(r.formName);

            }
            foreach (FieldBox.boxtypes type in Enum.GetValues(typeof(FieldBox.boxtypes)))
            {
                fieldboxListBox.Items.Add(type);
            }
            fieldboxListBox.Items.Add("Label");
        }


        #endregion


        /// <summary>
        /// loads a blank record and allows user to manipulate fieldbox text, as well as size and placement.
        /// </summary>
        /// <param name="r"></param>
        public void loadTemplate(Record r)
        {
            rec = new Record(r.formName);
            foreach (FieldBox f in r.values)
            {
                RecordTextBox textbox = new RecordTextBox();
                textbox.Top = f.y_pos;
                textbox.Left = f.x_pos;
                textbox.Text = f.tag.tagName;
                textbox.MouseDown += new MouseEventHandler(textbox_MouseDown);
                textbox.MouseMove += new MouseEventHandler(textbox_MouseMove);
                textbox.MouseUp += new MouseEventHandler(textbox_MouseUp);
                textbox.ReadOnly = true;
                textbox.attachedFieldBox = f;
                pictureBox1.Controls.Add(textbox);
            }

            foreach (KeyValuePair<string, Point> k in r.labels)
            {
                Label l = new Label();
                l.Text = k.Key;
                l.Location = k.Value;
                l.MouseDown += new MouseEventHandler(textbox_MouseDown);
                l.MouseMove += new MouseEventHandler(textbox_MouseMove);
                l.MouseUp += new MouseEventHandler(textbox_MouseUp);
                pictureBox1.Controls.Add(l);
            }
            templateLoaded = true;
        }

        #region general GUI events

        /// <summary>
        /// loads a template form to be used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void templateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!templateLoaded)
            {
                loadTemplate(caller.blankRecords[templateListBox.SelectedIndex]);
            }
            else
            {
                MessageBox.Show("Template already chosen");
            }
        }

        /// <summary>
        /// takes chosen components from the list and adds them to the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldboxListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool choseLabel = false;
            FieldBox newbox;
            switch(fieldboxListBox.SelectedIndex)
            {
                case 0:
                    newbox = new intBox();
                    break;
                case 1:
                    newbox = new stringBox();
                    break;
                case 2:
                    newbox = new doubBox();
                    break;
                case 3:
                    newbox = new dateTimeBox();
                    break;
                default:
                    choseLabel = true;
                    newbox = new intBox();
                    break;
            }
            if (choseLabel)
            {
                Label l = new Label();
                FieldboxCreationForm f = new FieldboxCreationForm();
                f.ShowDialog();
                f.Dispose();
                l.Text = f.text;
                l.Location = new Point(50, 100);
                Graphics g = this.CreateGraphics();
                SizeF size = g.MeasureString(l.Text, l.Font);
                l.Size = new Size((int)size.Width+5, (int)size.Height+1);
                l.MouseDown += new MouseEventHandler(textbox_MouseDown);
                l.MouseMove += new MouseEventHandler(textbox_MouseMove);
                l.MouseUp += new MouseEventHandler(textbox_MouseUp);
                pictureBox1.Controls.Add(l);
            }
            else 
            {
                tagselect t = new tagselect(taglist);
                t.ShowDialog();
                newbox.tag = t.selected;
                RecordTextBox textbox = new RecordTextBox();
                textbox.attachedFieldBox = newbox;
                textbox.Text = newbox.tag.tagName;
                textbox.Location = new Point(100, 100);
                textbox.ReadOnly = true;
                textbox.MouseDown += new MouseEventHandler(textbox_MouseDown);
                textbox.MouseMove += new MouseEventHandler(textbox_MouseMove);
                textbox.MouseUp += new MouseEventHandler(textbox_MouseUp);
                textbox.KeyDown += new KeyEventHandler(Key_Down);
                pictureBox1.Controls.Add(textbox);
            }
           
        }

        #endregion


        #region Drag Components

        public void textbox_MouseDown(object sender, MouseEventArgs e)
        {
            activeControl = sender as Control;
            previousLocation = e.Location;
            Cursor = Cursors.Hand;
        }
        public void textbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender)
                return;
            var location = activeControl.Location;

            //bounds the components to the picturebox
            int x = (location.X <= 1 && (e.Location.X - previousLocation.X) < 0)
                ? 0 : (location.X + activeControl.Width + 1 > pictureBox1.Width -1
                && (e.Location.X - previousLocation.X) > 0) ? 0 : e.Location.X - previousLocation.X;
            int y = (location.Y <= 1 && (e.Location.Y - previousLocation.Y) < 0)
                ? 0 : (location.Y + activeControl.Height + 1 > pictureBox1.Height -1
                && (e.Location.Y - previousLocation.Y) > 0) ? 0 : e.Location.Y - previousLocation.Y;

            //checks if move is out of boundaries
            location.Offset(x, y);
            if (location.X < 0) { location.X = 1; }
            else if (location.X + activeControl.Width + 1 > pictureBox1.Width) 
            {
                location.X = pictureBox1.Width - activeControl.Width - 1;
            }
            if (location.Y < 0) { location.Y = 1; }
            else if (location.Y + activeControl.Height + 1 > pictureBox1.Height)
            {
                location.Y = pictureBox1.Height - activeControl.Height - 1;
            }
            activeControl.Location = location;
        }

        public void textbox_MouseUp(object sender, MouseEventArgs e)
        {
            var location = activeControl.Location;
            //checks for box collisions
            List<Control> collisions = new List<Control>();
            foreach (Control c in pictureBox1.Controls)
            {
                if (c == activeControl)
                    continue;

                if (activeControl.Bounds.IntersectsWith(c.Bounds))
                {
                    collisions.Add(c);
                }
            }
            while (collisions.Count > 0)
            {
                foreach (Control c in collisions)
                {
                    int axc = location.X + (activeControl.Width / 2);
                    int ayc = location.Y + (activeControl.Height / 2);
                    int cxc = c.Location.X + (c.Width / 2);
                    int cyc = c.Location.Y + (c.Height / 2);

                    int xdiff = axc - cxc;
                    int ydiff = ayc - cyc;

                    if (Math.Abs(xdiff) >= Math.Abs(ydiff))
                    {
                        if (xdiff >= 0)
                        {
                            location.X = c.Location.X + c.Width + 1;
                            break;
                        }
                        else
                        {
                            location.X = c.Location.X - activeControl.Width - 1;
                            break;
                        }
                    }
                    else
                    {
                        if (ydiff >= 0)
                        {
                            location.Y = c.Location.Y + c.Height + 1;
                            break;
                        }
                        else
                        {
                            location.Y = c.Location.Y - activeControl.Height - 1;
                            break;
                        }
                    }
                }
                activeControl.Location = location;
                collisions.Clear();
                foreach (Control c in pictureBox1.Controls)
                {
                    if (c == activeControl)
                        continue;

                    if (activeControl.Bounds.IntersectsWith(c.Bounds))
                    {
                        collisions.Add(c);
                    }
                }
            }
            activeControl = null;
            Cursor = Cursors.Default;
        }

        public void Key_Down(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (activeControl != null)
                { 
                    activeControl.Hide();
                    activeControl.Dispose();
                }
            }
        }


        #endregion



        void addImage() 
        {
            OpenFileDialog f = new OpenFileDialog();
            
            string tempPath = "";

            if (f.ShowDialog() == DialogResult.OK)
            {
                tempPath = f.FileName; // prints path
                Console.WriteLine(tempPath);
            }

        }


        /// <summary>
        /// collects all of the created data and saves the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rec == null)
            {
                //stupid simple file naming, should be replaced with save file dialog
                FieldboxCreationForm f = new FieldboxCreationForm();
                f.ShowDialog();
                f.Dispose();
                rec = new Record(f.text);
            }
            else 
            {
                FieldboxCreationForm f = new FieldboxCreationForm();
                f.ShowDialog();
                f.Dispose();
                rec.formName = f.text;
            }
            foreach (dynamic l in pictureBox1.Controls)
            {
                if (l is Label) 
                {
                    KeyValuePair<string, Point> k = new KeyValuePair<string, Point>(l.Text, l.Location);
                    rec.labels.Add(k);
                    
                }
                else if (l is RecordTextBox) 
                {

                    l.attachedFieldBox.x_pos = l.Location.X;
                    l.attachedFieldBox.x_pos = l.Location.X;
                    l.attachedFieldBox.length = l.Width;
                    l.attachedFieldBox.height = l.Height;
                    rec.values.Add(l.attachedFieldBox);
                }
                
                
            }

            foreach (FieldBox f in rec.values) 
            {
                Console.WriteLine(f.typeToString());
            }
            rec.FinalizeNewRecord();
            caller.initializeRecords();
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addImage();
        }

    }
}
