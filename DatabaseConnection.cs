using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatingappVersion1
{
    class DatabaseConnection
    {
        // Laver en connection string, der kan tilgaaes af de forskellige metoder i klassen
        private string connString = @"Data Source=SIMONNGF2DATA\H2SQLSOMMERSIMON;Initial Catalog=datingdb;Integrated Security=True"; 

        // Foerste version af login funktionalitet, vil evt. proeve at opdele det i flere metoder, for mere genbrug.
        public bool SearchLogin(string email, string password)
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

            string query = "SELECT COUNT(1) FROM account WHERE email = @email AND Password = @Password";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            // Stjaalet kode for at sterilisere input, til at forhindre sql injection.
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@Password", password);
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            conn.Close();
            if(count == 1)
            {
                return true;
            }
            else
            {
                return false;
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

        public int CheckEmail(string email)
        {
            SqlCommand query = new SqlCommand(@"SELECT COUNT(1) FROM account WHERE email = @email");
            query.Parameters.AddWithValue("@email", email);
            int output = Convert.ToInt32(ReadDatabase(query));
            return output;
        }
    }
}
