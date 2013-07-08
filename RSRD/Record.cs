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
        void ParseFormatFile() { }

        //save the data to the correct table
        public void saveData(string index) { }

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
        void loadData(int id)
        {

        }

        
    }
}
