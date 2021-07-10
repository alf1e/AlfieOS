using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;

namespace AlfieOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("");
        }

        protected override void Run()
        {
            string input = "";
            input = Console.ReadLine();
            Terminal(input);
        }
        private void Terminal(string input)
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
