using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DatingappVersion1.Models;

namespace DatingappVersion1
{
    class DatabaseConnection
    {
        // Laver en connection string, der kan tilgaaes af de forskellige metoder i klassen
        private string connString = @"Data Source=SIMONNGF2DATA\H2SQLSOMMERSIMON;Initial Catalog=datingdb;Integrated Security=True"; 

        // Foerste version af login funktionalitet, vil evt. proeve at opdele det i flere metoder, for mere genbrug.
        public DataTable SearchLogin(string email, string password)
        {
            SqlConnection conn = new SqlConnection(connString); // Opretter en sql forbindelse til serveren, med brug af den globale connection string.
            try
            {

                conn.Open(); // Aabner for forbindelsen til databasen.
            }
            catch (Exception errorMessage)
            {
                Console.WriteLine(errorMessage);
                throw;
            }

            string query = "SELECT * FROM account WHERE email = @email AND Password = @Password";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            // Stjaalet kode for at sterilisere input, til at forhindre sql injection.
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@Password", password);
            DataTable data = new DataTable(); // Laver en variable til at holde paa de oplysninger der bliver givet fra databasen.
            SqlDataReader dataReader = sqlCmd.ExecuteReader(); // Laver en datareader der laeser fra databasen.
            data.Load(dataReader); // Henter data fra databasen, og gemmer det i DataTable variablen.
            dataReader.Close();
            conn.Close();
            if(data.Rows.Count == 1) // Hvis der er fundet 1 raekke med passende vaerdier, saa findes brugeren, og brugerens informationer bliver returneret til den kaldende metode.
            {
                return data;
            }
            else // Hvis der er mere eller mindre end 1 raekke med de tilsvarende vaerdier, findes brugeren ikke, eller der er sket en alvorlig fejl i databasen, og en tom vaerdi bliver returneret.
            {
                return new DataTable();
            }
            
        }
        private SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(connString); // Opretter en sql forbindelse til serveren, med brug af den globale connection string.
            try
            {

                conn.Open(); // Aabner for forbindelsen til databasen.
                return conn;
            }
            catch (Exception errorMessage)
            {
                Console.WriteLine(errorMessage);
                throw;
            }
        }

        public SqlDataReader ReadDatabase(SqlCommand sqlCmd)
        {
            SqlConnection conn = OpenConnection();
            sqlCmd.Connection = conn;
            //SqlCommand sqlCmd = new SqlCommand(query., conn);
            SqlDataReader output = sqlCmd.ExecuteReader();
            return output;

        }

        public int WriteDatabase(SqlCommand sqlCmd)
        {
            SqlConnection conn = OpenConnection();
            sqlCmd.Connection = conn;
            int rowsAffected = sqlCmd.ExecuteNonQuery(); //
            conn.Close();
            return 1;
        }

        public SqlDataReader CheckEmail(string email)
        {
            SqlCommand query = new SqlCommand(@"SELECT COUNT(1) FROM account WHERE email = @email");
            query.Parameters.AddWithValue("@email", email);
            SqlDataReader output = ReadDatabase(query);
            return output;
        }

        public int InsertAccount(string email, string password, int phone)
        {
            SqlCommand query = new SqlCommand(@"INSERT INTO account VALUES(@email, @phone, @password, @createDate)");
            query.Parameters.AddWithValue("@email", email);
            query.Parameters.AddWithValue("@phone", phone);
            query.Parameters.AddWithValue("@password", password);
            query.Parameters.AddWithValue("@createDate", DateTime.Now.ToString("yyyy-MM-dd"));
            int rowsAffected = WriteDatabase(query);
            return rowsAffected;
        }

        public SqlDataReader CheckForProfile(int accountId)
        {
            SqlCommand query = new SqlCommand(@"SELECT COUNT(1) FROM profile WHERE accountId = @accountId");
            query.Parameters.AddWithValue("@accountId", accountId);
            SqlDataReader countProfiles = ReadDatabase(query);
            return countProfiles;

        }

        public List<CityModel> GetCities()
        {
            SqlCommand query = new SqlCommand(@"SELECT * FROM city");
            DataTable cityData = new DataTable();
            SqlDataReader output = ReadDatabase(query);
            cityData.Load(output);
            output.Close();
            SqlReaderConversion queryConverter = new SqlReaderConversion();
            List<CityModel> citiesList = queryConverter.SelectCities(cityData);
            return citiesList;
            
            
        }


    }
}
