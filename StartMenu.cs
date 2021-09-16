using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    class StartMenu : Menu
    {
        public override  Int16 FillMenu(Int16 selected = 0)
        {
            string[] options = new string[] { "Login", "Create account", "Quit program" }; // Laver et array der indeholder de valgmuligheder brugeren har.
            selected = VerifySelected(selected, (short)options.Length); // tjekker om vaerdien i selected er indenfor de mulige valg, og retter det hvis det ikke er.
            this.WriteMenu(options, selected); // kalder en metode fra baseclass, der skriver selve menuen i konsol.
            Console.WriteLine(selected);
            return selected;

        }

        public override void RunFunction(short selected)
        {
            switch (selected)
            {
                case 0:
                    Login loginMethod = new Login();
                    loginMethod.LoginProcess();
                    break;
                case 1:
                    CreateAccount accountCreation = new CreateAccount();
                    accountCreation.CreateAccountProcess();
                    break;
                case 2:
                    CloseProgram shutdown = new CloseProgram();
                    shutdown.ShutdownProgram();
                    break;
                default:
                    break;
            }
        }
    }
}
