using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1.Models
{
    class CityModel
    {
        public int Postal { get; set; }
        public string City { get; set; }
        public CityModel(int postal, string city)
        {
            Postal = postal;
            City = city;
        }
    }

    
}
