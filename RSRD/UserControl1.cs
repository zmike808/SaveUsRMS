using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSRD
{
    public partial class UserControl1 : UserControl
    {


        Record parentRecord;
        int recordIndex;
        FieldBox f;

        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(Record r, int index, FieldBox f) 
        {
            parentRecord = r;
            recordIndex = index;
            InitializeComponent();
            label1.Text = f.label;
        }

    }
}
