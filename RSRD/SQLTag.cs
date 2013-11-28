using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Entity;
using MySql.Data.Types;

namespace RSRD
{
	public class SQLTag
	{
		private Tag tag;
		public string Name
		{
			get {return tag.name;}
			set {tag.name = value;}
		}
		public string table
		{
			get {return tag.tableName;}
			set {tag.tableName = value;}
		}
		public string column
		{
			get {return tag.colName;}
			set {tag.colName = value;}
		}

		public Type tagType;
		public Type listType;
		public dynamic data;
		//{
		//    get {return t
		//}
		//List<val>
		//List<dynamic> 
		/// <summary>
		/// use this constructor for creating a new tag
		/// </summary>
		/// <param name="tagName">name of tag</param>
		/// <param name="tableName">form/record name</param>
		/// <param name="colName">column name</param>
		/// <param name="type">type of column</param>
		public SQLTag(string tagName, string tableName, string colName, string type)
		{
			var db = new dbEntities();
			var tags = from temp in db.Tags
					   where temp.id > 0
					   select temp;
			int lastID = tags.Max(temp => temp.id);
			tag = Tag.CreateTag(lastID+1,tagName, tableName, colName, type);
			db.Tags.AddObject(tag);
			db.SaveChanges();

		}
		/// <summary>
		/// used for the tag manager
		/// </summary>
		/// <param name="t">entity framework Tag object</param>
		public SQLTag(Tag t)
		{
			tag = t;
			tagType = Type.GetType(tag.type);
			listType = typeof(List<>).MakeGenericType(tagType);
			data = Activator.CreateInstance(listType);
			loadData();
		}
		/// <summary>
		/// gets all data from tag's column
		/// </summary>
		private void loadData()
		{
			MySQLHandler dbh = new MySQLHandler();
			MySqlConnection conn = dbh.conn;
			conn.Open();
			MySqlCommand cmd = new MySqlCommand("select `" + column + "` from `" + table+"`;", conn); //+ "` where `"+column+"`;", conn);
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				data.Add((dynamic)reader.GetValue(0)); //only should be one column in this datareader
			}
			conn.Clone();
		}
	}

	public class TagManager
	{
		public List<SQLTag> tags;
		public dynamic compoundData;
		Type listType;
        
        public string tagName { get; set; }
		public TagManager(string tagname)
		{
			tags = new List<SQLTag>();
			tagName = tagname;
			var db = new dbEntities();
			var query = from t in db.Tags where t.name == tagname select t;
			foreach (var t in query)
			{
				SQLTag sqltag = new SQLTag(t);
				tags.Add(sqltag);
				listType = sqltag.listType;	
			}
			compoundData = Activator.CreateInstance(listType);
			foreach (var t in tags)
			{
				foreach (var x in t.data)
				{
					compoundData.Add(x);
				}
			}
		}
		/// <summary>
		/// creates instances of tagmanager for all tags in the tag table in the database
		/// </summary>
		/// <returns>List of type tagmanager containing all possible tags that were listed in sql tag table</returns>
		public static List<TagManager> getAllTagManagers()
		{
			List<TagManager> allTMs = new List<TagManager>();
			List<string> usedNames = new List<string>();
			var db = new dbEntities();
			var query = from t in db.Tags where t.name != null select t;
			foreach (var t in query)
			{
				if(!(usedNames.Exists(element => element == t.name)))
				{
					allTMs.Add(new TagManager(t.name));
					usedNames.Add(t.name);
				}
			}
			return allTMs;
			
		}

	}
}
