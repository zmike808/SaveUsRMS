using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSRD
{
    public class RecordTextBox : System.Windows.Forms.TextBox
    {

        Record attachedRecord;
        FieldBox attachedFieldBox;



        //the record that it is attached to, and the index it is placed in the records values list
        public RecordTextBox(Record r, int index)
        {
            
        }

        public RecordTextBox()
        {
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

    }
}
