using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSRD
{
    public class Animal
    {

        public enum Species 
        {
            Canine,
            Feline,
            Horse
        }

        public enum Size 
        {
            Small,
            Medium,
            Large
        }

        public enum Status 
        {
            Lost,
            Found,
            Surrendered,
            Adopted,
            Fostered
        }

        //all of the records associated with this particular animal
        public List<Record> records;

        public bool vacc = false;

        public bool sterilized = false;

        public bool female = false;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Species _species;

        public Species species
        {
            get { return _species; }
            set { _species = value; }
        }

        public int ID;

        public string color;

        public Size size;

        public DateTime dob;

        public bool dobEstimate;



        public Animal(Species s, Size sz, Status st, string _name, bool _female) 
        {
            species = s;
            size = sz;
            Name = _name;
            female = _female;

        }

        

    }
}
