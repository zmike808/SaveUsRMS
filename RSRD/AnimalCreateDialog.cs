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
    public partial class AnimalCreateDialog : Form
    {
        public AnimalCreateDialog()
        {
            InitializeComponent();
        }
        public Animal a = new Animal();
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            //if valid fill up new animal
            if (checkValidity())
            {
                a.breed = this.breedTextBox.Text;
                a.Name = this.nameTextBox.Text;
                a.color = this.ColorTextBox.Text;
                a.crossbreed = this.crossBreedTextBox.Text;
                a.dob = DateTime.Parse(this.dobTextBox.Text);
                a.dobIsEstimated = this.dobEstimateCheckBox.Checked;
                a.female = this.sexTestBox.Text == "female";
                a.sterilized = true;
                a.vacc = DateTime.Parse(this.vaccDateBox.Text);
                a.notes = this.richTextBox1.Text;
                

            }
            else 
            {
                MessageBox.Show(this, "Invalid Data");
            }
        }

        private bool checkValidity() 
        {
            return true;
        }


      
      
    }
}
