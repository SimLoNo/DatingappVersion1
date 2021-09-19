using System;
using System.Collections.Generic;

namespace DatingappVersion1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            
            Int16 selected = 0;
            do
            {
                selected = GlobalVariables.allMenu[GlobalVariables.SelectedMenu].FillMenu(selected);
                do
                {
                    
                } while (!Console.KeyAvailable);
                selected = InputController.InputSelector(selected);
                //ConsoleKey pressedKey = Console.ReadKey(true).Key;

                //switch (pressedKey)
                //{
                //    case ConsoleKey.UpArrow:
                //        selected--;
                //        break;
                //    case ConsoleKey.DownArrow:
                //        selected++;
                //        break;
                //    case ConsoleKey.Enter:
                //        allMenu[GlobalVariables.SelectedMenu].RunFunction(selected);
                //        selected = 0;
                //        break;
                //    default:
                //        break;
                //}
            } while (GlobalVariables.RunProgram == true);
        }
    }
}
