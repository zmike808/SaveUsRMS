using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ZedGraph;

namespace RSRD
{
    public partial class Form1 : Form
    {
        //starts out as all animals, changes as search constraints are altered
        //List<Animal> animals = new List<Animal>();

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
            species += (speciesComboBox.SelectedValue.ToString() == null) ? "*" : speciesComboBox.SelectedValue.ToString();
            string breed = "breed = ";
            breed += (breedComboBox.SelectedValue.ToString() == null) ? "*" : breedComboBox.SelectedValue.ToString();
            //List<string> statuses = new List<string>();
            //for (int x = 0; x < statusBox.Items.Count; x++)
            //{
            //    if (statusBox.Items[x] != null)
            //    {
            //        statuses.Add(statusBox.Items[x].ToString());
            //    }
            //}

            string gender = "female =";

            if (radioButton1.Checked == true)
            {
                gender += Convert.ToString(false);
            }
            else if (radioButton2.Checked == true)
            {
                gender += Convert.ToString(true);
            }
            else
            {
                gender = "*";
            }

            string owner = "owner = ";
            owner += (ownerSearchTextBox.Text == null) ? "*" : ownerSearchTextBox.Text;

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

        private void createPie(GraphPane myPane, List<Animal> animals, string dataType)
        {
            myPane.IsFontsScaled = false;
            myPane.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            // No fill for the chart background
            myPane.Chart.Fill.Type = FillType.None;

            double o = 0; //offset
            int c = 0; //color counter
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple, Color.Cyan, Color.SeaGreen, Color.MistyRose, Color.RosyBrown, Color.Sienna, Color.MintCream, Color.Navy, Color.Orange, Color.OldLace, Color.Olive }; //slice color array

            //creates and fills a dictionary of dataType and integer of occurences
            Dictionary<String, int> dataCount = new Dictionary<string, int>();
            for (int i = 0; i < animals.Count; i++)
            {
                string s = "";
                if (dataType == "Species")
                    s = animals[i].species.ToString();
                else if (dataType == "Gender")
                    s = animals[i].female == false ? "Male" : "Female"; //gets gender strings
                else if (dataType == "Date of Birth")
                    s = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(animals[i].dob.Month); //gets month strings
                if (dataCount.ContainsKey(s))
                    dataCount[s]++; //increment key
                else
                    dataCount.Add(s, 1); //add new key
            }
            //adds pie slice for each key in dictionary
            foreach (KeyValuePair<string, int> entry in dataCount)
            {
                myPane.AddPieSlice(entry.Value, Color.White, colors[c],45f, o, entry.Key); //add slice
                c++; //iterating through color array to differentiate slice colors
            }
            //myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45);
            //myPane.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 225), 45);
            myPane.AxisChange();
            zg1.Invalidate();
        }

        private void createBar(GraphPane myPane,List<Animal> animals, string dataType)
        {
            myPane.XAxis.IsVisible = true;
            myPane.YAxis.IsVisible = true;
            myPane.XAxis.Title.Text = "Date of Birth";
            myPane.YAxis.Title.Text = "Animals";
            myPane.YAxis.Scale.Format = "#";

            PointPairList list = new PointPairList();
            Dictionary<int, int> ageCount = new Dictionary<int, int>();
            for (int i = 0; i < animals.Count; i++)
            {
                int a = animals[i].dob.Year;
                if (ageCount.ContainsKey(a))
                    ageCount[a]++;
                else
                    ageCount.Add(a, 1);
            }
            int c = 0;
            double z=0;
            foreach(KeyValuePair<int,int> entry in ageCount)
            {
                z = c / 4.0;
                list.Add(entry.Key,entry.Value,z);
                c++; //color increment
            }

            BarItem myCurve = myPane.AddBar("Multi-Colored Bars", list, Color.Blue);
            Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Purple};
            //Color[] colors = { Color.Red, Color.Blue, Color.Green };
            myCurve.Bar.Fill = new Fill(colors);
            myCurve.Bar.Fill.Type = FillType.GradientByZ;

            myCurve.Bar.Fill.RangeMin = 0;
            myCurve.Bar.Fill.RangeMax = 10;

            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 225), 45);
            myPane.Legend.IsVisible = false;

            myPane.AxisChange();
            zg1.Invalidate();
        }

        private void TabControl1_Enter(object sender, EventArgs e)
        {
            List<string> graphType = new List<string>();
            graphType.Add("Pie Chart");
            graphType.Add("Bar Chart");
            listBox1.DataSource = graphType;

            MySQLHandler dbh = new MySQLHandler();
            List<Animal> listanimals = dbh.loadAnimals().ToList();
        }


        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //fill listBox1 & corresponding listBox2
            string select = listBox1.SelectedItem.ToString();
            if (select == "Pie Chart")
            {
                List<string> pieType = new List<string>();
                pieType.Add("Species");
                pieType.Add("Gender");
                pieType.Add("Date of Birth");
                listBox2.DataSource = pieType;
            }
            if (select == "Bar Chart")
            {
                List<string> barType = new List<string>();
                barType.Add("Date of Birth");
                listBox2.DataSource = barType;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //load animal list
            MySQLHandler dbh = new MySQLHandler();
            List<Animal> listanimals = dbh.loadAnimals().ToList();
            //make new graph pane
            GraphPane myPane = zg1.GraphPane;
            myPane.CurveList.Clear();
            string graphselect = listBox1.SelectedItem.ToString();
            if (graphselect == "Pie Chart") //create pie chart
            {
                string select = listBox2.SelectedItem.ToString();
                if (select == "Species")
                {
                    myPane.Title.Text = "Species Breakdown";
                    createPie(myPane, listanimals, select);
                }
                if (select == "Gender")
                {
                    myPane.Title.Text = "Gender Breakdown";
                    createPie(myPane, listanimals, select);
                }
                if (select == "Date of Birth")
                {
                    myPane.Title.Text = "Date of Birth Breakdown";
                    createPie(myPane, listanimals, select);
                }
            }
            if (graphselect == "Bar Chart") //create bar chart
            {
                string select = listBox2.SelectedItem.ToString();
                if(select=="Date of Birth")
                {
                    myPane.Title.Text = "Date of Birth Breakdown";
                    createBar(myPane, listanimals, select);
                }
            }
        }

        private void zg1_Load(object sender, EventArgs e)
        {

        }

    }
}
