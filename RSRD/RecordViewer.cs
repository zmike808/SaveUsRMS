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
        public RecordViewer()
        {
            InitializeComponent();
        }

        //method to take Animal ID and populate the record list box with it's records
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

        



    }
}
