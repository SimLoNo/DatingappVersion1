using DatingappVersion1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    class CreateProfile
    {
        public int ProfileId { get; set; }
        public string Alias { get; set; }
        public int Postal { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int AccountId { get; set; }
        public void InitCreateProfile(int accountId)
        {
            GlobalVariables.LoggedProfile = new ProfileModel();
            AccountId = accountId;
            WriteAlias();
            SelectPostal();

        }

        private void WriteAlias()
        {
            // Alias burde vaere have en constraint der goer den unik i databasen, dette blev overset ved oprettelse,
            // og der kan derfor vaere flere profiler med samme alias. Dette kan evt. blive rettet hvis databasen paa et tidspunkt
            // alligevel bliver genskabt.
            string alias;
            do
            {
                Console.Clear();
                Console.WriteLine("Indtast dit ønskede alias. Alias bliver brugt af andre brugere til at identificere dig."); // Alias burde vaere unik i databasen, men det blev glemt da vi oprettede den.
                alias = Console.ReadLine();
            } while (alias.Length > 50 || alias.Length < 3 || string.IsNullOrEmpty(alias));
            GlobalVariables.LoggedProfile.Alias = alias;
        }

        private void SelectPostal()
        {
            Int16 selected = 0;
            GlobalVariables.SelectedMenu = 2;
            List<CityModel> citiesList = new List<CityModel>();
            DatabaseConnection SqlDatabase = new DatabaseConnection();
            citiesList = SqlDatabase.GetCities();
            GlobalVariables.AllCities = citiesList;
            PostalMenu selectPostal = new PostalMenu();
            //do
            //{
            //    selectPostal.FillMenu(selected, citiesList);
            //    do
            //    {

            //    } while (!Console.KeyAvailable);
            //    selected = InputController.InputSelector(selected);

            //} while (Console.ReadKey(true).Key != ConsoleKey.Enter);

        }

        private void SelectGender()
        {

        }
    }
}
