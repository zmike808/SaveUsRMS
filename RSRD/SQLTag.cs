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
	class SQLTag
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
		public SQLTag(Tag t)
		{
			tag = t;
			tagType = Type.GetType(tag.type);
			listType = typeof(List<>).MakeGenericType(tagType);
			data = Activator.CreateInstance(listType);
			loadData();
		}

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
	class TagManager
	{
		public List<SQLTag> tags;
		public dynamic compoundData;
		Type listType;
		public string tagName;
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

	}
}
