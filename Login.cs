using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatingappVersion1
{
    class Login
    {
        public void LoginProcess()
        {
            string email = WriteEmail();
            string password = WritePassword();
            Console.Clear();
            bool isLogged = VerifyLogin(email, password);
            if (isLogged == true)
            {
                bool profileExist = CheckForProfile(GlobalVariables.LoggedUser.AccountId);
                if (profileExist == true)
                {
                    GlobalVariables.SelectedMenu = 1; // Skifter den viste menu til hovedmenuen.
                }
                else
                {
                    CreateProfile profileCreation = new CreateProfile();
                    profileCreation.InitCreateProfile(GlobalVariables.LoggedUser.AccountId);
                }
            }
            



        }
        public void LoginProcess(string email, string password)
        {
            Console.Clear();
            VerifyLogin(email, password);
        }

        public bool VerifyLogin(string email, string password)
        {
            DatabaseConnection sqlDatabase = new DatabaseConnection();
            DataTable output = sqlDatabase.SearchLogin(email, password);
            int numRows = output.Rows.Count;
            if (numRows == 1)
            {
                AccountModel user = new AccountModel(output);
                GlobalVariables.LoggedUser = user; // Gemmer informationerne for brugeren.
                //GlobalVariables.SelectedMenu = 1; // Skifter den viste menu til hovedmenuen.
                return true;
            }
            else
            {
                GlobalVariables.SelectedMenu = 0;
                GlobalVariables.LoggedUser = null;
                Console.WriteLine("Email eller kodeord er forkert, tryk på en tast for at prøve igen.");
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Kodeord: " + password);
                Console.ReadKey(false);
                return false;
            }
        }

        private string WriteEmail()
        {
            Console.Clear();
            Console.WriteLine("Email");
            string email = Console.ReadLine();
            return email;
        }

        private string WritePassword()
        {
            Console.Clear();
            Console.WriteLine("Kodeord");
            string Password = Console.ReadLine();
            return Password;
        }

        public bool CheckForProfile(int accountId)
        {
            DatabaseConnection SqlDatabase = new DatabaseConnection();
            SqlDataReader output = SqlDatabase.CheckForProfile(accountId);
            SqlReaderConversion sqlConverter = new SqlReaderConversion();
            int countProfiles = sqlConverter.SelectCount(output);
            if (countProfiles == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
