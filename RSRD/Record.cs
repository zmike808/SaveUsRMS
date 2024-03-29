﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using MySql.Data.Common;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using MySql.Data.Types;

namespace RSRD
{

    //class used to interface between the record creator,
    //the record text files, and the record viewer/creator
    public class Record
    {
        //the image to show up behind the field boxes
        //Bitmap image;

        //id of the animal or person or whatever
        public string entityID;
        //the number of this type of recordt that have been made for the associated entity
        public int iteration;

        //the form name, and table name should always be the same, so this variable can be referenced for either
        public string formName;

        //if the record is empty, used to tell if it is just a blank form or not
        public bool empty = true;

        public DateTime timeStamp { get; set; }

        public List<FieldBox> values = new List<FieldBox>();

        public static List<TagManager> tags;


        //the labels that are on the form
        //the string is the text it shows, 
        //the point is it's location
        public List<KeyValuePair<string, Point>> labels = new List<KeyValuePair<string,Point>>();

        //the directory of the formatting file to parse
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
            FormatFile = name + ".recf";
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
                    TagManager t = null;
                    //TODO put in tagmanager parsing/search through list
                    if (words.Length == 7)
                    {
                        t = tags.Single(s => s.tagName == words[6]);
                    }
                    switch (words[1])
                    {
                        case "int":
                            values.Add(new intBox(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), t));
                            break;
                        case "string":
                            values.Add(new stringBox(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), t));
                            break;
                        case "double":
                            values.Add(new doubBox(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), t));
                            break;
                        case "DateTime":
                            values.Add(new dateTimeBox(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), t));
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
			reader.Close();
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

         //when a record is created, save the format file, and create the table
       public void FinalizeNewRecord() {


		   var dbhandler = new MySQLHandler();
		   dbhandler.createNewRecord(formName, values);

           string location = formName + ".recf";
		   StringWriter writer = new StringWriter();
		   dbEntities db = new dbEntities();
		   var r = dbRecord.CreatedbRecord(formName);
		   
           // Top of the record
           writer.WriteLine(formName);
           writer.WriteLine("Image");
           // Records the fieldboxes
           foreach (FieldBox x in values)
           {
               writer.WriteLine(x.recfString());
               Console.WriteLine(x.recfString());
           }
           // Records the labels
           foreach (KeyValuePair<string, Point> x in labels)
           {
               writer.WriteLine("label," + x.Key + ',' + x.Value.X + ',' + x.Value.Y);
               Console.WriteLine("label," + x.Key + ',' + x.Value.X + ',' + x.Value.Y);
           }
           writer.Close();
		   r.recordData = writer.ToString();
		   db.dbRecords.AddObject(r);
		   db.SaveChanges();
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
