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
        List<TagManager> tags;

		public string currentUser;

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

            dobEstimateCheckBox.Checked = a.dobIsEstimated;
            dobEstimateCheckBox.CheckState = a.dobIsEstimated ? CheckState.Checked : CheckState.Unchecked;
            dobEstimateCheckBox.Enabled = false;

            locationTextBox.Text = a.location;

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

            //if (a.gender)
            //{ sexTestBox.Text = "MALE"; }
            //else { sexTestBox.Text = "FEMALE"; }
            sexTestBox.Text = a.gender;

            
            
        }

        ////checks all constraints and eliminates the non-valid animals
        //public List<Animal> searchBy(List<Animal> original) 
        //{
        //    List<Animal> culled = original;
        //    return culled;
        //}

        public Form1()
        {
            InitializeComponent();
            initializeHardcode();
            initializeRecords();
            this.Location = new Point(0, 0);
            tags = TagManager.getAllTagManagers();

            splitContainer1.SplitterDistance = splitContainer1.Panel1.Right;//splitContainer1.Panel1.Width + (dataGridView1.Width - splitContainer1.Panel1.Width); //properly size the form dynamically
            splitContainer1.IsSplitterFixed = true;
        }

      /*  private string searchParameters()
        {
            string species = "species = ";
            species += (speciesComboBox.SelectedValue.ToString() == null) ? "*" : speciesComboBox.SelectedValue.ToString();
            string breed = "breed = ";
            breed += (sizeComboBox.SelectedValue.ToString() == null) ? "*" : sizeComboBox.SelectedValue.ToString();
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
           // return returnstr;
        }*/



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
            r.f_ = this;
            r.initializeRecordTypesList();

        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            RecordAdd r = new RecordAdd(this, SelectedAnimal);
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
            f.taglist = tags;
            f.Show();
        }

        public void initializeRecords()
        {
			if (!(Directory.Exists("./records")))
			{
				Directory.CreateDirectory("./records");
			}
			dbEntities db = new dbEntities();
			var savedRecords = from savedRecord in db.dbRecords where savedRecord.recordName != null select savedRecord;
			foreach (var r in savedRecords)
			{
				string location = "./records/" + r.recordName + ".recf";
				var finfo = new FileInfo(location);
				if (!(finfo.Exists))
				{
					StreamWriter writer = finfo.CreateText();
					writer.Write(r.recordData);
					writer.Close();
				}
			}
			//string path = "..\\..\\..\\";
			string[] filePaths = Directory.GetFiles("./records/", "*.recf");
			foreach (string filePath in filePaths)
			{
				FileInfo f = new FileInfo(filePath);
				MessageBox.Show(f.Name.Substring(0, f.Name.Count() - 5));
				Record rect = new Record(f.Name.Substring(0,f.Name.Count()-5));//filePath.,(0, filePath.Count() - 5));
				rect.fileDirectory = "./records/";
				rect.ParseFormatFile();
				blankRecords.Add(rect);
			}
			ImageUtility setup = new ImageUtility();
			setup.preload();
        }

        public void searchHandler(string comp)
        {
            string speciesState = (speciesComboBox.SelectedItem == null) ? "" : speciesComboBox.SelectedItem.ToString();
            string sizeState = (sizeComboBox.SelectedItem == null) ? "" : sizeComboBox.SelectedItem.ToString();
            string statusState = (statusComboBox.SelectedItem == null) ? "" : statusComboBox.SelectedItem.ToString();
            string genderState = (genderComboBox.SelectedItem == null) ? "" : genderComboBox.SelectedItem.ToString();
            if (genderState == "Male")
            {
                genderState = "false";
            }
            else if (genderState == "Female")
            {
                genderState = "true";
            }

            comp = " " + comp + " ";
            //var ownerState = ownerSearchTextBox.Text;
            string query = "";
            MySQLHandler dbh = new MySQLHandler();
            int prevqlen = 0;
            //dont judge, it gets shit done.
            if (speciesState != "")
            {
                query += "species='" + speciesState + "'";
            }

            if (query.Length > prevqlen && sizeState != "")
            {
                prevqlen = query.Length;
                query += comp + "size='" + sizeState + "'";
            }
            else if (sizeState != "")
            {
                query += "size='" + sizeState + "'";
            }

            if (query.Length > prevqlen && statusState != "")
            {
                prevqlen = query.Length;
                query += comp + "status='" + statusState + "'";
            }
            else if (statusState != "")
            {
                query += "status='" + statusState + "'";
            }

            if (query.Length > prevqlen && genderState != "")
            {
                prevqlen = query.Length;
                query += comp + "female='" + genderState + "'";
            }
            else if (genderState != "")
            {
                query += "female='" + genderState + "'";
            }
            if (query != "")
            {
                dataGridView1.DataSource = dbh.loadAnimals(query);
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
            //dialog box to create animal
            AnimalCreateDialog a = new AnimalCreateDialog();
            a.ShowDialog(this);
            a.Dispose();
			Animal newAnim = new Animal(a.a);
            Console.WriteLine(newAnim.Name);
        }


        /// <summary>
        /// generates new list from search constraints, attaches to datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            searchHandler("AND");
        }

        private void createPie(GraphPane myPane, List<string> selected, string dataType)
        {

            myPane.Legend.IsVisible = true;
            //myPane.IsFontsScaled = false;
            myPane.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            // No fill for the chart background
            myPane.Chart.Fill.Type = FillType.None;
            myPane.Title.Text = dataType + " Breakdown";

            double o = 0; //offset
            int c = 0; //color index

            //creates and fills a dictionary of dataType and integer of occurences
            Dictionary<string, int> dataCount = new Dictionary<string, int>();
            foreach (string line in selected)
            {
                char[] delim = { ':' };
                string[] split = line.Split(delim);
                dataCount.Add(split[0], Convert.ToInt32(split[1]));
            }
            Color[] colors = genColors(dataCount.Count); //generate colors

            //adds pie slice for each key in dictionary
            foreach (KeyValuePair<string, int> entry in dataCount)
            {
                myPane.AddPieSlice(entry.Value, Color.White, colors[c], 45f, o, entry.Key); //add slice
                c++; //iterating through color array to differentiate slice colors
            }
            myPane.AxisChange();
            zg1.Invalidate();
        }

        private void createBar(GraphPane myPane, string dataType, List<string> selected)
        {
            myPane.Title.Text = dataType + " Breakdown";
            myPane.XAxis.Title.Text = dataType;
            myPane.YAxis.Title.Text = "Number of Animals";
            int parsed=0;
            //if else statement... if string, int, do the thing, else if int, int, do the other thing(point pair list)...
            Dictionary<string, int> dataCount = new Dictionary<string, int>();
            List<string> x = new List<string>();
            List<int> x2 = new List<int>();
            List<double> y = new List<double>();
            foreach (string line in selected)
            {
                char[] delim = { ':' };
                string[] split = line.Split(delim);
                if (Int32.TryParse(split[0], out parsed))
                    x2.Add(parsed);
                else
                    x.Add(split[0]);
                y.Add(Convert.ToDouble(split[1]));
                //y.Add(Convert.ToInt32(split[1]));
            }
            
            myPane.XAxis.IsVisible = true;
            myPane.YAxis.IsVisible = true;

            if (x.Count == 0)
            {
                //do thing
            }

            if (x2.Count == 0)
            {
                // Set the XAxis labels
                myPane.XAxis.Scale.TextLabels = x.ToArray();
                // Set the XAxis to Text type
                myPane.XAxis.Type = AxisType.Text;
            }

            BarItem myCurve = myPane.AddBar("label",null, y.ToArray(), Color.Blue);

            myPane.XAxis.Type = AxisType.Text;


            myPane.AxisChange();
            zg1.Invalidate();
            //BarItem myCurve = myPane.AddBar("Curve 1", null, x, Color.White);

            /*myPane.XAxis.IsVisible = true;
            myPane.YAxis.IsVisible = true;
            PointPairList list = new PointPairList();
            Dictionary<int, int> dataCount = new Dictionary<int, int>();
            for (int i = 0; i < animals.Count; i++)
            {
                int a = 0;
                if (dataType == "Date of Birth")
                    a = animals[i].dob.Year;
                else if (dataType == "Age")
                    a = DateTime.Now.Year - animals[i].dob.Year;
                if (dataCount.ContainsKey(a))
                    dataCount[a]++;
                else
                    dataCount.Add(a, 1);
            }
            int c = 0;
            double z = 0;
            foreach (KeyValuePair<int, int> entry in dataCount)
            {
                z = c / 4.0;
                list.Add(entry.Key, entry.Value, z);
                c++; //color increment
            }

            BarItem myCurve = myPane.AddBar(dataType, list, Color.Blue);
            //Color[] colors = genColors(dataCount.Count);
            Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Purple };
            myCurve.Bar.Fill = new Fill(colors);
            myCurve.Bar.Fill.Type = FillType.GradientByZ;

            myCurve.Bar.Fill.RangeMin = 0;
            myCurve.Bar.Fill.RangeMax = 10;

            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 225), 45);
            myPane.Legend.IsVisible = false;

            myPane.AxisChange();
            zg1.Invalidate();*/
        }



        private Dictionary<string, int> createDict(List<Animal> animals, string type)
        {
            Dictionary<String, int> dataCount = new Dictionary<string, int>();
            for (int i = 0; i < animals.Count; i++)
            {
                string s = "";
                if (type == "Species")
                    s = animals[i].species.ToString();
                else if (type == "Gender")
                    s = animals[i].female == false ? "Male" : "Female"; //gets gender strings
                else if (type == "Breed")
                    s = animals[i].breed;
                else if (type == "Month of Birth")
                    s = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(animals[i].dob.Month); //gets month strings
                else if (type == "Year of Birth")
                    s = animals[i].dob.Year.ToString();
                else if (type == "Status")
                    s = animals[i].status.ToString();
                if (dataCount.ContainsKey(s))
                    dataCount[s]++; //increment key
                else
                    dataCount.Add(s, 1); //add new key
            }
            return dataCount;
        }

        private void createStatisticsFile(List<Animal> animals, List<string> dataTypes)
        {
            string fpath = Environment.CurrentDirectory + "\\statistics.txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fpath))
            {
                foreach (string type in dataTypes)
                {
                    file.WriteLine("&" + type);
                    Dictionary<String, int> dataCount = createDict(animals, type);
                    foreach (var entry in dataCount)
                    {
                        file.WriteLine(entry.Key + ":" + entry.Value);
                    }
                }
            }
        }

        private List<string> parseBySelect(string s)
        {
            bool x = false;
            string fpath = Environment.CurrentDirectory + "\\statistics.txt";
            string[] lines = System.IO.File.ReadAllLines(fpath);

            List<string> selected = new List<string>();
            foreach (string line in lines)
            {
                if (line.Replace("&", string.Empty) == s)
                    x = true;
                else if (line[0] == '&')
                    x = false;
                if (line[0] != '&' && x)
                    selected.Add(line);
            }
            return selected;
        }


        private void TabControl1_Enter(object sender, EventArgs e)
        {
            zg1.Visible = false;
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

            List<string> pieType = new List<string>();
            pieType.Add("Species");
            pieType.Add("Gender");
            pieType.Add("Breed");
            pieType.Add("Month of Birth");
            pieType.Add("Year of Birth");
            pieType.Add("Status");
            if (select == "Pie Chart")
            {
                listBox2.DataSource = pieType;
            }
            if (select == "Bar Chart")
            {
                List<string> barType = new List<string>();
                barType.Add("Date of Birth");
                barType.Add("Age"); 
                barType.Add("Species");
                listBox2.DataSource = pieType;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zg1.Visible = true;
            //make new graph pane
            GraphPane myPane = zg1.GraphPane;
            myPane.CurveList.Clear();
            string graphselect = listBox1.SelectedItem.ToString();
            if (graphselect == "Pie Chart") //create pie chart
            {
                string select = listBox2.SelectedItem.ToString();
                List<string> selected = parseBySelect(select);
                createPie(myPane, selected, select);
            }
            if (graphselect == "Bar Chart") //create pie chart
            {
                string select = listBox2.SelectedItem.ToString();
                List<string> selected = parseBySelect(select);
                createBar(myPane, select, selected);
            }
            /*if (graphselect == "Bar Chart") //create bar chart
            {
                string select = listBox2.SelectedItem.ToString();
                if (select == "Date of Birth")
                {
                    myPane.Title.Text = "Date of Birth Breakdown";
                    myPane.XAxis.Title.Text = "Birthday";
                    myPane.YAxis.Title.Text = "Animals";
                    myPane.YAxis.Scale.Format = "#";
                    createBar(myPane, listanimals, select);
                }
                if (select == "Age")
                {
                    myPane.Title.Text = "Age Breakdown";
                    myPane.XAxis.Title.Text = "Age";
                    myPane.YAxis.Title.Text = "Animals";
                    myPane.YAxis.Scale.Format = "#";
                    createBar(myPane, listanimals, select);
                }
            }*/
        }


        // Given H,S,L in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static Color HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
            Color rgb;
            rgb = Color.FromArgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
            return rgb;
        }


        private Color[] genColors(int s)
        {
            Color[] colors= new Color[s];
            for (int i = 0; i < s; i++)
            {
                colors[i] = HSL2RGB(i / (double)s, 0.9, 0.4);
            }
                return colors;
        }
        private void zg1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchHandler("OR");
        }

        private void Form1_Load(object sender, EventArgs e){

			EmployeeLoginWindow login = new EmployeeLoginWindow();
			if (login.getCurrentUser() != "" || login.ShowDialog() == DialogResult.OK)
			{
				this.currentUser = login.getCurrentUser();
				login.Close();
			}			
			
        }

        private void stats_button_Click(object sender, EventArgs e)
        {
            MySQLHandler dbh = new MySQLHandler();
            List<Animal> listanimals = dbh.loadAnimals().ToList();
            List<string> dataType = new List<string>();
            dataType.Add("Species");
            dataType.Add("Gender");
            dataType.Add("Breed");
            dataType.Add("Month of Birth");
            dataType.Add("Year of Birth");
            dataType.Add("Status");
            createStatisticsFile(listanimals, dataType);
        //private void createStatisticsFile(List<Animal> animals, List<string> dataTypes)
        }

    }
}
