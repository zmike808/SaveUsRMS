﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace RSRD
{
    //BASIC TEMPLATE COPIED FROM http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/ef37eb19-3c77-4dc5-aa6c-917a6da7fdf2/

    //Don't forget to add the MySQL.Data dll to your projects references
    //It can be downloaded for free from MySQL's official website.
    //Link to the .NET Connector (.dll file) http://dev.mysql.com/downloads/connector/net/


    public class MySQLHandler
    {
        MySqlConnection conn = null;


        #region Constructors
        public MySQLHandler(string hostname, string database, string username, string password)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";");
        }

        public MySQLHandler(string hostname, string database, string username, string password, int portNumber)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";");
        }

        public MySQLHandler(string hostname, string database, string username, string password, int portNumber, int connectionTimeout)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";Connection Timeout=" + connectionTimeout.ToString() + ";");
        }
        #endregion

        #region Open/Close Connection
        private bool Open()
        {
            //This opens temporary connection
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                //Here you could add a message box or something like that so you know if there were an error.
                return false;
            }
        }

        private bool Close()
        {
            //This method closes the open connection
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Database Single field/Quick Editing Manipulators
        //USE FOR QUICK QUERIES WHEN YOU WONT NEED TO EDIT MORE THAN 1 COLUMN/1 VALUE AT A TIME
        public void Insert(string table, string column, string value)
        {
            //Insert values into the database.

            //Example: INSERT INTO names (name, age) VALUES('John Smith', '33')
            //Code: MySQLClient.Insert("names", "name, age", "'John Smith, '33'");
            string query = "INSERT INTO " + table + " (" + column + ") VALUES (" + value + ")";

            try
            {
                if (this.Open())
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch { }
            return;
        }

        public void Update(string table, string SET, string WHERE)
        {
            //Update existing values in the database.

            //Example: UPDATE names SET name='Joe', age='22' WHERE name='John Smith'
            //Code: MySQLClient.Update("names", "name='Joe', age='22'", "name='John Smith'");
            string query = "UPDATE " + table + " SET " + SET + " WHERE " + WHERE + "";

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }

        public void Delete(string table, string WHERE)
        {
            //Removes an entry from the database.

            //Example: DELETE FROM names WHERE name='John Smith'
            //Code: MySQLClient.Delete("names", "name='John Smith'");
            string query = "DELETE FROM " + table + " WHERE " + WHERE + "";

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }
        #endregion

        #region Database Multi-field Manipulators
        //TYPICALLY USE THESE!
        public void Insert(string table, List<string> fieldnames, List<string> fieldvalues)
        {
            //Insert values into the database.

            //Example: INSERT INTO names (name, age) VALUES('John Smith', '33')
            string query = "INSERT INTO " + table + " (";
            foreach (string field in fieldnames)
            {
                query = query + field + ",";
            }
            query = query.Remove(query.Length - 1) + ") VALUES ("; //ghetto hack to take off that extra ", " on the end of the query string, 
            Debug.WriteLine(query);

           //i mean, i could just use a counter but fuck it
            foreach (string field in fieldvalues)
            {
                query = query + "'" + field + "'" + ",";
            }

            query = query.Remove(query.Length - 1) + ")";
            Debug.WriteLine(query);

            try
            {
                if (this.Open())
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch { }
            return;
        }

        /* 
         * logicOption can be AND, OR, NOT, etc...
         * Currently only handling one at a time  and using it across the whole query string 
         * aka name='john' AND age='22', etc, or leave null for no option aka updating based on 1 field value
         */

        public void Update(string table, List<string> SET, List<string> WHERE, string logicOption)    
        {
            //Update existing values in the database.

            //Example: UPDATE names SET name='Joe', age='22' WHERE name='John Smith'
            string query = "UPDATE " + table + " SET ";
             
            foreach(string s in SET)
            {
                query = query + s + ", ";//loop through the values we're editing and append them to the query string
            }

            query = query.Remove(query.Length - 2) + " WHERE ";

            foreach (string s in WHERE)
            {
                query = query + s + " " + logicOption; //trailing whitespace shouldn't effect sql queries, right...?
            }

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }

        //logicOption param functions same as update fuction
        public void Delete(string table, List<string> WHERE, string logicOption)
        {
            //Removes an entry from the database.

            //Example: DELETE FROM names WHERE name='John Smith'
            string query = "DELETE FROM " + table + " WHERE ";

            foreach (string s in WHERE)
            {
                query = query + s + " " + logicOption; //trailing whitespace shouldn't effect sql queries, right...?
            }


            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }
        #endregion

        #region Database Accessors
        public Dictionary<string, string> Select(string table, string WHERE)
        {
            //This methods selects from the database, it retrieves data from it.
            //You must make a dictionary to use this since it both saves the column
            //and the value. i.e. "age" and "33" so you can easily search for values.

            //Example: SELECT * FROM names WHERE name='John Smith'
            // This example would retrieve all data about the entry with the name "John Smith"

            //Code = Dictionary<string, string> myDictionary = Select("names", "name='John Smith'");
            //This code creates a dictionary and fills it with info from the database.

            string query = "SELECT * FROM " + table + " WHERE " + WHERE + "";

            Dictionary<string, string> selectResult = new Dictionary<string, string>();

            if (this.Open())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                try
                {
                    while (dataReader.Read())
                    {

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            selectResult.Add(dataReader.GetName(i).ToString(), dataReader.GetValue(i).ToString());
                        }

                    }
                    dataReader.Close();
                }
                catch { }
                this.Close();

                return selectResult;
            }
            else
            {
                return selectResult;
            }
        }

        public int Count(string table)
        {
            //This counts the numbers of entries in a table and returns it as an integear

            //Example: SELECT Count(*) FROM names
            //Code: int myInt = MySQLClient.Count("names");

            string query = "SELECT Count(*) FROM " + table + "";
            int Count = -1;
            if (this.Open() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    Count = int.Parse(cmd.ExecuteScalar() + "");
                    this.Close();
                }
                catch { this.Close(); }
                return Count;
            }
            else
            {
                return Count;
            }
        }
        #endregion

        /*
         * this needs to be edited for when we want to have fields that can store images as well as strings
         * currently this only accounts for storing strings as fields
         * uniqueID is the column that will be filled with the unique id every animal will have
         * which will be generated by the hash-like function, which has yet to be implemented at this point 6/4/13
         */
        public void createTable(string tableName, List<string> tableFields)
        {
         /*
          *this will be the same for every table, it's how we link what animal is what between all tables
          *each animal will have it's own uniqueID 
          */
            string query = "CREATE TABLE " + tableName + " ( uniqueID INT NOT NULL, ";

            foreach (string field in tableFields)
            {
                query = query + field + "MEDIUMTEXT NULL, ";
            }

            query = query + "PRIMARY KEY (uniqueID), UNIQUE INDEX uniqueID_UNIQUE (uniqueID ASC) );";

            sendCommand(query);

            return;
        }

        #region helperFunctions
        /* 
         * public (for now) because if we want to debug by sending a manual/custom query to the database then it's convient to have this,
         * otherwise the use is only for internal/private querying less messy than retyping the contents for each time we need to send a command
         */
        public void sendCommand(string query)
        {
            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
        }

        #endregion
    }
}
