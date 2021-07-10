using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;


namespace AlfieOS
{
    internal class Terminal 
    {
        private string input;

        public Terminal(string input)
        {
            if (input == "help")
            {
                Console.WriteLine("help -- Shows help infomation");
                Console.WriteLine("restart -- Reboot the machine");
                Console.WriteLine("shutdown -- Shutdown the machine");
            }
            else if (input == "restart")
            {
                Sys.Power.Reboot();
            }
            else if (input == "shutdown")
            {
                Sys.Power.Shutdown();
            }
        }
    }
}