using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatingappVersion1
{
    class CreateAccount
    {
        private string Email { get; set; }
        private string Password { get; set; }
        private int Phone { get; set; }
        private DateTime CreateDate = DateTime.Today;
        private string Alias { get; set; }
        private int Postal { get; set; }
        private bool Gender { get; set; }
        private DateTime BirthDate { get; set; }
        public void CreateAccountProcess()
        {
            DatabaseConnection sqlDatabase = new DatabaseConnection();
            WriteEmail();
            WritePassword();
            WritePhone();
            int rowsAffected = sqlDatabase.InsertAccount(Email, Password, Phone);
            if (rowsAffected == 1)
            {
                Login loginNewAccount = new Login();
                loginNewAccount.LoginProcess(Email, Password);
            }
        }

        private void WriteEmail()
        {
            string email;
            bool emailAvailable = false;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Indtast din email. Din email vil blive brugt til login");
                    email = Console.ReadLine();
                } while (email.Length < 5 || email.Length > 50);
                DatabaseConnection databaseQuery = new DatabaseConnection();
                SqlReaderConversion queryConverter = new SqlReaderConversion();
                SqlDataReader output = databaseQuery.CheckEmail(email);
                int identicalEmailsInDatabase = queryConverter.SelectCount(output);
                if (identicalEmailsInDatabase == 0)
                {
                    emailAvailable = true;
                }
            } while (! emailAvailable);
            
            Email = email;
        }

        private void WritePassword()
        {
            string password;
            do
            {
                Console.Clear();
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Indtast et kodeord, til brug ved logon.");
                password = Console.ReadLine();
            } while (password.Length < 5 || password.Length > 20);
            Password = password;
        }

        private void WritePhone()
        {
            bool isConvertible;
            int phone;
            do
            {
                Console.Clear();
                Console.WriteLine("Indtast dit telefonnummer, skriv 0 for ikke at angive.");
                string input = Console.ReadLine();
                isConvertible = int.TryParse(input, out phone );
            } while (phone > 99999999 || (phone < 10000000 && phone != 0) || isConvertible == false);
            if(phone != 0)
            {
                Phone = phone;
            }
        }

        private void WriteAlias()
        {
            string alias;
            do
            {
                Console.Clear();
                Console.WriteLine("Indtast dit alias, dit alias er det der bliver brugt til at identificere dig for andre.");
                alias = Console.ReadLine();
            } while (alias.Length < 5 || alias.Length > 50);
            Alias = alias;
        }

    }
}
