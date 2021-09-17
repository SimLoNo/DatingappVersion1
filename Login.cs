using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatingappVersion1
{
    class Login
    {
        public void LoginProcess()
        {
            string email = WriteEmail();
            string password = WritePassword();
            Console.Clear();
            VerifyLogin(email, password);



        }
        public void LoginProcess(string email, string password)
        {
            Console.Clear();
            VerifyLogin(email, password);
        }

        public void VerifyLogin(string email, string password)
        {
            DatabaseConnection sqlDatabase = new DatabaseConnection();
            DataTable output = sqlDatabase.SearchLogin(email, password);
            int numRows = output.Rows.Count;
            if (numRows == 1)
            {
                AccountModel user = new AccountModel(output);
                // Saet email til en global email variable, til at holde programmet opdateret om man er logget ind ved visse funktionaliteter.
                // Saet password til en global email variable, til at holde programmet opdateret om man er logget ind ved visse funktionaliteter.
                // Evt. kald en metode der saetter en variable til at lokalt sige man er logget ind, og som i tidsintervaller verificere at man stadig er logget ind.
                GlobalVariables.selectedMenu = 1;
            }
            else
            {
                // nulstil global email variable.
                // nulstil global password variable
                // Evt. kald en metode der saetter en variable til at sige man ikke er logged ind.
                Console.WriteLine("Email eller kodeord er forkert, tryk på en tast for at prøve igen.");
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Kodeord: " + password);
                Console.ReadKey(false);
                GlobalVariables.selectedMenu = 0;
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
    }
}
