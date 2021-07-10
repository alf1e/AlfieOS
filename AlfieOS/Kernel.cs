using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;

namespace AlfieOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            var acc = "Home";
            Console.Clear();
            Console.WriteLine("");
        }

        protected override void Run()
        {
            string input = "";
            input = Console.ReadLine();
            if (input.StartsWith("sudo ")) {
                input.Remove(0, 5);
                Terminal(input.Remove(0, 5), true);
                }
            else { Terminal(input, false); }
            
        }
        private void Terminal(string input, Boolean super)
        {
            if (input == "help")
            {
                Console.WriteLine("help -- Shows help infomation");
                Console.WriteLine("restart -- Reboot the machine");
                Console.WriteLine("shutdown -- Shutdown the machine");
                Console.WriteLine("fs -- Perform a file system check");
            }
            else if (input == "restart")
            {
                Sys.Power.Reboot();
            }
            else if (input == "shutdown")
            {
                Sys.Power.Shutdown();
            }
            else if (input == "fs") {if (super == true)
                {
                    string[] filePaths = Directory.GetFiles(@"0:\");
                    var drive = new DriveInfo("0");
                    Console.WriteLine("Volume in drive 0 is " + $"{drive.VolumeLabel}");
                    Console.WriteLine("Directory of " + @"0:\");
                    Console.WriteLine("\n");
                    for (int i = 0; i < filePaths.Length; ++i)
                    {
                        string path = filePaths[i];
                        Console.WriteLine(System.IO.Path.GetFileName(path));
                    }
                    foreach (var d in System.IO.Directory.GetDirectories(@"0:\"))
                    {
                        var dir = new DirectoryInfo(d);
                        var dirName = dir.Name;

                        Console.WriteLine(dirName + " <DIR>");
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("        " + $"{drive.TotalSize}" + " bytes");
                    Console.WriteLine("        " + $"{drive.AvailableFreeSpace}" + " bytes free");
                }
                else if (super == false) {}
            }
            
        }
    }
}
