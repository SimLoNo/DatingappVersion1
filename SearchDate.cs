using DatingappVersion1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatingappVersion1
{
    class SearchDate
    {
        public List<ProfileModel> FindProfiles()
        {
            DatabaseConnection sqlDatabase = new DatabaseConnection();
            DataTable output;
            if (GlobalVariables.LoggedProfile.Gender == 0)
            {
                output = sqlDatabase.FindDates(1);
            }
            else
            {
                output = sqlDatabase.FindDates(0);
            }
            SqlReaderConversion databaseConverter = new SqlReaderConversion();
            List<ProfileModel> profileList = databaseConverter.FindDates(output);
            return profileList;
        }
    }
}
