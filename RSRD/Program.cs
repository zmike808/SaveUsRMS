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
            DBTest();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        #region hardcoded DB Testing
        static void DBTest()
        {
            //connect
            //ROOT, ROOT IS DEFAULT USERNAME AND PASSWORD, CHANGE TO YOUR OWN SETTINGS IF NEEDED.
            MySQLHandler db = new MySQLHandler("localhost", "test", "root", "root");

            #region database setup (DO NOT EDIT)
            if (db.sendCommand("CREATE DATABASE IF NOT EXISTS test"))
            {
                db.sendCommand("CREATE  TABLE IF NOT EXISTS `Animal` (`ID` INT NOT NULL AUTO_INCREMENT ,`name` TEXT NULL DEFAULT NULL ,  `DateofBirth` DATETIME NULL DEFAULT NULL ,  `image` LONGBLOB NULL DEFAULT NULL ,  `estimate` TINYINT(1) NULL DEFAULT NULL ,  `vaccination` DATETIME NULL DEFAULT NULL ,  `sterilized` TINYINT(1) NULL DEFAULT NULL ,  `female` TINYINT(1) NULL DEFAULT NULL ,  `color` TEXT NULL DEFAULT NULL ,  `size` TEXT NULL DEFAULT NULL ,  `breed` TEXT NULL DEFAULT NULL ,  `crossbreed` TEXT NULL DEFAULT NULL ,  `location` TEXT NULL DEFAULT NULL ,  `owner` TEXT NULL DEFAULT NULL ,  `notes` TEXT NULL DEFAULT NULL ,  PRIMARY KEY (`ID`) )");
            }
            #endregion

            #region multi-field insert test
            List<string> list1 = new List<string>();
            for(int x = 0; x<2;x++)
            {
                 list1.Add("string");
            }

            if (!db.createTable("test1", list1))
            {
                Debug.WriteLine("TABLE CREATION FAILED, PROBABLY ALREADY EXISTS. NO WORRIES THO, JUST SAYIN");
            }


            List<string> list2 = new List<string>();
            string[] q = {"aaa","bbb","ccc"};
            list2.AddRange(q);

            db.Insert("test1", list1, list2);
            #endregion

        }
        #endregion
    }

}
