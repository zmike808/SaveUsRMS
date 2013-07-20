using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSRD
{
    public class RecordTab : System.Windows.Forms.TabPage
    {

        public Record rec;

        

        public RecordTab(Record r) 
        {
            rec = r;
        }
    }
}
