using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Text;
using System.Data.Objects;

//misc. classes that are used for general utility should go in this file. (i.e.: not directly related to the database: image handling/saving/etc, file io, etc) 
namespace RSRD
{
	public partial class ImageUtility
	{

		public ImageUtility()
		{

		}

		private bool localImageExists(string img)
		{
			return File.Exists("./images/" + img);
		}

		private IQueryable<int> getImageIDs()
		{
			dbEntities db = new dbEntities();
			IQueryable<int> query = from i in db.recordImages where i.id >= 1 select i.id;
			return query;

		}
		private ObjectQuery<recordImage> selectImages(int imgID)
		{
			dbEntities db = new dbEntities();
			dynamic query = from i in db.recordImages where i.id >= imgID select i;
			return query;
		}

		private recordImage selectImage(int imgID)
		{
			dbEntities db = new dbEntities();
			var query = from i in db.recordImages where i.id == imgID select i;
			return query.First();
		}

		public void preload()
		{
			if (!(Directory.Exists("./images")))
			{
				Directory.CreateDirectory("./images");
				getAllImages();
			}
			else
			{
				updateImages();
			}
		}
		/// <summary>
		/// save image to the local images directory
		/// </summary>
		/// <param name="img">image from the DB to save locally</param>
		public void saveLocalImage(recordImage img)
		{
			MemoryStream ms = new MemoryStream(img.image);
			Image i = Image.FromStream(ms,true,true);
			i.Save("./images/"+img.id.ToString()+"."+img.type);
		}
		/// <summary>
		/// add image to the database
		/// </summary>
		/// <param name="img">image to add to the database</param>
		public void saveRemoteImage(Image img)
		{
			dbEntities db = new dbEntities();
			string imgType = new ImageFormatConverter().ConvertToString(img.RawFormat).ToLower();
			var query = from i in db.recordImages where i.id > 0 select i.id;
			int lastID = query.Max();
			ImageConverter converter = new ImageConverter();
			byte[] imgArray = (byte[])converter.ConvertTo(img, typeof(byte[]));

			recordImage newRecordImage = recordImage.CreaterecordImage(lastID+1,imgArray,imgType);
			db.recordImages.AddObject(newRecordImage);
			db.SaveChanges();
		}

	
		public void getAllImages()
		{
			dynamic query = selectImages(1);
			foreach(dynamic img in query)
			{
				saveLocalImage(img);
			}
		}

		/// <summary>
		/// check if image exists locally, relies on the assumption that autoincrementing values in the database will always be consistant, 1,2,3,4,....,n 
		/// </summary>
		public void updateImages()
		{
			var query = getImageIDs();
			int lastID = query.Max();
			List<string> files = Directory.GetFiles("./images/").ToList<string>();
			foreach (var id in query)
			{
				
				//files.Contains(id.ToString(),
				if (!(files.Any(str => str.Contains(id.ToString()))))//localImageExists(x.ToString() + "." + type)))
				{

					var img = selectImage(id);
					saveLocalImage(img);
				}
			}
		}

	}
}
