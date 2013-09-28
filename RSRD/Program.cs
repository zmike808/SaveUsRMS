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
            string[] gNames = { "doge", "meowmeow", "horse?" };
            string[] gColors = { "white", "black", "rainbow" };

            //FILL IT UP
            for (int x = 1; x < 75; x++)
            {
                List<string> fieldvals = new List<string>();

                fieldvals.Add(gNames[x%3] + x);
                if(x%12 < 10 || x%30 < 10 || x%60 < 10)
                    fieldvals.Add("12/12/" + (2000 + x) + " 12:12:12");
                else
                    fieldvals.Add(x % 12 + "/" + x % 30 + "/" + (2000 + x) + " " + x % 12 + ":" + x % 60 + ":" + x%60);
                fieldvals.Add("");
                fieldvals.Add("false");
                if (x % 12 < 10 || x % 30 < 10 || x % 60 < 10)
                    fieldvals.Add("12/12/" + (2000 + x) + " 12:12:12");
                else
                    fieldvals.Add(x % 12 + "/" + x % 30 + "/" + (2000 + x) + " " + x % 12 + ":" + x % 60 + ":" + x % 60);
                
                fieldvals.Add("true");
                fieldvals.Add("false");
                fieldvals.Add(gColors[x%3]);
                fieldvals.Add(aSize[x%3]);

                fieldvals.Add("dragon " + aSpecies[x%3]);
                fieldvals.Add("unicorn " + aSpecies[x % 3]);
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
