using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    static class InputController
    {
        public static Int16 InputSelector(Int16 selected)
        {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                    selected--;
                    break;
                case ConsoleKey.DownArrow:
                    selected++;
                    break;
                case ConsoleKey.Enter:
                    GlobalVariables.allMenu[GlobalVariables.SelectedMenu].RunFunction(selected);
                    selected = 500;
                    break;
                default:
                    break;
            }
            return selected;
        }
    }
}
