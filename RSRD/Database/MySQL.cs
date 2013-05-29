using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace RSRD.Database
{
    //BASIC TEMPLATE COPIED FROM http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/ef37eb19-3c77-4dc5-aa6c-917a6da7fdf2/

    //Don't forget to add the MySQL.Data dll to your projects references
    //It can be downloaded for free from MySQL's official website.
    //Link to the .NET Connector (.dll file) http://dev.mysql.com/downloads/connector/net/


    public class MySQL
    {
        MySqlConnection conn = null;


        #region Constructors
        public MySQL(string hostname, string database, string username, string password)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";");
        }

        public MySQL(string hostname, string database, string username, string password, int portNumber)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";");
        }

        public MySQL(string hostname, string database, string username, string password, int portNumber, int connectionTimeout)
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

        public void Insert(string table, List<string> fieldnames, List<string> fieldvalues)
        {
            //Insert values into the database.

            //Example: INSERT INTO names (name, age) VALUES('John Smith', '33')
            //Code: MySQL.Insert("animals", "name, type, etc", "John Smith, bird");
            string query = "INSERT INTO " + table + " (";
            foreach (string field in fieldnames)
            {
                query = query + "'" + field + "'" + ", "; //handle the single quotations needed for sql queries in here (assumes that not handled prior, in GUI code)
            }
            query = query.Remove(query.Length - 2) + ") VALUES ("; //ghetto hack to take off that extra ", " on the end of the query string, 
                                                                    //i mean, i could just use a counter but fuck it
            foreach (string field in fieldvalues)
            {
                query = query + "'" + field + "'" + ", ";
            }

            query = query.Remove(query.Length - 2) + ")";

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
    }
}
