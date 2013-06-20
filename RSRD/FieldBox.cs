using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSRD
{
    //objects to be placed on form and to store data to be saved to a table
    public class FieldBox<T>
    {

        public string label;

        int x_pos;      //x position on the record  
        int y_pos;      //y position on the record

        T boxValue;     //value of the field
        
        public FieldBox(string _label, int _x, int _y, object value) 
        {
            x_pos = _x;
            y_pos = _y;

            label = _label;
            boxValue = (T)value;
        }


    }
}
