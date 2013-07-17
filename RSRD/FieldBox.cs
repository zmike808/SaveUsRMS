using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSRD
{

    public abstract class FieldBox 
    {

        public enum boxtypes 
        {
            intBox,
            stringBox,
            doubBox
        }

        public string label;
        public dynamic value { get; set; }
        public boxtypes type;

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

        public abstract string typeToString();


    }

    public class intBox : FieldBox
    {
        public intBox(string _label, int _x, int _y, int _length, int _height, int i) :base(_label, _x, _y, _length, _height)
        {
            value = i;
            type = FieldBox.boxtypes.intBox;
        }
        public override string typeToString() { return "int"; }
    }

    public class stringBox : FieldBox
    {
        public stringBox(string _label, int _x, int _y, int _length, int _height, string i) :base(_label, _x, _y, _length, _height)
        {
            value = i;
            type = FieldBox.boxtypes.stringBox;
        }
        public override string typeToString() { return "string"; }
    }

    public class doubBox : FieldBox
    {
        public doubBox(string _label, int _x, int _y, int _length, int _height, double i) :base(_label, _x, _y, _length, _height)
        {
            value = i;
            type = boxtypes.doubBox;
        }
        public override string typeToString() { return "double"; }
    }
}
