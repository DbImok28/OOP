using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class JPGFileManager
    {
        public static void Inspect(string path)
        {
            Directory.CreateDirectory("JPGInspect");
            using (var f = new StreamWriter("JPGInspect/jpgdirinfo.txt", true))
            {
                var info = new DirectoryInfo(path);
                foreach (var file in info.GetFiles())
                {
                    f.WriteLine(file.Name);
                }
                File.Copy("JPGInspect/jpgdirinfo.txt", "dirinfo.txt");
                File.Delete("JPGInspect/jpgdirinfo.txt");
            }
        }
        public static void CopyByExtension(string path, string extension)
        {
            Directory.CreateDirectory("JPGFiles");
            var info = new DirectoryInfo(path);
            foreach (var file in info.GetFiles($"*{extension}"))
            {
                File.Copy(file.FullName, $"JPGFiles/{file.Name}");
            }
        }
        /*public static void Archive(string path)
        {
            ZipFile.CreateFromDirectiory("JPGInspect", "zip");
        }*/
    }
}
