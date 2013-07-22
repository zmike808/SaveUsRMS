using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


namespace RSRD
{

    //class used to interface between the record creator,
    //the record text files, and the record viewer/creator
    public class Record
    {
        //the image to show up behind the field boxes
        Bitmap image;

        //id of the animal or person or whatever
        public string entityID;
        //the number of this type of recordt that have been made for the associated entity
        public int iteration;

        //the form name, and table name should always be the same, so this variable can be referenced for either
        public string formName;

        //if the record is empty, used to tell if it is just a blank form or not
        public bool empty = true;

        public DateTime timeStamp { get; set; }

        //the associated fieldboxes
        //should be created like this
        // values[0] = new intBox("alabama", 124, 124, 20, 20, int);
        //get value by using var and getValue();
        public List<FieldBox> values = new List<FieldBox>();


        //the labels that are on the form
        //the string is the text it shows, 
        //the point is it's location
        public List<KeyValuePair<string, Point>> labels = new List<KeyValuePair<string,Point>>();

        //the directory of the formatting file to pRSE
        public string fileDirectory;

        //the actual file name of the format file
        public string FormatFile;

        /// <summary>
        /// used to load record into viewer and query data from the appropriate table
        /// </summary>
        /// <param name="name">
        /// tells you what table to look at, and what .recf file to load from
        /// </param>
        /// <param name="id">
        /// what row to query data from to fill fieldboxes
        /// </param>
        public Record(string name, string id) 
        {
           
        }

        //used when creating a new record type in the editor
        public Record(string name, List<FieldBox> fieldboxes, List<KeyValuePair<string, Point>> _labels) 
        {
            values = fieldboxes;
            formName = name;
            FormatFile = name + ".recf";
            labels = _labels;
        }

        //used when loading a blank, previously created record
        public Record(string name)
        {
            formName = name;
        }

        //parses the format file, creating fieldBoxes and filling in data
        public void ParseFormatFile() {
            values = new List<FieldBox>();
            string location = fileDirectory + FormatFile;
            StreamReader reader = new FileInfo(location).OpenText();
            formName = reader.ReadLine();
            reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                if (words[0] == "fieldBox")
                {
                    switch (words[1])
                    {
                        case "int":
                            values.Add(new intBox(words[4], Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), 0));
                            break;
                        case "string":
                            values.Add(new stringBox(words[4], Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), null));
                            break;
                        case "double":
                            values.Add(new doubBox(words[4], Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), 0.0));
                            break;
                        case "DateTime":
                            values.Add(new dateTimeBox(words[4], Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), DateTime.Now));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                if (words[0] == "fieldBox")
                { // We know it's a fieldbox
                    switch (words[1])
                    { // But what type?
                        case "int":
                            values.Add(new intBox(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), 0));
                            break;
                        case "string":
                            values.Add(new stringBox(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), null));
                            break;
                        case "double":
                            values.Add(new doubBox(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), 0.0));
                            break;
                        case "DateTime":
                            values.Add(new dateTimeBox(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), DateTime.Now));
                            break;
                        default:
                            break;
                    }
                }
                else if (words[0] == "label")
                {
                    labels.Add(new KeyValuePair<string, Point>(words[1], new Point(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]))));
                }
            }
        }

        /// <summary>
        /// check if all the field boxes are filled with valid data,
        /// if so, save the data into a new row of the table with the same name as the form, 
        /// the index will be the id of the animal the data is tied to, and the record instance number, 
        /// returns whether or not the data was able to save
        /// </summary>
        /// <param name="index">
        /// id of animal, and number of record instance
        /// </param>
        public bool saveData(string index) 
        {
            if (!empty) 
            {
                //fill in savey stuff
                return true;
            }
            else
            {
                //no fieldboxes have been filled in
                return false;
            }
       }

        /// <summary>
        /// mike should fill this out
        /// search through the table associated with this record,
        /// count up all of the rows that have identifiers that start with the entityID
        /// </summary>
        public void getIteration() 
        {

        }


         //when a record is created, save the format file, and create the table
       public void FinalizeNewRecord() {

           /*
            MySQLHandler msql = new MySQLHandler("localhost", "ASRD", "root", "root"); //needs to be changed later to be dynamic settings, 
                                                                                       //or at least have a standardized setting for when the software is installed
            List<string> fieldTypes = new List<string>();

            foreach (FieldBox x in values)
            {
                fieldTypes.Add(x.typeToString());
            }
            msql.createTable(formName, fieldTypes);
           */
           // Creating the .recf
           string location = "C:\\Users\\Sebastian\\Documents\\Visual Studio 2010\\Projects\\RSRD\\" + formName + ".recf";
           StreamWriter writer = new FileInfo(location).CreateText();

           // Top of the record
           writer.WriteLine(formName);
           writer.WriteLine("Image");
           // Records the fieldboxes
           foreach (FieldBox x in values)
           {
               writer.WriteLine("fieldBox," + x.typeToString() + ',' + x.x_pos + ',' + x.y_pos + ',' + x.length + ',' + x.height);
           }
           // Records the labels
           foreach (KeyValuePair<string, Point> x in labels)
           {
               writer.WriteLine("label," + x.Key + ',' + x.Value.X + ',' + x.Value.Y);
           }
           writer.Close();
        }
 
        /// <summary>
        /// loads data from the database
        /// </summary>
        /// <param name="id">
        /// the id of the data row
        /// </param>
        void loadData(int id) 
        {


            //definitely not blank after this
            empty = false;
        }

        
    }
}
