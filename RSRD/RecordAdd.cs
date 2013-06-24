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
        public RecordAdd()
        {
            InitializeComponent();
            toolStripComboBox1.Items.Add("Euthenization");
            toolStripComboBox1.Items.Add("Sterilization");
            toolStripComboBox1.Items.Add("Adoption");
        }

        
        /// <summary>
        /// used to start the form with a few  record tabs already open
        /// usefull for creating a new animal or an event that needs more than one form to be recorded
        /// increases ease for user
        /// </summary>
        /// <param name="defaults"></param>
        public RecordAdd(Record[] defaults) 
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

        }


        /// <summary>
        /// takes the selected tab and checks if the information in it is valid, and then saves it to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

        }



    }
}
