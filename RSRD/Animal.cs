using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSRD
{
  
        
    public class Animal
    {
        //variables that are public properties will automagically be picked up by the datagridview
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
        public enum Gender
        {
            Male,
            Female
        }
        //all of the records associated with this particular animal
        public List<Record> records;

        public DateTime vacc;

        public bool sterilized;

        public bool female;

        private string _name;

        public int ID{get; set;}

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Species _species;

        private Status _status;

        [System.ComponentModel.DisplayName("Status")]
        public Status status
        {
            get { return _status; }
            set { _status = value; }
        }

        [System.ComponentModel.DisplayName("Species")]
        public Species species
        {
            get { return _species; }
            set { _species = value; }
        }

        public string color;

        public Size size;

        [System.ComponentModel.DisplayName("DOB")]
        public DateTime dob { get; set; }

        public bool dobEstimate;

        public string Address;

        public string breed;

        public string crossbreed;

        public string location;

        public string owner;

        public string notes;

        public string image;

        /*
         * Why would anyone ever want to type out all those parameters to create an animal, like really?
         */

        public Animal(int id, string name, DateTime dob, string image, bool estimate, DateTime vaccination, 
            bool sterilized, bool female, string color, string size, string breed, string crossbread, string location, string owner, string notes, Species species, Status status)
        {
            this.ID = id;
            this.Name = name;
            this.dob = dob;
            this.image = image; 
            this.dobEstimate = estimate;
            this.vacc = vaccination;
            this.sterilized = sterilized;
            this.female = female;
            this.color = color;
            this.size = (Size)Enum.Parse(typeof(Animal.Size), size);
            this.breed = breed;
            this.crossbreed = crossbread;
            this.location = location;
            this.owner = owner;
            this.notes = notes;
            this.species = species;
            this.status = status;
        }

     
        /// <summary>
        /// constructs an animal from an array of objects, currently only used for the ui datagridview
        /// though it could end up being easier to use than specifying each variable in the constructor (seen above) 
        /// array is a fixed size, equal to the number of columns in the animal sql table, first column is index 0, and the last column currently being at index 15
        /// Typecasts every entry in the array to the appropriate type of the animal class variable
        ///
        /// </summary>
        /// <param name="a">array of objects pulled from the animal sql table</param>
        public Animal(object[] a)
        {
            //this hardcoding....well it works for now....
            this.ID = (int)a[0];
            this.Name = (string)a[1];
            try
            {
                this.dob = DateTime.Parse((string)a[2]);
            }
            catch
            {
                MessageBox.Show((string)a[2]);
            }
            this.image = (string)a[3];
            this.dobEstimate = Convert.ToBoolean(a[4]);
            this.vacc = DateTime.Parse((string)a[5]);
            this.sterilized = Convert.ToBoolean((string)a[6]);
            this.female = Convert.ToBoolean((string)a[7]);
            this.color = (string)a[8];
            this.size = (Size)Enum.Parse(typeof(Animal.Size), (string)a[9]);
            this.breed = (string)a[10];
            this.crossbreed = (string)a[11];
            this.location = (string)a[12];
            this.owner = (string)a[13];
            this.notes = (string)a[14];
            this.species = (Species)Enum.Parse(typeof(Animal.Species), (string)a[15]);
            this.status = (Status)Enum.Parse(typeof(Animal.Status), (string)a[16]);

        }

        /// <summary>
        /// this is just a fugly method that just gets shit done...
        /// useful for taking an animal object and changing it into a list of strings, which is required for using the mysql database accessor/manipulator methods
        /// but really, don't look at this method, its just...not worth it.
        /// </summary>
        /// <param name="a">Animal object to convert to list of strings</param>
        /// <returns>List of strings</returns>
       public static List<string> toList(Animal a)
        {
            List<string> ao = new List<string>();

            //all the hardcodings...cutler would frown
           //but srsly, thankgod for tostring methods, or this shit would have been like 100x more fugly...
         //   ao.Add(a.ID.ToString()); don't add this mysql takes care of that
            ao.Add(a.Name);
            ao.Add(a.dob.ToString());
            ao.Add(a.image);
            ao.Add(a.dobEstimate.ToString());
            ao.Add(a.vacc.ToString());
            ao.Add(a.sterilized.ToString());
            ao.Add(a.female.ToString());
            ao.Add(a.color);
            ao.Add(a.size.ToString());
            ao.Add(a.breed);
            ao.Add(a.crossbreed);
            ao.Add(a.location);
            ao.Add(a.owner);
            ao.Add(a.notes);
            ao.Add(a.species.ToString());
            ao.Add(a.status.ToString());
           
            return ao;
        }



        

    }
}
