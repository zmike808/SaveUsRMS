using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

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
            DBSetup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        #region db stuff
        /// <summary>
        /// setup the database for people who just installed mysql
        /// </summary>
        static void DBSetup()
        {
            //connect
            //ROOT, ROOT IS DEFAULT USERNAME AND PASSWORD, CHANGE TO YOUR OWN SETTINGS IF NEEDED.
            MySQLHandler db = new MySQLHandler("localhost", "root", "root");

            #region database setup
            db.sendCommand("CREATE DATABASE IF NOT EXISTS `test`");
            db.sendCommand("USE `test`");
            db.sendCommand("CREATE TABLE IF NOT EXISTS `animal` (  `ID` int(11) NOT NULL AUTO_INCREMENT,  `name` text,  `DateofBirth` datetime DEFAULT NULL,  `image` longblob,  `estimate` tinyint(1) DEFAULT NULL,  `vaccination` datetime DEFAULT NULL,  `sterilized` tinyint(1) DEFAULT NULL,  `female` tinyint(1) DEFAULT NULL,  `color` text,  `size` text,  `breed` text,  `crossbreed` text,  `location` text,  `owner` text,  `notes` text, `species` text,  `status` text,  PRIMARY KEY (`ID`)) ENGINE=InnoDB AUTO_INCREMENT=372 DEFAULT CHARSET=utf8");
            #endregion

            

        }
        /*
         * doesnt work cause seabass is a bitch making me hardcode so much shit, needs to fill with the proper shit seabass can do it. /endrant
        /// <summary>
        /// provides that nice animal filling...
        /// but no really, it just populates the animal table with random strings of numbers for the name and breed
        /// </summary>
        static void AnimalFilling()
        {
            MySQLHandler db = new MySQLHandler("localhost", "test", "root", "root");
            //lets flush the table each time we run this so we don't get a billion animals after running it 100 times...that wouldnt be fun.
            db.sendCommand("TRUNCATE 'animal'");
            string[] animalTableColumns = { "name", "DateofBirth", "image", "estimate", "vaccination", "sterilized", "female", "color", "size", "breed", "crossbreed", "location", "owner", "notes", "species", "status" };
            List<string> columnnames = new List<string>(animalTableColumns);

            //FILL IT UP
            for (int x = 1; x < 75; x++)
            {
                List<string> fieldvals = new List<string>();   
            
                for (int y = 1; y <= 16; y++)
                {
                    int c = x + y;
                    fieldvals.Add(c.ToString());
                }
                Debug.WriteLine(fieldvals.ToString());
                db.Insert("animal", columnnames, fieldvals);
            }
        }*/
        #endregion

    }

}
