using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            JPGLog.Log("hello");
            JPGLog.Log("hey");

            Console.WriteLine(JPGDiskInfo.DiskSize());
            Console.WriteLine(JPGDiskInfo.FileSystemInfo());
            Console.WriteLine(JPGDiskInfo.DiskInfo());
            Console.WriteLine();

            Console.WriteLine(JPGFileInfo.FileFullPath("jpglogfile.txt"));
            Console.WriteLine(JPGFileInfo.jpgFileInfo("jpglogfile.txt"));
            Console.WriteLine(JPGFileInfo.CreationDate("jpglogfile.txt"));
            Console.WriteLine(JPGFileInfo.ChangeDate("jpglogfile.txt"));
            Console.WriteLine();

            Console.WriteLine(JPGDirInfo.FileCount("dir"));
            Console.WriteLine(JPGDirInfo.CreationDate("dir"));
            Console.WriteLine(JPGDirInfo.SubDirCount("dir"));
            Console.WriteLine(JPGDirInfo.RootDir("dir"));
            Console.WriteLine();

            Console.WriteLine(JPGLog.GetByTime(DateTime.Parse("19.11.2021 19:46:03")));
            Console.WriteLine(JPGLog.GetByMessage("hey"));
            Console.ReadKey();
        }
    }
}
