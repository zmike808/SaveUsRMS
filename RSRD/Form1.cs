using System;
using System.IO;
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

        //more hardcoded bullshit
        stringBox i = new stringBox(100, 100, 20, 10, "test");
        intBox j = new intBox(100, 200, 20, 10, 0);
        List<FieldBox> list = new List<FieldBox>();
        List<KeyValuePair<string, Point>> labels = new List<KeyValuePair<string, Point>>();


        BindingList<Animal> constrained;

        public List<Record> blankRecords = new List<Record>();

        public Animal SelectedAnimal;

        #region hardcodedbullshit

        public void initializeHardcode() 
        {
            MySQLHandler dbh = new MySQLHandler();
            dataGridView1.DataSource = dbh.loadAnimals();
        }

        #endregion 

        //loads the details of the selected animal into the preview container elements
        public void loadSelected(object sender, DataGridViewCellEventArgs e) 
        {
            DataGridView box = (DataGridView)sender;
            Animal a =  (Animal)box.Rows[e.RowIndex].DataBoundItem;
            SelectedAnimal = a;
            nameTextBox.Text = a.Name;

            sterilizedCheckBox.Checked = a.sterilized;
            sterilizedCheckBox.CheckState = a.sterilized ? CheckState.Checked : CheckState.Unchecked;
            sterilizedCheckBox.Enabled = false;

            //god damn it seabass...why did you have vacc as a bool in the first place -_-
            if (a.vacc != null)
            {
                vaccCheckBox.Checked = true;
            }
            else
            {
                vaccCheckBox.Checked = false;
            }
            vaccCheckBox.CheckState = vaccCheckBox.CheckState;
            vaccCheckBox.Enabled = false;

            idTextBox.Text = a.ID.ToString();

            dobTextBox.Text = a.dob.ToShortDateString();
            
            dobEstimateCheckBox.Checked = a.dobEstimate;
            dobEstimateCheckBox.CheckState = a.dobEstimate ? CheckState.Checked : CheckState.Unchecked;
            dobEstimateCheckBox.Enabled = false;

            locationTextBox.Text = a.Address;

            breedTextBox.Text = a.breed;

            if (a.crossbreed != null && a.crossbreed != "")
            {
                crossbreedCheckBox.Checked = true;
                crossbreedCheckBox.CheckState = CheckState.Checked;
                crossbreedCheckBox.Enabled = false;
                crossBreedTextBox.Text = a.crossbreed;
            }
            else 
            {
                crossbreedCheckBox.Checked = false;
                crossbreedCheckBox.CheckState = CheckState.Unchecked;
                crossbreedCheckBox.Enabled = false;
                crossBreedTextBox.Text = "None";
            }

            if (a.female)
            { sexTestBox.Text = "MALE"; }
            else { sexTestBox.Text = "FEMALE"; }

            
            
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
            initializeRecords();
            this.Location = new Point(0, 0);
            this.WindowState = FormWindowState.Maximized;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;

        }

        private string searchParameters()
        {
            string species = "species = ";
            species += (speciesBox.SelectedValue.ToString() == null) ? "*" : speciesBox.SelectedValue.ToString();
            string breed = "breed = ";
            breed += (breedBox.SelectedValue.ToString() == null) ? "*" : breedBox.SelectedValue.ToString();
            //List<string> statuses = new List<string>();
            //for (int x = 0; x < statusBox.Items.Count; x++)
            //{
            //    if (statusBox.Items[x] != null)
            //    {
            //        statuses.Add(statusBox.Items[x].ToString());
            //    }
            //}

            string gender = "female =";

            if (maleRB.Checked == true)
            {
                gender += Convert.ToString(false);
            }
            else if (femaleRB.Checked == true)
            {
                gender += Convert.ToString(true);
            }
            else
            {
                gender = "*";
            }

            string owner = "owner = ";
            owner += (ownerName.Text == null) ? "*" : ownerName.Text;

            string returnstr = species + " " + breed + " " + gender + " " + owner + " ";
            return returnstr;
        }



        private void adoptButton_Click(object sender, EventArgs e)
        {
            /*
            Record test = new Record("TestRecord");
            test.fileDirectory = "C:\\Users\\Sebastian\\Documents\\Visual Studio 2010\\Projects\\RSRD\\";
            
            //should be replaced with a save/load dialog
            FieldboxCreationForm f = new FieldboxCreationForm();
            f.ShowDialog();
            f.Dispose();
            test.FormatFile = f.text +".recf";

            test.ParseFormatFile();
            System.Console.WriteLine("values size is: " + test.values.Count);
            for (int i = 0; i < test.values.Count; i++)
            {
                System.Console.WriteLine(test.values[i].typeToString());
            }
            System.Console.WriteLine("empty's value is: " + test.empty);
            blankRecords.Add(test);
           */
        }

        /// <summary>
        /// bring up the record viewer, using the animal id constructor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void viewRecordButton_Click(object sender, EventArgs e)
        {
            RecordViewer r = new RecordViewer();
            r.Show();
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            RecordAdd r = new RecordAdd(this);
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

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMaker f = new FormMaker(this);
            f.Show();
        }

        public void initializeRecords()
        {
            string path = "..\\..\\..\\";
            string[] filePaths = Directory.GetFiles(@path, "*.recf");
            foreach (string filePath in filePaths)
            {
                Record rect = new Record(filePath.Substring(path.Count(), filePath.Count()-path.Count() - 5));
                rect.fileDirectory = path;
                rect.ParseFormatFile();
                blankRecords.Add(rect);
            }

        }

        /// <summary>
        /// should bring up a a form for animal creation,
        /// when creation is done, bring up all of the other records in addRecord that would be necessary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAnimalButton_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// generates new list from search constraints, attaches to datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
