using DatingappVersion1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    static class GlobalVariables
    {
        public static Int16 SelectedMenu { get; set; } = 0;
        public static bool RunProgram { get; set; } = true;
        public static AccountModel LoggedUser { get; set; }

        public static ProfileModel LoggedProfile { get; set; }
        public static List<Menu> allMenu = new() { new StartMenu(), new HomeMenu(), new PostalMenu(), new GenderMenu(), new SearchDateMenu() };

        public static List<CityModel> AllCities { get; set; }
    }
}
