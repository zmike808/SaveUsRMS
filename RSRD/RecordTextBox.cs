using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSRD
{
    /// <summary>
    /// only really necessary for the RecordAdd form because no other form need reference to the record and fieldbox to change them 
    /// </summary>
    public class RecordTextBox : System.Windows.Forms.TextBox
    {

        public Record attachedRecord;
        public FieldBox attachedFieldBox;



        //the record that it is attached to, and the index it is placed in the records values list
        public RecordTextBox(Record r, int index)
        {
            attachedRecord = r;
            attachedFieldBox = r.values[index];
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
