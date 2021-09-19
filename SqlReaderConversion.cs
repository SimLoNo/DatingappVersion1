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
    }
}
