using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1.Models
{
    class ProfileModel
    {
        public int ProfileId { get; set; }
        public string Alias { get; set; }
        public Int16 Gender { get; set; }
        public int Postal { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }

        public ProfileModel()
        {

        }
        public ProfileModel(string alias, Int16 gender, int postal, string city, DateTime birthDate)
        {
            Alias = alias;
            Gender = gender;
            Postal = postal;
            City = city;
            BirthDate = birthDate;
        }
    }
        
}
