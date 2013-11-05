using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using System.Text;

namespace RSRD
{
    static class Program
    {
		
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        #region db stuff
        
        /// <summary>
        /// provides that nice animal filling...
        /// but no really, it just populates the animal table with random strings of numbers for the name and breed
        /// </summary>
        static void AnimalFilling()
        {
            dbEntities db = new dbEntities();
           
            //lets flush the table each time we run this so we don't get a billion animals after running it 100 times...that wouldnt be fun.
            string[] animalTableColumns = { "name", "DateofBirth", "dobIsEstimated", "vaccinationDate", "sterilized", "gender", "color", "size", "breed", "crossbreed", "location", "owner", "notes", "species", "status" };
            List<string> columnnames = new List<string>(animalTableColumns);
           
            //add that variety for testing
            string[] aSpecies = { "Canine", "Feline", "Horse" };
            string[] aSize = { "Small", "Medium", "Large" };
            string[] aStatus = { "Lost", "Found", "Surrendered", "Adopted", "Fostered" };
            string[] gNames = { "doge", "meowmeow", "unicorn" };
            string[] gColors = { "white", "black", "rainbow", "magic" };
            //FILL IT UP
            for (int y = 1; y < 200; y++)
            {
                dbanimal a = dbanimal.Createdbanimal(y);
               
                Random r = new Random();
                int x = r.Next(12);
                int z = r.Next(28);
                string ghettostr = "";

                a.name = gNames[x % 3] + x;

                if (x % 12 == 0)
                    ghettostr += "12/";
                else if (x % 12 < 10)
                    ghettostr += "0" + x % 12 + "/";
                else
                    ghettostr += x % 12 + "/";

                if (z % 28 == 0)
                    ghettostr += "28/";
                else if (z % 28 < 10)
                    ghettostr += "0" + z % 28 + "/";
                else
                    ghettostr += z % 28 + "/";

                ghettostr += (2000 + x) + " 11:11:11";

               a.DateofBirth = (Convert.ToDateTime(ghettostr));
                   // fieldvals.Add(x % 12 + "/" + x % 30 + "/" + (2000 + x) + " " + x % 12 + ":" + x % 60 + ":" + x % 60);
               // fieldvals.Add("");
                a.dobIsEstimated = (false);
                //if (x % 12 < 10 || x % 30 < 10 || x % 60 < 10)
                //    fieldvals.Add("12/12/" + (2000 + x) + " 12:12:12");
                //else
                //    fieldvals.Add(x % 12 + "/" + x % 30 + "/" + (2000 + x) + " " + x % 12 + ":" + x % 60 + ":" + x % 60);
                a.vaccinationDate = (Convert.ToDateTime(ghettostr));
                
                a.sterilized = (true);

                if(r.Next(y) > y)
                    a.gender = ("Male");
                else
                    a.gender = ("Female");

                a.color = (gColors[x%4]);
                a.size = (aSize[x%3]);

                a.breed = ("dragon " + aSpecies[x%3]);
                a.crossbreed = ("hedgehog " + aSpecies[x % 3]);
                a.location = ("rpi");
                a.owner = ("shirly");
                a.notes = ("seems legit");

                a.species = (aSpecies[x % 3]);

                a.status = (aStatus[x % 5]);
                db.dbanimals.AddObject(a);
                db.SaveChanges();
            }
            
            
        }

		
		#endregion

    }

	//best coding practices NA
	//public class loltemp
	//{
	//    private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
	//    private string RandomString(int size)
	//    {
	//        StringBuilder builder = new StringBuilder();
	//        char ch;
	//        for (int i = 0; i < size; i++)
	//        {
	//            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
	//            builder.Append(ch);
	//        }

	//        return builder.ToString();
	//    }

	//    public void orggen()
	//    {
	//        dbEntities db = new dbEntities();

	//        for (int x = 1; x <= 10; x++)
	//        {
	//            Organization o = Organization.CreateOrganization(x);

	//            o.name = RandomString(10);
	//            o.address = RandomString(10);
	//            o.phone = RandomString(10);
	//            o.email = RandomString(10);
	//            o.fax = RandomString(10);
	//            o.website = RandomString(10);
	//            o.aboutus = RandomString(10);
	//            o.hours = RandomString(10);
	//            o.servicesprovided = RandomString(10);

	//            db.Organizations.AddObject(o);
	//            db.SaveChanges();

	//        }
	//    }
	//}

}
