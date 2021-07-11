using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using AlfieOS;

namespace AlfieOS.terminal
{
    public class Ter
    {
        public static void Terminal(string input, Boolean super)
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
            else if (input == "fs")
            {
                if (super == true)
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
                else if (super == false) { Kernel.rExpection(503); }
                else if (input.StartsWith("cat "))
                {
                    try
                    {
                        var hello_file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\" + input.Remove(0, 4));
                        var hello_file_stream = hello_file.GetFileStream();

                        if (hello_file_stream.CanRead)
                        {
                            byte[] text_to_read = new byte[hello_file_stream.Length];
                            hello_file_stream.Read(text_to_read, 0, (int)hello_file_stream.Length);
                            Console.WriteLine(Encoding.Default.GetString(text_to_read));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else if (input.StartsWith("wt "))
                {
                    try
                    {
                        var hello_file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\" + input.Remove(0, 3));
                        Console.Write("What should we write?");
                        string toWrite = Console.ReadLine();
                        var hello_file_stream = hello_file.GetFileStream();

                        if (hello_file_stream.CanWrite)
                        {
                            byte[] text_to_write = Encoding.ASCII.GetBytes(toWrite);
                            hello_file_stream.Write(text_to_write, 0, text_to_write.Length);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }
            }
        }
    }
}