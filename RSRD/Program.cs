using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            MySQLHandler db = new MySQLHandler("localhost", "test", "root", "root");
            #region multi-field insert test
            List<string> list1 = new List<string>();
            string[] s = {"name","age","bla"};
            list1.AddRange(s);

            List<string> list2 = new List<string>();
            string[] q = {"aaa","bbb","ccc"};
            list2.AddRange(q);

            db.Insert("test1", list1, list2);
            #endregion

        }
        #endregion
    }
}
