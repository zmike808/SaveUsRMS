using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSRD
{

    public abstract class FieldBox 
    {
        public string label;

        public abstract string typeToString();

        public dynamic value { get; set; }

        public int x_pos { get; set; }    //x position on the record  
        public int y_pos { get; set; }      //y position on the record

        public int length { get; set; }

        public int height { get; set; }

        protected FieldBox(string _label, int _x, int _y, int _length, int _height) 
        {
            x_pos = _x;
            y_pos = _y;

            length = _length;
            height = _height;

            label = _label;
        }

       

    }

    public class intBox : FieldBox
    {

        public intBox(string _label, int _x, int _y, int _length, int _height, int i) :base(_label, _x, _y, _length, _height)
        {
            value = i;
        }

        public override string typeToString() { return "int"; }
    }

    public class stringBox : FieldBox
    {

        public stringBox(string _label, int _x, int _y, int _length, int _height, string i) :base(_label, _x, _y, _length, _height)
        {
            value = i;
        }
        public override string typeToString() { return "string"; }
    }

    public class doubBox : FieldBox
    {

        public doubBox(string _label, int _x, int _y, int _length, int _height, double i) :base(_label, _x, _y, _length, _height)
        {
            value = i;
        }
        public override string typeToString() { return "double"; }
    }





    //objects to be placed on form and to store data to be saved to a table
    /*public class FieldBox<T>
    {
        public string label;

        public int x_pos;      //x position on the record  
        public int y_pos;      //y position on the record

        public int length;

        public int height;
      

        public T boxValue;     //value of the field
        
        public FieldBox(string _label, int _x, int _y, int _length, int _height, object value) 
        {
            x_pos = _x;
            y_pos = _y;

            length = _length;
            height = _height;

            label = _label;
            boxValue = (T)value;
        }


    }*/
}
