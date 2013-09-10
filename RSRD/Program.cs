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
            AnimalFilling();
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
            db.sendCommand("CREATE DATABASE IF NOT EXISTS test");
            db.sendCommand("USE test");
            db.sendCommand("CREATE TABLE IF NOT EXISTS `Animal` (`ID` INT NOT NULL AUTO_INCREMENT ,`name` TEXT NULL DEFAULT NULL ,  `DateofBirth` DATETIME NULL DEFAULT NULL ,  `image` LONGBLOB NULL DEFAULT NULL ,  `estimate` TINYINT(1) NULL DEFAULT NULL ,  `vaccination` DATETIME NULL DEFAULT NULL ,  `sterilized` TINYINT(1) NULL DEFAULT NULL ,  `female` TINYINT(1) NULL DEFAULT NULL ,  `color` TEXT NULL DEFAULT NULL ,  `size` TEXT NULL DEFAULT NULL ,  `breed` TEXT NULL DEFAULT NULL ,  `crossbreed` TEXT NULL DEFAULT NULL ,  `location` TEXT NULL DEFAULT NULL ,  `owner` TEXT NULL DEFAULT NULL ,  `notes` TEXT NULL DEFAULT NULL ,  PRIMARY KEY (`ID`) )");
            #endregion

            

        }
        /// <summary>
        /// provides that nice animal filling...
        /// but no really, it just populates the animal table with random strings of numbers for the name and breed
        /// </summary>
        static void AnimalFilling()
        {
            MySQLHandler db = new MySQLHandler("localhost", "test", "root", "root");
            List<string> columnnames = new List<string>();
            columnnames.Add("name");
            columnnames.Add("breed");
            //lets flush the table each time we run this so we don't get a billion animals after running it 100 times...that wouldnt be fun.
            db.sendCommand("TRUNCATE 'animal'");

            //FILL IT UP
            for (int x = 1; x < 75; x++)
            {
                Random r = new Random();

                List<string> fieldvals = new List<string>();
                string a = "" + x * r.Next(x); ;
                string b = "" + x * r.Next(x); ;
                fieldvals.Add(a);
                fieldvals.Add(b);
                db.Insert("animal", columnnames, fieldvals);
            }
        }
        #endregion

    }

}
