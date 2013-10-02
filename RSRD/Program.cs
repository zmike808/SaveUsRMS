using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

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
            //AnimalFilling();
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
            MySQLHandler db = new MySQLHandler();
            //lets flush the table each time we run this so we don't get a billion animals after running it 100 times...that wouldnt be fun.
            string[] animalTableColumns = { "name", "DateofBirth", "image", "estimate", "vaccination", "sterilized", "female", "color", "size", "breed", "crossbreed", "location", "owner", "notes", "species", "status" };
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
                Random r = new Random();
                int x = r.Next(12);
                int z = r.Next(28);
                string ghettostr = "";

                List<string> fieldvals = new List<string>();

                fieldvals.Add(gNames[x%3] + x);

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

                fieldvals.Add(ghettostr);
                   // fieldvals.Add(x % 12 + "/" + x % 30 + "/" + (2000 + x) + " " + x % 12 + ":" + x % 60 + ":" + x % 60);
                fieldvals.Add("");
                fieldvals.Add("false");
                //if (x % 12 < 10 || x % 30 < 10 || x % 60 < 10)
                //    fieldvals.Add("12/12/" + (2000 + x) + " 12:12:12");
                //else
                //    fieldvals.Add(x % 12 + "/" + x % 30 + "/" + (2000 + x) + " " + x % 12 + ":" + x % 60 + ":" + x % 60);
                fieldvals.Add(ghettostr);
                
                fieldvals.Add("true");

                if(r.Next(y) > y)
                    fieldvals.Add("true");
                else
                    fieldvals.Add("false");

                fieldvals.Add(gColors[x%4]);
                fieldvals.Add(aSize[x%3]);

                fieldvals.Add("dragon " + aSpecies[x%3]);
                fieldvals.Add("hedgehog " + aSpecies[x % 3]);
                fieldvals.Add("rpi");
                fieldvals.Add("shirly");
                fieldvals.Add("seems legit");

                fieldvals.Add(aSpecies[x % 3]);

                fieldvals.Add(aStatus[x % 5]);

                db.Insert("animal", columnnames, fieldvals);
            }
        }
        #endregion

    }

}
