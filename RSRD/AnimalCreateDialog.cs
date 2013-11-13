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
		public dbanimal a;
        public AnimalCreateDialog()
        {
            InitializeComponent();
			dbEntities db = new dbEntities();
			var animals = from e in db.dbanimals
						  where e.ID > 0
						  select e;
			int lastID = animals.Max(e => e.ID);
			a = dbanimal.Createdbanimal(lastID + 1);
        }
		
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            //if valid fill up new animal
            if (checkValidity())
            {
                a.breed = this.breedTextBox.Text;
                a.name = this.nameTextBox.Text;
                a.color = this.ColorTextBox.Text;
                a.crossbreed = this.crossBreedTextBox.Text;
                a.DateofBirth = DateTime.Parse(this.dobTextBox.Text);
                a.dobIsEstimated = this.dobEstimateCheckBox.Checked;
                a.gender = this.sexTestBox.Text;
                a.sterilized = true;
                a.vaccinationDate = DateTime.Parse(this.vaccDateBox.Text);
                a.notes = this.richTextBox1.Text;
                a.species = this.speciesTextbox.Text;
				dbEntities db = new dbEntities();
				db.dbanimals.AddObject(a);
				db.SaveChanges();
				this.Dispose();
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
