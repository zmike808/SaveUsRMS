//#define admindev

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.Entity;
using MySql.Data.Types;
using System.Diagnostics;

namespace RSRD
{
    //BASIC TEMPLATE COPIED FROM http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/ef37eb19-3c77-4dc5-aa6c-917a6da7fdf2/

    //Don't forget to add the MySQL.Data dll to your projects references
    //It can be downloaded for free from MySQL's official website.
    //Link to the .NET Connector (.dll file) http://dev.mysql.com/downloads/connector/net/

    /// <summary>
    /// Global variables for db connecting (readonly access)
    /// </summary>
    
	class DbBuilder
	{
		public string crlf = Environment.NewLine;
		List<DbColumn> columns;
	//	public enum ColTypes { ctint, ctvarchar, ctdatetime };
		string tablename;

		public DbBuilder()
		{
			columns = null;
		}

		public void StartTable(string tableName)
		{
			columns = new List<DbColumn>();
			tablename = "`"+tableName+"`";
		}

		public string BuildSQL()
		{
			string primary = "";
			if (columns == null)
				throw new Exception("Mising StartTable in class DbBuilder");
			string sql = "CREATE TABLE IF NOT EXISTS " + tablename + " (";
			foreach(DbColumn dbcol in columns)
			{
				sql += dbcol.toString();
				if (primary == string.Empty && dbcol.isPrimary)
				{
					primary = "PRIMARY KEY (" + dbcol.colName + ")";
				}
			}
			if (primary != "")
			{
				sql += primary;//primary).Append(crlf);
			}
			sql += ");";
			return sql;
		}

		public void AddColumn(FieldBox.boxtypes type, string columnName, bool isIndex = false, bool isPrimary = false, int charlen = 0, bool isnull = true)
		{
			DbColumn dbc = new DbColumn(type, columnName, isIndex, isPrimary, charlen, isnull);
			columns.Add(dbc);
		}
	}

	// ****************************************************** DBColumn *********************************************
	class DbColumn
	{
		FieldBox.boxtypes colType;
		private bool isnull;
		public string colName { get; set; }
		public bool IsIndex { get; set; }
		public bool isPrimary { get; set; }
		public int charLen;
		public string isNull
		{
			get
			{
				return isnull ? "NULL" : "NOT NULL";
			}
		}

		public string ColType
		{
			get
			{
				switch (colType)
				{
					case FieldBox.boxtypes.intBox: return "INT " + isNull;
					case FieldBox.boxtypes.stringBox: return "VARCHAR(255) " + isNull;
					case FieldBox.boxtypes.dateTimeBox: return "DATETIME " + isNull;
					case FieldBox.boxtypes.doubBox: return "DOUBLE " + isNull;
					default: return "";
				}
			}
		}

		public string toString()
		{
			return this.colName + " " + this.ColType + ",";
		}
		public DbColumn(FieldBox.boxtypes type, string columnName, bool isIndex = false, bool isPrimary = false, int charlen = 0, bool isnull = true)
		{
			colType = type;
			colName = "`" + columnName + "`";
			this.IsIndex = isIndex;
			charLen = charlen;
			this.isnull = isnull;
			this.isPrimary = isPrimary;
		}
	}

    public class MySQLHandler
    {
       public MySqlConnection conn = null;


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
        public MySQLHandler(string hostname, string username, string password)
        {
            conn = new MySqlConnection("host=" + hostname + ";username=" + username + ";password=" + password + ";");
        }
        /// <summary>
        /// USE THIS UNLESS OTHERWISE NOTED!
        /// Default constructor: Creates a mysql connection using the global credentials defined in DBInfo
        /// </summary>
        public MySQLHandler()
        {
			dbEntities db = new dbEntities();
			var cb = new MySqlConnectionStringBuilder(((System.Data.EntityClient.EntityConnection)db.Connection).StoreConnection.ConnectionString);
			conn = new MySqlConnection(cb.GetConnectionString(true));
			//MessageBox.Show(conn.Database);
	
			// conn = new MySqlConnection("host=" + DBInfo.host + ";database=" + DBInfo.database + ";username=" + DBInfo.username + ";password=" + DBInfo.password + ";" + "Allow User Variables=true;");
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
        public void Insert(string table, List<string> fieldnames, List<object> fieldvalues)
        {
            //Insert values into the database.
            
           
            string query = "INSERT INTO " + table + " (";
            foreach (string field in fieldnames)
            {
                query = query + field + ",";
            }
            query = query.Remove(query.Length - 1) + ") VALUES ("; //ghetto hack to take off that extra ", " on the end of the query string, 
            Debug.WriteLine(query);

           //i mean, i could just use a counter but fuck it
            foreach (var field in fieldvalues)
            {
                //if (field.GetType() == typeof(MySqlDateTime))
                //{
                //    MySqlDateTime t = new MySqlDateTime((DateTime)field);
                //    MessageBox.Show(t.ToString());
                //    query = query + "'" + t. + "'" + ",";
                //}
                 if (field.ToString() == "False")
                {
                    query = query + "'" + "0" + "'" + ",";
                }
                else if( field.ToString() == "True")
                {
                    query = query + "'" + "1" + "'" + ",";
                }
                else
                {
                    query = query + "'" + field.ToString() + "'" + ",";
                }
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
                         //   dataReader.
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

        /// <summary>
        /// creates a binding list containing all the animals in the animal table
        /// </summary>
        /// <returns>a bindinglist of type animal which can be converted to a list of type animal</returns>
        public BindingList<Animal> loadAnimals()
        {
           dbEntities db = new dbEntities();
            BindingList<Animal> bindedanimals = new BindingList<Animal>();
            var animals = from e in db.dbanimals
                          where e.ID > 0
                          select e;
			try
			{
				foreach (var a in animals)
				{
					bindedanimals.Add(new Animal(a));
				}
			}
			catch (Exception e)
			{
			}
            return bindedanimals;
            //try
            //{
            //    // - DEBUG 
            //    // MessageBox.Show("Connection successful!"); 
            //    MySqlDataAdapter MyDA = new MySqlDataAdapter();
            //    MyDA.SelectCommand = new MySqlCommand("SELECT * FROM `animal`", conn);
            //    DataTable table = new DataTable();
            //    MyDA.Fill(table);
 
            //    BindingList<Animal> bindedanimals = new BindingList<Animal>();
            //    foreach (DataRow row in table.Rows)
            //    {
            //       Animal a = new Animal(row.ItemArray);
            //       bindedanimals.Add(a);
            //    }

            //    return bindedanimals;
            //}
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    Close();
            //}
            //return null;
        }

        public BindingList<Animal> loadAnimals(string constrants)
        {
            //try
            //{
            //    // - DEBUG 
            //    // MessageBox.Show("Connection successful!"); 
            //    MySqlDataAdapter MyDA = new MySqlDataAdapter();
            //    string cmdstr = "SELECT * FROM `animal` WHERE " + constrants;
            //    MessageBox.Show(cmdstr);
            //    MyDA.SelectCommand = new MySqlCommand(cmdstr, conn);
            //    DataTable table = new DataTable();
            //    MyDA.Fill(table);
                
            //    BindingList<Animal> bindedanimals = new BindingList<Animal>();
            //    foreach (DataRow row in table.Rows)
            //    {
            //        Animal a = new Animal(row.ItemArray);
            //        bindedanimals.Add(a);
            //    }

            //    MessageBox.Show(table.Rows.Count.ToString());
            //    return bindedanimals;
            //}
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    Close();
            //}
            return null;
        }
        /// <summary>
        /// creates/adds a new animal, s, to animal table in the database
        /// </summary>
        /// <param name="a">Animal to add to database</param>
        public void saveAnimal(Animal a)
        {
            //string[] animalTableColumns = { "name", "DateofBirth", "image", "estimate", "vaccination", "sterilized", "female", "color", "size", "breed", "crossbreed", "location", "owner", "notes", "species", "status"};

            //List<string> animalcolumns = new List<string>(animalTableColumns);
            
            //this.Insert("animal", animalcolumns, Animal.toList(a)); 
        }
        /// <summary>
        /// untested, but should create a new table based off the parameters given, ideally used for custom form creation
        /// </summary>
        /// <param name="tableName">name of form that the table will be created for</param>
        /// <param name="fieldTypes">list of fields that are in the form (which will act as the columns for the table) currently limited to string, int, and double</param>
		
		//public void createTable(string tableName, List<string> fieldTypes)
		// {
		//  /*
		//   *this will be the same for every table, it's how we link what animal is what between all tables
		//   *each animal will have it's own uniqueID 
		//   */
		//     string query = "CREATE TABLE IF NOT EXISTS " + tableName + " ( `ID` INT NOT NULL AUTO_INCREMENT, ";
 
		//    int count = 1;
		//    foreach (string field in fieldTypes)
		//     {
		//        query = query + "`" + count.ToString() + "` "; //each column name will be a number from 1..n, n being the last column and equal to the # of columns in that table

		//        if (field == "string")
		//        {
		//            query = query + "TEXT NULL DEFAULT NULL, ";
		//        }
		//        if (field == "int")
		//        {
		//            query = query + "INT NULL DEFAULT NULL, ";
		//        }
		//        if (field == "double")
		//        {
		//            query = query + "DOUBLE NULL DEFAULT NULL, ";
		//        }
		//        count++;
		//     }
 

		//    query = query + "PRIMARY KEY (`ID`) );";

		//    Debug.Write(query);

		//    sendCommand(query);
		//}
		public void addRecord(string formName,List<FieldBox> values)
		{
			DbBuilder dbBuilder = new DbBuilder();
			dbBuilder.StartTable(formName);
			dbBuilder.AddColumn(FieldBox.boxtypes.stringBox, "ID", false, true, 0, false);
			dbBuilder.AddColumn(FieldBox.boxtypes.intBox, "animalID", true, false, 0, false);
			dbBuilder.AddColumn(FieldBox.boxtypes.dateTimeBox, "DateCreated", true, false, 0, false);
			int x = 0;
			foreach (var v in values)
			{
				dbBuilder.AddColumn(v.type, x.ToString(), false, false, 0, true);
				x++;
			}
			//MessageBox.Show(dbBuilder.BuildSQL());
			this.conn.Open();
			var cmd = new MySqlCommand(dbBuilder.BuildSQL(), this.conn);
			cmd.ExecuteNonQuery();
			this.conn.Close();
			//	sendCommand(dbBuilder.BuildSQL());
			
			
		}

        #region helperFunctions
        /* 
         * public (for now) because if we want to debug by sending a manual/custom query to the database then it's convient to have this,
         * otherwise the use is only for internal/private querying less messy than retyping the contents for each time we need to send a command
         * returns true if command succeeded, false if failed / error occured.
         */
        public bool sendCommand(string query)
        {
            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.
					//Debug.WriteLine("OPEN");
				//	Debug.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                    return true;
                }
                catch {
					//Debug.WriteLine("FAILURE");
                    this.Close();
                    return false;
                }
            }
            return false;
        }


        #endregion
    }
}
