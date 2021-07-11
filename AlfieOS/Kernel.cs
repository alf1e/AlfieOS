using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using AlfieOS.terminal;
using Alfie

namespace AlfieOS
{
    public class Kernel : Sys.Kernel
    {
        public string acc;

        protected override void BeforeRun()
        {
            acc = "Home";
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.WriteLine("");
        }

        protected override void Run()
        {
            string input = "";
            Console.Write(acc + ": ");
            input = Console.ReadLine();
            if (input.StartsWith("sudo ")) {
                input.Remove(0, 5);
                Ter.Terminal(input.Remove(0, 5), true);
                }
            else { Ter.Terminal(input, false); }
            
        }
        public static void rExpection(int ecode)
        {
            string emsg = "";
            if (ecode == 503)
            {
                emsg = "Action not permitted";
            }
            Console.WriteLine("Error " + ecode + ": " + emsg);
        }
    }
}
