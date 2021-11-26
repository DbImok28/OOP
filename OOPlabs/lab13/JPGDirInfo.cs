using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class JPGDirInfo
    {
        public static int FileCount(string path)
        {
            var info = new DirectoryInfo(path);
            return info.GetFiles().Length;
        }
        public static DateTime CreationDate(string path)
        {
            var info = new DirectoryInfo(path);
            return info.CreationTime;
        }
        public static int SubDirCount(string path)
        {
            var info = new DirectoryInfo(path);
            return info.GetDirectories().Length;
        }
        public static string RootDir(string path)
        {
            var info = new DirectoryInfo(path);
            return info.Parent.Name;
        }
    }
}
