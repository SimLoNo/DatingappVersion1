using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatingappVersion1.Models;
using System.Data;

namespace DatingappVersion1
{
    class SqlReaderConversion
    {
        public int SelectCount(SqlDataReader output)
        {
            int returnCountFromDatabase = 0;
            while (output.Read())
            {
                returnCountFromDatabase = output.GetInt32(0);
            }
            return returnCountFromDatabase;
        }
        public List<CityModel> SelectCities(DataTable output)
        {
            List<CityModel> citiesList = new List<CityModel>();
            foreach (DataRow row in output.Rows)
            {
                int postal = Convert.ToInt32(row["postal"]);
                string cityName = row["city"].ToString();
                CityModel city = new CityModel(postal, cityName);
                citiesList.Add(city);
            }
            return citiesList;
        }

        public List<ProfileModel> FindDates(DataTable output)
        {
            SqlReaderConversion dataConverter = new SqlReaderConversion();
            List<ProfileModel> profilesList = new List<ProfileModel>();
            foreach (DataRow row in output.Rows)
            {
                string alias = row["alias"].ToString();
                int postal = Convert.ToInt32(row["postal"]);
                string cityName = row["city"].ToString();
                Int16 gender = Convert.ToInt16(row["gender"]);
                DateTime birthDate = Convert.ToDateTime(row["birthDate"]);
                ProfileModel profile = new ProfileModel(alias, gender, postal, cityName, birthDate);
                profilesList.Add(profile);
            }
            return profilesList;
        }
    }
}
