using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    class Menu
    {
        /*
         * Menu er en base class, der bliver arvet af subclasses for hver specifik menu.
         */
        protected void WriteMenu(Array options, Int16 selected)
        {
            Console.Clear();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selected) // Hvis feltet i arrayet er det brugeren står på, bliver baggrunden groen, for at indikere til brugeren at den er valgt.
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(options.GetValue(i));
                Console.BackgroundColor = ConsoleColor.Black; // Nulstiller baggrundsfarven til sort.
            }
        }

        protected Int16 VerifySelected(Int16 selected, Int16 optionsLength) // Metode der tjekker om vaerdien i selected, er en mulighed i menuen, og retter hvis vaerdien er udenfor.
        {
            if (selected < 0) // Hvis selected er mindre en 0, som er den laveste vaerdi i menuen, so rettes selected til at vaere den hoejeste vaerdi i menuen.
            {
                selected = (short)(optionsLength - 1);
            }
            else if (selected >= optionsLength) // Hvis selected er hoejere en menuens muligheder, rettes selected til at vaere 0, som er den laveste vaerdi i menuen.
            {
                selected = 0;
            }
            return selected;
        }

        public virtual Int16 FillMenu(Int16 selected = 0)
        {
            return 0;
        }

        public virtual void RunFunction(Int16 selected)
        {
        }
    }
}
