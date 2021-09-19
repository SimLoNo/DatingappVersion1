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
        public int Postal { get; set; }
        public string City { get; set; }
        public DateTime DateTime { get; set; }
    }
        
}
