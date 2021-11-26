using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class JPGFileInfo
    {
        public static string FileFullPath(string path)
        {
            return Path.GetFullPath(path);
        }
        public static string jpgFileInfo(string path)
        {
            StringBuilder sb = new StringBuilder();
            FileInfo info = new FileInfo(path);
            sb.Append("Name:");
            sb.Append(info.Name);
            sb.Append(", Extension:");
            sb.Append(info.Extension);
            sb.Append(", Size:");
            sb.Append(info.Length.ToString());
            return sb.ToString();
        }
        public static DateTime CreationDate(string path)
        {
            FileInfo info = new FileInfo(path);
            return info.CreationTime;
        }
        public static DateTime ChangeDate(string path)
        {
            FileInfo info = new FileInfo(path);
            return info.LastAccessTime;
        }
    }
}
