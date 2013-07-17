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

        //the form name, and table name should always be the same, so this variable can be referenced for either
        public string formName;

        //if the record is empty, used to tell if it is just a blank form or not
        public bool empty;

        public DateTime timeStamp { get; set; }

        //the associated fieldboxes
        //should be created like this
        // values[0] = new intBox("alabama", 124, 124, 20, 20, int);
        //get value by using var and getValue();
        public List<FieldBox> values;

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
        public Record(string name, List<FieldBox> fieldboxes) 
        {
            values = fieldboxes;
            formName = name;
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
                        default:
                            break;
                    }
            }

            empty = false;
        }

        /// <summary>
        /// check if all the field boxes are filled with valid data,
        /// if so, save the data into a new row of the table with the same name as the form, 
        /// the index will be the id of the animal the data is tied to, and the record instance number
        /// </summary>
        /// <param name="index">
        /// id of animal, and number of record instance
        /// </param>
        public void saveData(string index) 
        {
            if (!empty) 
            {
            }
            else
            {
                //no fieldboxes have been filled in
            }
        /*
         * wat? ??? how can you know where to save data to if there's only an index which is a very ambiguous variable name...
         * seabass wat r u doin
         * seabassplz stahp
         * */
       }
 
         //make sure all fields are filled in and contain valid data
         public void checkDataValidity() { }
 
 
         //when a record is created, save the format file, and create the table
       void FinalizeNewRecord() {
         MySQLHandler msql = new MySQLHandler("localhost", "ASRD", "root", "root"); //needs to be changed later to be dynamic settings, 
                                                                                       //or at least have a standardized setting for when the software is installed
            List<string> fieldTypes = new List<string>();

            foreach (FieldBox x in values)
            {
                fieldTypes.Add(x.typeToString());
            }
            msql.createTable(formName, fieldTypes);
        }
 
         //loads data from database
        void loadData(int id) { }

        
    }
}
