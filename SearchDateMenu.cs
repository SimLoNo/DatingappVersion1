using DatingappVersion1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    class SearchDateMenu : Menu
    {
        private List<ProfileModel> ProfileList;
        private enum GenderEnum
            {
            Mand = 0,
            Kvinde = 1
        };
        public override Int16 FillMenu(Int16 selected = 0)
        {
            if (ProfileList is null)
            {
                SearchDate findProfiles = new SearchDate();
                ProfileList = findProfiles.FindProfiles();
            }
            string[] options = new string[] { "Profilindstillinger", "Søg date", "Log ud" }; // Laver et array der indeholder de valgmuligheder brugeren har.
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
                    break;
                case 1:
                    GlobalVariables.SelectedMenu = 4;
                    break;
                default:
                    break;
            }
        }

        public void WriteDateMenu(Int16 selected)
        {
            Console.Clear();
            for (int i = 0; i < ProfileList.Count; i++)
            {
                if (i == selected) // Hvis feltet i arrayet er det brugeren står på, bliver baggrunden groen, for at indikere til brugeren at den er valgt.
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(ProfileList[i].Alias);
                Console.BackgroundColor = ConsoleColor.Black; // Nulstiller baggrundsfarven til sort.
                if (i == selected)
                {
                    WriteProfileInfo(ProfileList[i]);
                }
            }
        }

        public void WriteProfileInfo(ProfileModel profile)
        {
            GenderEnum gender = (GenderEnum)profile.Gender;
            DateTime age = Convert.ToDateTime(DateTime.Now.Date - profile.BirthDate.Date);
            int testWidth = Console.WindowWidth / 2;
            Console.SetCursorPosition(testWidth, 50);
            Console.WriteLine("Alias: " +profile.Alias);
            Console.SetCursorPosition(testWidth, 51);
            Console.WriteLine(@"Postnummer: {Profile.Postal} /t By: {Profile.City}");
            Console.SetCursorPosition(testWidth, 52);
            Console.WriteLine("Køn: " + gender);
            Console.SetCursorPosition(testWidth, 53);
            Console.WriteLine("Alder: " + age.Year);

        }
    }
}
