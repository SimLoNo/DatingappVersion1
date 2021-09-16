using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    class Login
    {
        public void LoginProcess()
        {
            DatabaseConnection sqlDatabase = new DatabaseConnection();
            string email = WriteEmail();
            string password = WritePassword();
            Console.Clear();

            bool loginValid = sqlDatabase.SearchLogin(email,password);
            if(loginValid == true)
            {
                // Saet email til en global email variable, til at holde programmet opdateret om man er logget ind ved visse funktionaliteter.
                // Saet password til en global email variable, til at holde programmet opdateret om man er logget ind ved visse funktionaliteter.
                // Evt. kald en metode der saetter en variable til at lokalt sige man er logget ind, og som i tidsintervaller verificere at man stadig er logget ind.
                Program.selectedMenu = 1;
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
                Program.selectedMenu = 0;
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
