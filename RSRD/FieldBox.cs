using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSRD
{
    /// <summary>
    /// When implementing a subclass, be sure to add the type to the boxtypes enumeration
    /// </summary>
    public abstract class FieldBox 
    {

        public enum boxtypes 
        {
            intBox,
            stringBox,
            doubBox,
            dateTimeBox
        }

        public dynamic value { get; set; }
        public boxtypes type;

        public int x_pos { get; set; }    //x position on the record  
        public int y_pos { get; set; }      //y position on the record

        public int length { get; set; }
        public int height { get; set; }

        protected FieldBox(int _x, int _y, int _length, int _height) 
        {
            x_pos = _x;
            y_pos = _y;

            length = _length;
            height = _height;
        }

        public abstract string typeToString();

        //try to parse the value to the value type, return false if it cant
        public abstract bool isDataValid(string s);


    }

    public class intBox : FieldBox
    {
        public intBox(int _x, int _y, int _length, int _height, int i) :base(_x, _y, _length, _height)
        {
            value = new int();
            value = i;
            type = FieldBox.boxtypes.intBox;
        }
        public override string typeToString() { return "int"; }
        public override bool isDataValid(string s)
        {
            int place;
            if (int.TryParse(s, out place)) 
            {
                value = place;
                return true;
            }
                
            return false;
        }
    }

    public class stringBox : FieldBox
    {
        public stringBox(int _x, int _y, int _length, int _height, string i) :base(_x, _y, _length, _height)
        {
			value = i;
            type = FieldBox.boxtypes.stringBox;
        }
        public override string typeToString() { return "string"; }
		public override bool isDataValid(string s)
		{
			value = s;
			return true;}
    }

    public class doubBox : FieldBox
    {
        public doubBox(int _x, int _y, int _length, int _height, double i) :base(_x, _y, _length, _height)
        {
            value = new double();
            value = i;
            type = boxtypes.doubBox;
        }
        public override string typeToString() { return "double"; }

        public override bool isDataValid(string s)
        {
            double place;
            if (double.TryParse(s, out place)) 
            {
                value = place;
                return true;
            }
                
            return false;
        }
    }

    public class dateTimeBox : FieldBox
    {
        public dateTimeBox(int _x, int _y, int _length, int _height, DateTime i): base(_x, _y, _length, _height)
        {
            value = new DateTime();
            value = i;
            type = boxtypes.dateTimeBox;
        }
        public override string typeToString() { return "DateTime"; }
        public override bool isDataValid(string s)
        {
            DateTime place;
            if (DateTime.TryParse(s, out place))
            {
                value = place;
                return true;
            }

            return false;
        }
    }
}
