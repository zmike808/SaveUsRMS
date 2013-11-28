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
    public partial class tagselect : Form
    {
        public TagManager selected = null;

        public tagselect()
        {
            InitializeComponent();
        }


        public tagselect(List<TagManager> tags) 
        {
            InitializeComponent();
            listBox1.DataSource = tags;
            listBox1.DisplayMember = "tagName";
            listBox1.ClearSelected();
        }

        //tag is selected
        private void button1_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                this.Hide();
                this.Dispose();
            }
            else 
            {
                MessageBox.Show("No Tag Selected");
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (TagManager)listBox1.SelectedItem;
        }


    }
}
