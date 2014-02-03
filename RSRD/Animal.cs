using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.Types;


namespace RSRD
{
    /// <summary>
    /// as of 10-28-2013 the Animal Class is basically just a wrapper for the animal db table 
    /// this way all the code done thusfar is still usable #legacySupport #backWardsCompatible
    ///  
    /// </summary>
    public class Animal
    {
        //variables that are public properties will automagically be picked up by the datagridview
        //public enum Species
        //{
        //    Canine,
        //    Feline,
        //    Horse
        //}
        //public enum Size
        //{
        //    Small,
        //    Medium,
        //    Large
        //}
        //public enum Status
        //{
        //    Lost,
        //    Found,
        //    Surrendered,
        //    Adopted,
        //    Fostered
        //}
        //public enum Gender
        //{
        //    Male,
        //    Female
        //}
        //all of the records associated with this particular animal
        //public List<Record> records;

        #region Class Variables
        
        public dbanimal local; //store the db copy of this animal

        public bool female; 
        
       

        //this should not be settable, only gettable since this is the key component in the db
         public int ID {
            get { return local.ID; }
        }


        public string Name
        {
            get { return local.name; }
            set { local.name = value; }
        }

        [System.ComponentModel.DisplayName("Status")]
        public string status
        {
            get { return local.status; }
            set { local.status = value; }
        }

        [System.ComponentModel.DisplayName("Species")]
        public string species
        {
            get { return local.species; }
            set { local.species = value; }
        }

        [System.ComponentModel.Browsable(false)]
        public DateTime vacc
        {
           get { return new MySqlDateTime(local.vaccinationDate.Value).GetDateTime(); }
           set { local.vaccinationDate = (DateTime?)value; }
        }

        [System.ComponentModel.Browsable(false)]
        public bool sterilized
        {
            get { return local.sterilized.Value; }
            set { local.sterilized = value; }
        }
        [System.ComponentModel.Browsable(false)]
        public string gender
        {
            get { return local.gender; }
            set { local.gender = value; }
        }
        [System.ComponentModel.Browsable(false)]
        public string color
        {
            get { return local.color; }
            set { local.color = value; }
        }
        [System.ComponentModel.Browsable(false)]
        public string size
        {
            get { return local.size; }
            set { local.size = value; }
        }
        
        [System.ComponentModel.DisplayName("DOB")]
        public DateTime dob
        {
            get { return new MySqlDateTime(local.DateofBirth.Value).GetDateTime(); }
            set { local.DateofBirth = (DateTime?)value; }
        }
        [System.ComponentModel.Browsable(false)]
        public bool dobIsEstimated
        {
            get { return local.dobIsEstimated.Value; }
            set { local.dobIsEstimated = value; }
        }
        [System.ComponentModel.Browsable(false)]
        public string breed
        {
            get { return local.breed; }
            set { local.breed = value; }
        }
        [System.ComponentModel.Browsable(false)]
        public string crossbreed
        {
            get { return local.crossbreed; }
            set { local.crossbreed = value; }
        }
        [System.ComponentModel.Browsable(false)]
        public string location
        {
            get { return local.location; }
            set { local.location = value; }
        }
        [System.ComponentModel.Browsable(false)]
        public string owner
        {
            get { return local.owner; }
            set { local.owner = value; }
        }
        [System.ComponentModel.Browsable(false)]
        public string notes
        {
            get { return local.notes; }
            set { local.notes = value; }
        }
#endregion
        
        /// <summary>
        /// Creates an Animal from the animal datasource which is linked directly to the animal database table
        /// </summary>
        /// <param name="a">c# animal datasource object</param>
        public Animal(dbanimal a)
        {
            local = a;
            female = local.gender == "Male" ? false : true;
            vacc = local.vaccinationDate.Value;
            sterilized = local.sterilized.Value;
            gender = local.gender;
            color = local.color;
            size = local.size;
            dobIsEstimated = local.dobIsEstimated.Value;
            breed = local.breed;
            crossbreed = local.crossbreed;
            location = local.location;
            owner = local.owner;
            notes = local.notes;
        }

        public Animal()
        {
            local = null;
        }
		

        

    }
}
