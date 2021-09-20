using DatingappVersion1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    class PostalMenu : Menu
    {
        public CityModel[] CityArray { get; set; }
        public override Int16 FillMenu(Int16 selected = 0)
        {
            Console.WriteLine("Writing zip-codes!");
            CityArray = GlobalVariables.AllCities.ToArray();
            Console.WriteLine("CityArray: " + CityArray.ToString()) ;
            Console.WriteLine("Global variable: " + GlobalVariables.AllCities.ToString());
            selected = VerifySelected(selected, (short)CityArray.Count()); // tjekker om vaerdien i selected er indenfor de mulige valg, og retter det hvis det ikke er.
            this.WritePostalMenu(selected); // kalder en metode fra baseclass, der skriver selve menuen i konsol.
            return selected;
        }
        public override void RunFunction(Int16 selected )
        {
            GlobalVariables.LoggedProfile.Postal = GlobalVariables.AllCities[selected].Postal;
        }

        public void WritePostalMenu(Int16 selected)
        {
            Console.Clear();
            for (int i = 0; i < CityArray.Length; i++)
            {
                if (i == selected) // Hvis feltet i arrayet er det brugeren står på, bliver baggrunden groen, for at indikere til brugeren at den er valgt.
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(CityArray[i].Postal + " " + CityArray[i].City);
                Console.BackgroundColor = ConsoleColor.Black; // Nulstiller baggrundsfarven til sort.
            }
        }
    }
}
