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
    class Record
    {
        //the image to show up behind the field boxes
        Bitmap image;

        //the associated fieldboxes
        //should be created like this
        // values[0] = new FieldBox<object>("alabama", 124, 124, (int)32);
        //should be accessed by typecasting
        List<FieldBox<object>> values;

        //the directory of the formatting file to pRSE
        public string fileDirectory;

        //the actual file name of the format file
        public string FormatFile;

        //default constructor
        public Record() 
        {
           
        }



        //parses the format file, creating fieldBoxes and filling in data
        void ParseFormatFile() { }

        //save the data to the correct table
        public void saveData(string index) { }

        //make sure all fields are filled in and contain valid data
        public void checkDataValidity() { }


        //when a record is created, save the format file, and create the table
        void FinalizeNewRecord() { }

        
    }
}
