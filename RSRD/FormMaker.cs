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


        Form1 caller;
        bool templateLoaded = false;

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
        }






        public void loadTemplate(Record r)
        {

            foreach (FieldBox f in r.values)
            {

                TextBox textbox = new TextBox();
                textbox.Top = f.y_pos;
                textbox.Left = f.x_pos;
                Label l = new Label();
                l.Text = f.label;
                l.Top = f.y_pos;
                l.Left = f.x_pos - 50;

                pictureBox1.Controls.Add(textbox);
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
                RecordTextBox r = new RecordTextBox();
                r.Left = 100;
                r.Top = 20;
                r.Text = "100";
                pictureBox1.Controls.Add(r);
            }
            else 
            {
                MessageBox.Show("Template already chosen");
            }
        }

        /// <summary>
        /// creates boxes from the list and adds them to the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldboxListBox_DragLeave(object sender, EventArgs e)
        {

        }
    }
}
