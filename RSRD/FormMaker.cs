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
    public partial class FormMaker : Form
    {

        //the control that is currently being moved
        private Control activeControl;
        //the point that the control was at previously
        private Point previousLocation;


        Form1 caller;
        bool templateLoaded = false;

        //types of the fieldboxes.
        //if the control isn't a fieldbox, i will just say its an intbox
        List<FieldBox.boxtypes> controltypes = new List<FieldBox.boxtypes>();

        Record rec;

        public FormMaker(Form1 f)
        {
            caller = f;
            InitializeComponent();
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





        /// <summary>
        /// loads a blank record and allows user to manipulate fieldbox text, as well as size and placement.
        /// </summary>
        /// <param name="r"></param>
        public void loadTemplate(Record r)
        {
            rec = new Record(r.formName);
            foreach (FieldBox f in r.values)
            {

                TextBox textbox = new TextBox();
                textbox.Top = f.y_pos;
                textbox.Left = f.x_pos;

                textbox.MouseDown += new MouseEventHandler(textbox_MouseDown);
                textbox.MouseMove += new MouseEventHandler(textbox_MouseMove);
                textbox.MouseUp += new MouseEventHandler(textbox_MouseUp);
                textbox.ReadOnly = true;
                controltypes.Add(f.type);
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
                controltypes.Add(FieldBox.boxtypes.intBox);
                pictureBox1.Controls.Add(l);
            }
            templateLoaded = true;
        }


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
    
            switch(fieldboxListBox.SelectedIndex)
            {
                case 0:
                    controltypes.Add(FieldBox.boxtypes.intBox);
                    break;
                case 1:
                    controltypes.Add(FieldBox.boxtypes.stringBox);
                    break;
                case 2:
                    controltypes.Add(FieldBox.boxtypes.doubBox);
                    break;
                case 3:
                    controltypes.Add(FieldBox.boxtypes.dateTimeBox);
                    break;
                default:
                    controltypes.Add(FieldBox.boxtypes.intBox);
                    choseLabel = true;
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
                controltypes.Add(FieldBox.boxtypes.intBox);
                pictureBox1.Controls.Add(l);
            }
            else 
            {
                TextBox textbox = new TextBox();
                textbox.Location = new Point(100, 100);
                textbox.ReadOnly = true;
                textbox.MouseDown += new MouseEventHandler(textbox_MouseDown);
                textbox.MouseMove += new MouseEventHandler(textbox_MouseMove);
                textbox.MouseUp += new MouseEventHandler(textbox_MouseUp);
                pictureBox1.Controls.Add(textbox); 
            }
           
        }




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

            int dy = e.Location.Y - previousLocation.Y;
            int dx = e.Location.X - previousLocation.X;
            
            //checks for box collisions
            foreach (Control c in pictureBox1.Controls)
            {
                if (c == activeControl)
                    continue;



                if (activeControl.Bounds.IntersectsWith(c.Bounds))
                {
                    #region mings code

                    //bool rc = location.X + activeControl.Width + 1 >= c.Location.X;
                    //bool lc = location.X <= c.Location.X + c.Width + 1;
                    //bool bc = location.Y + activeControl.Height + 1 >= c.Location.Y;
                    //bool tc = location.Y <= c.Location.Y + c.Height + 1;

                    //bool up = (Math.Abs(dx) < Math.Abs(dy));

                    //bool vc = (location.Y + activeControl.Height + 1 >= c.Location.Y &&
                    //    location.Y + activeControl.Height <= c.Location.Y + c.Height + 1)
                    //    || (location.Y >= c.Location.Y && location.Y <= c.Location.Y + c.Height);
                    //bool hc = (location.X + activeControl.Width + 1 >= c.Location.X &&
                    //    location.X + activeControl.Width + 1 <= c.Location.X + c.Width + 1)
                    //    || (location.X <= c.Location.X + c.Width + 1 && location.X <= c.Location.X);

                    //if (dx > 0 && rc && (vc))
                    //{
                    //    location.X = c.Location.X - activeControl.Width - 1;
                    //    continue;
                    //}
                    //else if (dx < 0 && lc && (vc))
                    //{
                    //    location.X = c.Location.X + activeControl.Width + 1;
                    //    continue;
                    //}
                    //if (dy > 0 && bc && (hc))
                    //{
                    //    location.Y = c.Location.Y - activeControl.Height - 1;
                    //    continue;
                    //}
                    //else if (dy < 0 && tc && (hc))
                    //{
                    //    location.Y = c.Location.Y + activeControl.Height + 1;
                    //    continue;
                    //}

                    #endregion
                }
            }

            activeControl.Location = location;
        }

        public void textbox_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
            Cursor = Cursors.Default;
        }

        #endregion




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
            int count = 0;
            foreach (Control l in pictureBox1.Controls)
            {
                if (l is Label) 
                {
                    KeyValuePair<string, Point> k = new KeyValuePair<string, Point>(l.Text, l.Location);
                    rec.labels.Add(k);
                    
                }
                else if (l is TextBox) 
                {
                    switch(controltypes[count])
                    {
                        case FieldBox.boxtypes.intBox:
                            intBox i = new intBox(l.Location.X, l.Location.Y, l.Width, l.Height, 0);
                            rec.values.Add(i);
                            break;
                        case FieldBox.boxtypes.doubBox:
                            doubBox d = new doubBox(l.Location.X, l.Location.Y, l.Width, l.Height, 0);
                            rec.values.Add(d);
                            break;
                        case FieldBox.boxtypes.stringBox:
                            stringBox s = new stringBox(l.Location.X, l.Location.Y, l.Width, l.Height, "null");
                            rec.values.Add(s);
                            break;
                        case FieldBox.boxtypes.dateTimeBox:
                            dateTimeBox dt = new dateTimeBox(l.Location.X, l.Location.Y, l.Width, l.Height, DateTime.Now);
                            rec.values.Add(dt);
                            break;
                    }     
                }
                count++;
                
            }
            foreach (FieldBox f in rec.values) 
            {
                Console.WriteLine(f.typeToString());
            }
            rec.FinalizeNewRecord();
            caller.initializeRecords();
        }

    }
}
