using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    class GenderMenu : Menu
    {
        private string[] Genders = { "Mand", "Kvinde" };
        public override Int16 FillMenu(Int16 selected = 0)
        {
            selected = VerifySelected(selected, (short)Genders.Count()); // tjekker om vaerdien i selected er indenfor de mulige valg, og retter det hvis det ikke er.
            this.WriteMenu(Genders, selected); // kalder en metode fra baseclass, der skriver selve menuen i konsol.
            return selected;
        }
        public override void RunFunction(Int16 selected)
        {
            if (selected == 0)
            {
                GlobalVariables.LoggedProfile.Gender = false;
            }
            else
            {
                GlobalVariables.LoggedProfile.Gender = true;
            }
        }
    }
}
