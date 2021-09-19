using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingappVersion1
{
    class CloseProgram
    {
        public void ShutdownProgram()
        {
            GlobalVariables.RunProgram = false;
        }
    }
}
