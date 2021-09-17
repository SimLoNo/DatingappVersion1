using System;
using System.Collections.Generic;

namespace DatingappVersion1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            List<Menu> allMenu = new() {new StartMenu(), new HomeMenu()};
            Int16 selected = 0;
            do
            {
                selected = allMenu[GlobalVariables.selectedMenu].FillMenu(selected);
                do
                {

                } while (!Console.KeyAvailable);
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
                        allMenu[GlobalVariables.selectedMenu].RunFunction(selected);
                        selected = 0;
                        break;
                    default:
                        break;
                }
            } while (GlobalVariables.runProgram == true);
        }
    }
}
