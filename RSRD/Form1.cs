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
    public partial class Form1 : Form
    {
        //starts out as all animals, changes as search constraints are altered
        List<Animal> animals = new List<Animal>();



        BindingList<Animal> constrained;


        #region hardcodedbullshit

        public void initializeHardcode() 
        {
            animals.Add(new Animal(Animal.Species.Canine, Animal.Size.Medium, Animal.Status.Adopted, "Casper", true));
            animals[0].vacc = true;
            animals.Add(new Animal(Animal.Species.Feline, Animal.Size.Small, Animal.Status.Found, "Milo", false));
            constrained = new BindingList<Animal>(animals);



            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            dataGridView1.Columns.Add(nameColumn);

            dataGridView1.DataSource = constrained;
        }

        #endregion 

        //loads the details of the selected animal into the preview container elements
        public void loadSelected(object sender, DataGridViewCellEventArgs e) 
        {
            DataGridView box = (DataGridView)sender;
            Animal a =  (Animal)box.Rows[e.RowIndex].DataBoundItem;
            nameTextBox.Text = a.Name;

            sterilizedCheckBox.Checked = a.sterilized;
            sterilizedCheckBox.CheckState = a.sterilized ? CheckState.Checked : CheckState.Unchecked;
            sterilizedCheckBox.Enabled = false;

            vaccCheckBox.Checked = a.vacc;
            vaccCheckBox.CheckState = a.vacc ? CheckState.Checked : CheckState.Unchecked;
            vaccCheckBox.Enabled = false;
        }

        //checks all constraints and eliminates the non-valid animals
        public List<Animal> searchBy(List<Animal> original) 
        {
            List<Animal> culled = original;
            return culled;
        }


        public Form1()
        {
            InitializeComponent();
            initializeHardcode();

        }

        private void adoptButton_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        //bring up the record viewer, using the animal id constructor

        private void viewRecordButton_Click(object sender, EventArgs e)
        {
            RecordViewer r = new RecordViewer();
            r.Show();
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            RecordAdd r = new RecordAdd();
            r.Show();
        }

        //call when animal tab is loaded and when search constraints are altered
        private void populateAnimalList() 
        {            
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            //initializeHardcode();
            populateAnimalList();
        }

    }
}
