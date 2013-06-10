using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace red
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the directory path you would like to remove the files from:");
            String dir = Console.ReadLine();

            dir.Replace('\\', '/');
            if (!dir.EndsWith("/")) dir += '/';

            RemoveIfEmpty(dir);

        }

        static bool RemoveIfEmpty(DirectoryInfo Dir)
        {
            bool r = false;

            DirectoryInfo[] Dirs = Dir.GetDirectories();
            int n = Dirs.Length;
            if (n != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    RemoveIfEmpty(Dirs[i]);
                }
            }

            if (Dir.GetFiles().Length == 0 && Dir.GetDirectories().Length == 0)
            {
                Dir.Delete();
                Console.WriteLine("Removing the Empty Directory [" + Dir.FullName + "]");
                r = true;
            }
            else
                Console.WriteLine("Skipping the Empty Directory [" + Dir.FullName + "]");

            return r;
        }

        static bool RemoveIfEmpty(String dir)
        {
            return RemoveIfEmpty( new DirectoryInfo(dir) );
        }
    }
}
