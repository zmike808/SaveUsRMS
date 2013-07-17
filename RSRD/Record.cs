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

        //if the record is empty
        bool filled;

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

        //used to load record into viewer and query data from the appropriate table
        public Record(string name, int id) 
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
        }

        //parses the format file, creating fieldBoxes and filling in data
        void ParseFormatFile() {
            string location = fileDirectory + FormatFile;
            StreamReader reader = new FileInfo(location).OpenText();
            formName = reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string words[] = line.Split(',');
                if (words[0] == "fieldBox")
                    switch (words[1])
                    {
                        case "int":
                            values.Add(new intBox(words[4], Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToInt32(words[7])));
                            break;
                        case "string":
                            values.Add(new stringBox(words[4], Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), words[7]));
                            break;
                        case "double":
                            values.Add(new doubBox(words[4], Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToDouble(words[7])));
                            break;
                        default:
                            break;
                    }
            }

            filled = true;
        }

        //save the data to the correct table
        public void saveData(string index) { }

        //make sure all fields are filled in and contain valid data
        public void checkDataValidity() { }


        //when a record is created, save the format file, and create the table
        void FinalizeNewRecord() { }

        //loads data from database
        void loadData(int id)
        {

        }

        
    }
}
